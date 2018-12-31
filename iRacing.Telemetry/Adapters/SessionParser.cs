using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Models;
using iRacing.Telemetry.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Adapters
{
    public class SessionParser : ISessionParser
    {
        #region fields
        private IDictionary<string, string> _sanitizePrefixMaps = null;
        private IDictionary<string, string> _sanitizeSuffixMaps = null;
        #endregion

        #region properties
        public IList<FormatExceptionError> FormatExceptions { get; set; } = new List<FormatExceptionError>();
        public IList<UnhandledDataTypeError> UnhandledDataTypes { get; set; } = new List<UnhandledDataTypeError>();
        public IList<IFieldDefinition> SessionFieldDefinitions { get; set; } = new List<IFieldDefinition>();
        #endregion

        #region classes
        public class FormatExceptionError
        {
            public string Field { get; set; }
            public string Value { get; set; }

        }
        public class UnhandledDataTypeError : FormatExceptionError
        {
            public string DataType { get; set; }
        }
        public class TelemetrySessionFieldDefinition : IFieldDefinition
        {
            public string DataTypeName { get; set; }
            public string Description { get; set; }
            public string Group { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
            public string Unit { get; set; }
            public irsdk_VarType DataType { get; set; }
            public int Size { get; set; }
            public Int32 Position { get; set; }
            public bool IsCalculated { get; set; }
        }
        #endregion

        #region public
        public async Task<TelemetrySet> ParseTelemetrySessionAsync(IDictionary<object, object> telemetryValues)
        {
            var set = new TelemetrySet();

            await UpdateTelemetrySessionAsync(telemetryValues, set);

            return set;
        }

        public async Task UpdateTelemetrySessionAsync(IDictionary<object, object> telemetryValues, TelemetrySet telemetryInstance)
        {
            await Task.Run(() =>
            {
                FormatExceptions = new List<FormatExceptionError>();
                UnhandledDataTypes = new List<UnhandledDataTypeError>();

                BuildSanitizeMaps();

                // WeekendInfo
                IDictionary<object, object> weekendInfoValues = (IDictionary<object, object>)telemetryValues["WeekendInfo"];
                SetValues(telemetryInstance.WeekendInfo, weekendInfoValues);

                // WeekendInfo.WeekendOptions
                IDictionary<object, object> weekendOptionsValues = (IDictionary<object, object>)weekendInfoValues["WeekendOptions"];
                SetValues(telemetryInstance.WeekendInfo.WeekendOptions, weekendOptionsValues);

                // SessionInfo
                IDictionary<object, object> sessionInfoValues = (IDictionary<object, object>)telemetryValues["SessionInfo"];
                var sessionList = (IList<object>)sessionInfoValues["Sessions"];
                foreach (IDictionary<object, object> sessionItemValues in sessionList)
                {
                    var sessionInstance = new Session();
                    SetValues(sessionInstance, sessionItemValues);

                    var resultsPositionList = (IList<object>)sessionItemValues["ResultsPositions"];
                    if (resultsPositionList != null)
                    {
                        foreach (IDictionary<object, object> resultsPositionValues in resultsPositionList)
                        {
                            var resultsPositionsInstance = new ResultsPosition();
                            SetValues(resultsPositionsInstance, resultsPositionValues);
                            sessionInstance.ResultsPositions.Add(resultsPositionsInstance);
                        }
                    }

                    var resultsFastestLapList = (IList<object>)sessionItemValues["ResultsFastestLap"];
                    foreach (IDictionary<object, object> resultsFastestLapValues in resultsFastestLapList)
                    {
                        var resultsFastestLapInstance = new ResultsFastestLap();
                        SetValues(resultsFastestLapInstance, resultsFastestLapValues);
                        sessionInstance.ResultsFastestLap.Add(resultsFastestLapInstance);
                    }

                    telemetryInstance.SessionInfo.Sessions.Add(sessionInstance);
                }

                // DriverInfo
                IDictionary<object, object> driverInfoValues = (IDictionary<object, object>)telemetryValues["DriverInfo"];
                SetValues(telemetryInstance.DriverInfo, driverInfoValues);

                var driverList = (IList<object>)driverInfoValues["Drivers"];
                foreach (IDictionary<object, object> driverValues in driverList)
                {
                    var driverInstance = new Driver();
                    SetValues(driverInstance, driverValues);
                    telemetryInstance.DriverInfo.Drivers.Add(driverInstance);
                }

                // SplitTimeInfo
                var splitTimeInfoValues = (IDictionary<object, object>)telemetryValues["SplitTimeInfo"];
                var sectorList = (IList<object>)splitTimeInfoValues["Sectors"];
                foreach (IDictionary<object, object> values in sectorList)
                {
                    var instance = new Sector();
                    SetValues(instance, values);
                    telemetryInstance.SplitTimeInfo.Sectors.Add(instance);
                }

                // CarSetup (sk modified)
                var setupValues = (IDictionary<object, object>)telemetryValues["CarSetup"];
                telemetryInstance.CarSetup.UpdateCount = int.Parse(setupValues["UpdateCount"].ToString());

                var tiresValues = (IDictionary<object, object>)setupValues["Tires"];
                SetValues(telemetryInstance.CarSetup.Tires.LeftFront, (IDictionary<object, object>)tiresValues["LeftFront"]);
                SetValues(telemetryInstance.CarSetup.Tires.LeftRear, (IDictionary<object, object>)tiresValues["LeftRear"]);
                SetValues(telemetryInstance.CarSetup.Tires.RightFront, (IDictionary<object, object>)tiresValues["RightFront"]);
                SetValues(telemetryInstance.CarSetup.Tires.RightRear, (IDictionary<object, object>)tiresValues["RightRear"]);

                var chassisValues = (IDictionary<object, object>)setupValues["Chassis"];
                SetValues(telemetryInstance.CarSetup.Chassis.Front, (IDictionary<object, object>)chassisValues["Front"]);
                SetValues(telemetryInstance.CarSetup.Chassis.LeftFront, (IDictionary<object, object>)chassisValues["LeftFront"]);
                SetValues(telemetryInstance.CarSetup.Chassis.LeftRear, (IDictionary<object, object>)chassisValues["LeftRear"]);
                SetValues(telemetryInstance.CarSetup.Chassis.RightFront, (IDictionary<object, object>)chassisValues["RightFront"]);
                SetValues(telemetryInstance.CarSetup.Chassis.RightRear, (IDictionary<object, object>)chassisValues["RightRear"]);
                SetValues(telemetryInstance.CarSetup.Chassis.Rear, (IDictionary<object, object>)chassisValues["Rear"]);
            });

            DisplayErrors();
        }

        public async Task<IList<IFieldDefinition>> BuildFieldDefinitionListAsync(IDictionary<object, object> telemetryValues)
        {
            SessionFieldDefinitions = new List<IFieldDefinition>();

            var telemetryInstance = new TelemetrySet();

            await Task.Run(() =>
            {
                FormatExceptions = new List<FormatExceptionError>();
                UnhandledDataTypes = new List<UnhandledDataTypeError>();

                BuildSanitizeMaps();

                // WeekendInfo
                IDictionary<object, object> weekendInfoValues = (IDictionary<object, object>)telemetryValues["WeekendInfo"];
                CreateFieldDefinitions("WeekendInfo", telemetryInstance.WeekendInfo, weekendInfoValues);

                // WeekendInfo.WeekendOptions
                IDictionary<object, object> weekendOptionsValues = (IDictionary<object, object>)weekendInfoValues["WeekendOptions"];
                CreateFieldDefinitions("WeekendInfo.WeekendOptions", telemetryInstance.WeekendInfo.WeekendOptions, weekendOptionsValues);

                // SessionInfo
                IDictionary<object, object> sessionInfoValues = (IDictionary<object, object>)telemetryValues["SessionInfo"];
                var sessionList = (IList<object>)sessionInfoValues["Sessions"];
                foreach (IDictionary<object, object> sessionItemValues in sessionList)
                {
                    var sessionInstance = new Session();
                    CreateFieldDefinitions("SessionInfo.Sessions[]", sessionInstance, sessionItemValues);

                    var resultsPositionList = (IList<object>)sessionItemValues["ResultsPositions"];
                    if (resultsPositionList != null)
                    {
                        foreach (IDictionary<object, object> resultsPositionValues in resultsPositionList)
                        {
                            var resultsPositionsInstance = new ResultsPosition();
                            CreateFieldDefinitions("SessionInfo.Sessions[].ResultsPositions[]", resultsPositionsInstance, resultsPositionValues);
                            sessionInstance.ResultsPositions.Add(resultsPositionsInstance);
                        }
                    }

                    var resultsFastestLapList = (IList<object>)sessionItemValues["ResultsFastestLap"];
                    foreach (IDictionary<object, object> resultsFastestLapValues in resultsFastestLapList)
                    {
                        var resultsFastestLapInstance = new ResultsFastestLap();
                        CreateFieldDefinitions("SessionInfo.Sessions[].ResultsFastestLap[]", resultsFastestLapInstance, resultsFastestLapValues);
                        sessionInstance.ResultsFastestLap.Add(resultsFastestLapInstance);
                    }

                    telemetryInstance.SessionInfo.Sessions.Add(sessionInstance);
                }

                // DriverInfo
                IDictionary<object, object> driverInfoValues = (IDictionary<object, object>)telemetryValues["DriverInfo"];
                CreateFieldDefinitions("DriverInfo", telemetryInstance.DriverInfo, driverInfoValues);

                var driverList = (IList<object>)driverInfoValues["Drivers"];
                foreach (IDictionary<object, object> driverValues in driverList)
                {
                    var driverInstance = new Driver();
                    CreateFieldDefinitions("DriverInfo.Drivers[]", driverInstance, driverValues);
                    telemetryInstance.DriverInfo.Drivers.Add(driverInstance);
                }

                // SplitTimeInfo
                var splitTimeInfoValues = (IDictionary<object, object>)telemetryValues["SplitTimeInfo"];
                var sectorList = (IList<object>)splitTimeInfoValues["Sectors"];
                foreach (IDictionary<object, object> values in sectorList)
                {
                    var instance = new Sector();
                    CreateFieldDefinitions("SplitTimeInfo.Sectors[]", instance, values);
                    telemetryInstance.SplitTimeInfo.Sectors.Add(instance);
                }

                // CarSetup (sk modified)
                var setupValues = (IDictionary<object, object>)telemetryValues["CarSetup"];
                CreateFieldDefinitions("CarSetup", telemetryInstance.CarSetup, (IDictionary<object, object>)telemetryValues["CarSetup"]);

                var tiresValues = (IDictionary<object, object>)setupValues["Tires"];
                CreateFieldDefinitions("CarSetup.Tires.LeftFront", telemetryInstance.CarSetup.Tires.LeftFront, (IDictionary<object, object>)tiresValues["LeftFront"]);
                CreateFieldDefinitions("CarSetup.Tires.LeftRear", telemetryInstance.CarSetup.Tires.LeftRear, (IDictionary<object, object>)tiresValues["LeftRear"]);
                CreateFieldDefinitions("CarSetup.Tires.RightFront", telemetryInstance.CarSetup.Tires.RightFront, (IDictionary<object, object>)tiresValues["RightFront"]);
                CreateFieldDefinitions("CarSetup.Tires.RightRear", telemetryInstance.CarSetup.Tires.RightRear, (IDictionary<object, object>)tiresValues["RightRear"]);

                var chassisValues = (IDictionary<object, object>)setupValues["Chassis"];
                CreateFieldDefinitions("CarSetup.Chassis.Front", telemetryInstance.CarSetup.Chassis.Front, (IDictionary<object, object>)chassisValues["Front"]);
                CreateFieldDefinitions("CarSetup.Tires.LeftFront", telemetryInstance.CarSetup.Chassis.LeftFront, (IDictionary<object, object>)chassisValues["LeftFront"]);
                CreateFieldDefinitions("CarSetup.Chassis.LeftRear", telemetryInstance.CarSetup.Chassis.LeftRear, (IDictionary<object, object>)chassisValues["LeftRear"]);
                CreateFieldDefinitions("CarSetup.Chassis.RightFront", telemetryInstance.CarSetup.Chassis.RightFront, (IDictionary<object, object>)chassisValues["RightFront"]);
                CreateFieldDefinitions("CarSetup.Chassis.RightRear", telemetryInstance.CarSetup.Chassis.RightRear, (IDictionary<object, object>)chassisValues["RightRear"]);
                CreateFieldDefinitions("CarSetup.Tires.Rear", telemetryInstance.CarSetup.Chassis.Rear, (IDictionary<object, object>)chassisValues["Rear"]);
            });

            DisplayErrors();

            return SessionFieldDefinitions;
        }
        #endregion

        #region protected
        protected virtual void SetValues(object target, IDictionary<object, object> values)
        {
            string propKey = "";

            foreach (var prop in target.GetType().GetProperties())
            {
                try
                {
                    propKey = prop.Name.ToString();

                    if (values.ContainsKey(propKey))
                    {
                        var propValue = values[propKey];

                        if (propValue != null)
                        {
                            propValue = Sanitize(propKey, propValue);

                            if (prop.PropertyType == typeof(string))
                            {
                                prop.SetValue(target, propValue);
                            }
                            else if (prop.PropertyType == typeof(decimal))
                            {
                                prop.SetValue(target, decimal.Parse(propValue.ToString()));
                            }
                            else if (prop.PropertyType == typeof(int))
                            {
                                prop.SetValue(target, int.Parse(propValue.ToString()));
                            }
                            else if (prop.PropertyType == typeof(Int32[]))
                            {
                                var propArrayValues = propValue.ToString().Split(',');
                                Int32[] arrayValues = new Int32[propArrayValues.Length];

                                for (int i = 0; i < propArrayValues.Length; i++)
                                {
                                    arrayValues[i] = int.Parse(propArrayValues[i]);
                                }

                                prop.SetValue(target, arrayValues, null);
                            }
                            else if (prop.PropertyType == typeof(bool))
                            {
                                var boolValue = (propValue.ToString() == "1");
                                prop.SetValue(target, boolValue);
                            }
                            else if (prop.PropertyType == typeof(IList<ResultsPosition>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(IList<Driver>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(IList<ResultsFastestLap>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(WeekendOptions))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(Tires))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(Chassis))
                            {
                                // skip this, handled
                            }
                            else
                            {
                                UnhandledDataTypes.Add(new UnhandledDataTypeError()
                                {
                                    Field = prop.Name,
                                    Value = values[prop.Name.ToString()].ToString(),
                                    DataType = prop.PropertyType.Name
                                });
                                //Console.WriteLine($"Unhandled data type: {prop.PropertyType.Name}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No value for {propKey}");
                    }
                }
                catch (FormatException)
                {
                    FormatExceptions.Add(new FormatExceptionError() { Field = prop.Name, Value = values[prop.Name.ToString()].ToString() });
                }
                catch (Exception ex)
                {
                    string errorValue = "MISSING";
                    if (values.ContainsKey(""))
                    {
                        errorValue = values[prop.Name.ToString()].ToString();
                    }
                    Console.WriteLine($"{propKey}: [{errorValue}] {ex.ToString()}");
                }
            }
        }

        protected virtual void CreateFieldDefinitions(string path, object target, IDictionary<object, object> values)
        {
            string propKey = "";

            foreach (var prop in target.GetType().GetProperties())
            {
                try
                {
                    propKey = prop.Name.ToString();

                    if (values.ContainsKey(propKey))
                    {
                        var propValue = values[propKey];

                        if (propValue != null)
                        {
                            if (prop.PropertyType == typeof(string))
                            {
                                SessionFieldDefinitions.Add(
                                    new TelemetrySessionFieldDefinition()
                                    {
                                        Name = propKey,
                                        DataType = irsdk_VarType.irsdk_char,
                                        DataTypeName = "String",
                                        Group = path,
                                        Key = $"{path}.{propKey}",
                                        Size = 0,
                                        IsCalculated = true,
                                        Unit = GetUnit(propKey)
                                    });
                            }
                            else if (prop.PropertyType == typeof(decimal))
                            {
                                SessionFieldDefinitions.Add(
                                      new TelemetrySessionFieldDefinition()
                                      {
                                          Name = propKey,
                                          DataType = irsdk_VarType.irsdk_float,
                                          DataTypeName = "Single",
                                          Group = path,
                                          Key = $"{path}.{propKey}",
                                          Size = 4,
                                          IsCalculated = true,
                                          Unit = GetUnit(propKey)
                                      });
                            }
                            else if (prop.PropertyType == typeof(float))
                            {
                                SessionFieldDefinitions.Add(
                                      new TelemetrySessionFieldDefinition()
                                      {
                                          Name = propKey,
                                          DataType = irsdk_VarType.irsdk_float,
                                          DataTypeName = "Single",
                                          Group = path,
                                          Key = $"{path}.{propKey}",
                                          Size = 4,
                                          IsCalculated = true,
                                          Unit = GetUnit(propKey)
                                      });
                            }

                            else if (prop.PropertyType == typeof(double))
                            {
                                SessionFieldDefinitions.Add(
                                      new TelemetrySessionFieldDefinition()
                                      {
                                          Name = propKey,
                                          DataType = irsdk_VarType.irsdk_double,
                                          DataTypeName = "Double",
                                          Group = path,
                                          Key = $"{path}.{propKey}",
                                          Size = 8,
                                          IsCalculated = true,
                                          Unit = GetUnit(propKey)
                                      });
                            }
                            else if (prop.PropertyType == typeof(int))
                            {
                                SessionFieldDefinitions.Add(
                                     new TelemetrySessionFieldDefinition()
                                     {
                                         Name = propKey,
                                         DataType = irsdk_VarType.irsdk_int,
                                         DataTypeName = "Int32",
                                         Group = path,
                                         Key = $"{path}.{propKey}",
                                         Size = 4,
                                         IsCalculated = true,
                                         Unit = GetUnit(propKey)
                                     });
                            }
                            else if (prop.PropertyType == typeof(Int32[]))
                            {
                                SessionFieldDefinitions.Add(
                                     new TelemetrySessionFieldDefinition()
                                     {
                                         Name = propKey,
                                         DataType = irsdk_VarType.irsdk_int,
                                         DataTypeName = "Int32[]",
                                         Group = path,
                                         Key = $"{path}.{propKey}",
                                         Size = 4,
                                         IsCalculated = true,
                                         Unit = GetUnit(propKey)
                                     });
                            }
                            else if (prop.PropertyType == typeof(bool))
                            {
                                SessionFieldDefinitions.Add(
                                     new TelemetrySessionFieldDefinition()
                                     {
                                         Name = propKey,
                                         DataType = irsdk_VarType.irsdk_bool,
                                         DataTypeName = "Boolean",
                                         Group = path,
                                         Key = $"{path}.{propKey}",
                                         Size = 1,
                                         IsCalculated = true,
                                         Unit = GetUnit(propKey)
                                     });
                            }
                            else if (prop.PropertyType == typeof(IList<ResultsPosition>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(IList<Driver>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(IList<ResultsFastestLap>))
                            {
                                // skip this, handled
                            }
                            else if (prop.PropertyType == typeof(WeekendOptions))
                            {
                                // skip this, handled
                            }
                            else
                            {
                                UnhandledDataTypes.Add(new UnhandledDataTypeError()
                                {
                                    Field = prop.Name,
                                    Value = values[prop.Name.ToString()].ToString(),
                                    DataType = prop.PropertyType.Name
                                });
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No value for {propKey}");
                    }
                }
                catch (FormatException)
                {
                    FormatExceptions.Add(new FormatExceptionError() { Field = prop.Name, Value = values[prop.Name.ToString()].ToString() });
                }
                catch (Exception ex)
                {
                    string errorValue = "MISSING";
                    if (values.ContainsKey(""))
                    {
                        errorValue = values[prop.Name.ToString()].ToString();
                    }
                    Console.WriteLine($"{propKey}: [{errorValue}] {ex.ToString()}");
                }
            }
        }

        protected virtual void BuildSanitizeMaps()
        {
            _sanitizePrefixMaps = new Dictionary<string, string>();
            _sanitizeSuffixMaps = new Dictionary<string, string>();

            _sanitizeSuffixMaps.Add("TrackLength", "km");
            _sanitizeSuffixMaps.Add("TrackAltitude", "m");
            _sanitizeSuffixMaps.Add("TrackLatitude", "m");
            _sanitizeSuffixMaps.Add("TrackLongitude", "m");
            _sanitizeSuffixMaps.Add("TrackNorthOffset", "rad");
            _sanitizeSuffixMaps.Add("TrackPitSpeedLimit", "kph");
            _sanitizeSuffixMaps.Add("TrackSurfaceTemp", "C");
            _sanitizeSuffixMaps.Add("TrackAirTemp", "C");
            _sanitizeSuffixMaps.Add("TrackAirPressure", "Hg");
            _sanitizeSuffixMaps.Add("TrackWindVel", "m/s");
            _sanitizeSuffixMaps.Add("TrackWindDir", "rad");

            _sanitizeSuffixMaps.Add("TrackRelativeHumidity", "%");
            _sanitizeSuffixMaps.Add("TrackFogLevel", "%");
            _sanitizeSuffixMaps.Add("WindSpeed", "km/h");
            _sanitizeSuffixMaps.Add("WeatherTemp", "C");
            _sanitizeSuffixMaps.Add("RelativeHumidity", "%");
            _sanitizeSuffixMaps.Add("FogLevel", "%");
            _sanitizeSuffixMaps.Add("CarClassMaxFuelPct", "%");
            _sanitizeSuffixMaps.Add("CarClassWeightPenalty", "kg");
            _sanitizeSuffixMaps.Add("ColdPressure", "kPa");
            _sanitizeSuffixMaps.Add("LastHotPressure", "kPa");
            _sanitizeSuffixMaps.Add("LastTempsOMI", "C");
            _sanitizeSuffixMaps.Add("TreadRemaining", "%");
            _sanitizeSuffixMaps.Add("LastTempsIMO", "C");
            _sanitizeSuffixMaps.Add("Stagger", "mm");

            _sanitizeSuffixMaps.Add("BallastForward", "m");
            _sanitizePrefixMaps.Add("BallastForward", "+");

            _sanitizeSuffixMaps.Add("NoseWeight", "%");
            _sanitizeSuffixMaps.Add("CrossWeight", "%");

            _sanitizeSuffixMaps.Add("ToeIn", "mm");
            _sanitizePrefixMaps.Add("ToeIn", "+");

            _sanitizeSuffixMaps.Add("SteeringOffset", "deg");
            _sanitizePrefixMaps.Add("SteeringOffset", "+");

            _sanitizeSuffixMaps.Add("FrontBrakeBias", "%");
            _sanitizeSuffixMaps.Add("SwayBarSize", "mm");
            _sanitizeSuffixMaps.Add("SwayBarArmLength", "mm");

            _sanitizeSuffixMaps.Add("LeftBarEndClearance", "mm");
            _sanitizePrefixMaps.Add("LeftBarEndClearance", "+");

            _sanitizeSuffixMaps.Add("CornerWeight", "N");
            _sanitizeSuffixMaps.Add("RideHeight", "mm");
            _sanitizeSuffixMaps.Add("ShockCollarOffset", "mm");
            _sanitizeSuffixMaps.Add("SpringRate", "N/mm");

            _sanitizeSuffixMaps.Add("BumpStiffness", "clicks");
            _sanitizePrefixMaps.Add("BumpStiffness", "+");

            _sanitizeSuffixMaps.Add("ReboundStiffness", "clicks");
            _sanitizePrefixMaps.Add("ReboundStiffness", "+");

            _sanitizeSuffixMaps.Add("Camber", "deg");
            _sanitizePrefixMaps.Add("Camber", "+");

            _sanitizeSuffixMaps.Add("Caster", "deg");
            _sanitizePrefixMaps.Add("Caster", "+");

            _sanitizeSuffixMaps.Add("FuelFillTo", "L");
            _sanitizeSuffixMaps.Add("SteeringRatio", ":1");
        }

        protected virtual string Sanitize(string key, object objValue)
        {
            string value = objValue.ToString();

            if (_sanitizePrefixMaps.ContainsKey(key))
            {
                var prefixValue = _sanitizePrefixMaps[key];
                value = value.Replace(prefixValue, "").Trim();
            }
            if (_sanitizeSuffixMaps.ContainsKey(key))
            {
                var suffixValue = _sanitizeSuffixMaps[key];
                value = value.Replace(suffixValue, "").Trim();
            }

            return value;
        }

        protected virtual string GetUnit(string key)
        {
            string unit = String.Empty;

            if (_sanitizeSuffixMaps.ContainsKey(key))
            {
                unit = _sanitizeSuffixMaps[key];
            }

            return unit;
        }

        protected virtual void DisplayErrors()
        {
            Console.WriteLine("Format errors");
            Console.WriteLine("------------------------------");
            foreach (FormatExceptionError formatError in FormatExceptions)
            {
                Console.WriteLine($"{formatError.Field}: {formatError.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Unhandled data type errors");
            Console.WriteLine("------------------------------");
            foreach (UnhandledDataTypeError unhandledTypeError in UnhandledDataTypes)
            {
                Console.WriteLine($"{unhandledTypeError.Field}: {unhandledTypeError.Value} : {unhandledTypeError.DataType}");
            }
        }
        #endregion
    }
}
