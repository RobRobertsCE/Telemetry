using iRacing.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.Telemetry.Windows.Models
{
    // https://github.com/nlp80/irFFB/blob/master/irFFB/irsdk_defines.h
    public enum FieldConversionTypes
    {
        None,
        CelciusToFarenheit,
        KphToMph,
        KilometersToMiles,
        MetersToFeet,
        MetersPerSecondToFeetPerSecond,
        MillimetersToInches,
        LitersToGallons,
        KilogramsToPounds,
        KilogramsPerHourToPoundsPerHour,
        KilopascalsToInchesMercury,
        NewtonsToPounds,
        NewtonsPerMillimeterToPoundsPerInch,
        BarToPoundsPerSquareInch,
        MetersPerSecondSquaredToFeetPerSecondSquared,
        irsdk_EngineWarnings,
        irsdk_PitSvFlags,
        irsdk_SessionState,
        irsdk_TrkLoc,
        irsdk_TrkSurf
    }

    public static class FieldConverterService
    {
        static IDictionary<string, FieldConverterBase> _converters = null;
        private static IDictionary<string, FieldConverterBase> Converters
        {
            get
            {
                if (_converters == null)
                {
                    _converters = new Dictionary<string, FieldConverterBase>();

                    AddConverter(new EmptyConverter());

                    AddConverter(new KphToMphConverter());
                    AddConverter(new KphToMphConverter2());
                    AddConverter(new CelciusToFarenheitConverter());
                    AddConverter(new MsToFsConverter());
                    AddConverter(new MToFConverter());

                    AddConverter(new MmToInConverter());
                    AddConverter(new LToGConverter());
                    AddConverter(new KgToLbsConverter());
                    AddConverter(new KpaToInHgConverter());
                    AddConverter(new NewtonsToLbsConverter());

                    AddConverter(new irsdk_EngineWarningsConverter());
                    AddConverter(new irsdk_PitSvFlagsConverter());
                    AddConverter(new irsdk_SessionStateConverter());
                    AddConverter(new irsdk_TrkLocStateConverter());
                    AddConverter(new irsdk_TrkSurfConverter());

                    AddConverter(new NewtonsPerMillimeterToLbsInchConverter());
                    AddConverter(new Ms2ToFs2Converter());
                    AddConverter(new KghToLbsHConverter());
                    AddConverter(new KmToMConverter());
                    AddConverter(new LToGConverter2());

                    AddConverter(new BarToLbsSqInConverter());
                }

                return _converters;
            }
        }

        private static void AddConverter(FieldConverterBase converter)
        {
            _converters.Add(converter.UnitKey, converter);
        }

        public static T Convert<T>(string unit, T value)
        {
            var converter = Converters[unit];

            if (converter != null)
            {
                return ((FieldConverter<T>)converter).Convert(value);
            }
            else
                return value;
        }

        public static IList<FieldConverterBase> GetConverters()
        {
            return Converters.Values.ToList();
        }
        public static FieldConverterBase GetConverter(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Converters[""];
            }
            else
            {
                if (Converters.ContainsKey(key))
                {
                    return Converters[key];
                }
                else
                {
                    Console.WriteLine($">>>>>>>>>>>>>>>>>>>> No converter defined for {key}");
                    return Converters[""];
                }
            }
        }
    }
    public abstract class FieldConverterBase
    {
        public abstract string Name { get; }
        public virtual string UnitKey => "-";
        public abstract FieldConversionTypes FieldConversionType { get; }
        public abstract string Unit { get; }
    }
    public abstract class FieldConverter<T> : FieldConverterBase
    {
        public abstract T Convert(T value);
    }
    public abstract class FieldConverter<T, Y> : FieldConverterBase
    {
        public abstract Y Convert(T value);
    }

    public class EmptyConverter : FieldConverter<string>
    {
        public override string Name => "No conversion";
        public override string UnitKey => "";
        public override string Unit => "";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.None;

        public override string Convert(string value)
        {
            return value;
        }
    }

    public class irsdk_EngineWarningsConverter : FieldConverter<int, string>
    {
        public override string Name => "Engine Warnings Converter";
        public override string UnitKey => "irsdk_EngineWarnings";
        public override string Unit => "Engine Warnings";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.irsdk_EngineWarnings;

        public override string Convert(int value)
        {
            return ((irsdk_EngineWarnings)value).ToString();
        }
    }
    public class irsdk_PitSvFlagsConverter : FieldConverter<int, string>
    {
        public override string Name => "Pit Service Flags Converter";
        public override string UnitKey => "irsdk_PitSvFlags";
        public override string Unit => "Pit Service Flags";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.irsdk_PitSvFlags;

        public override string Convert(int value)
        {
            return ((irsdk_PitSvFlags)value).ToString();
        }
    }
    public class irsdk_SessionStateConverter : FieldConverter<int, string>
    {
        public override string Name => "Session State Converter";
        public override string UnitKey => "irsdk_SessionState";
        public override string Unit => "Session State";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.irsdk_SessionState;

        public override string Convert(int value)
        {
            return ((irsdk_SessionState)value).ToString();
        }
    }
    public class irsdk_TrkLocStateConverter : FieldConverter<int, string>
    {
        public override string Name => "Track Location Converter";
        public override string UnitKey => "irsdk_TrkLoc";
        public override string Unit => "Track Location";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.irsdk_TrkLoc;

        public override string Convert(int value)
        {
            return ((irsdk_TrkLoc)value).ToString();
        }
    }
    public class irsdk_TrkSurfConverter : FieldConverter<int, string>
    {
        public override string Name => "Track Surface Converter";
        public override string UnitKey => "irsdk_TrkSurf";
        public override string Unit => "Track Surface";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.irsdk_TrkSurf;

        public override string Convert(int value)
        {
            return ((irsdk_TrkSurf)value).ToString();
        }
    }

    public class Ms2ToFs2Converter : MsToFsConverter
    {
        public override string Name => "Meters/second^2 to Feet/second^2";
        public override string UnitKey => "m/s^2";
        public override string Unit => "f/s^2";
        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.MetersPerSecondSquaredToFeetPerSecondSquared;
    }
    public class KghToLbsHConverter : FieldConverter<float>
    {
        public override string Name => "kg/h to Lbs/h";
        public override string UnitKey => "kg/h";
        public override string Unit => "Lbs/h";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.KilogramsPerHourToPoundsPerHour;

        public override float Convert(float value)
        {
            return (float)(value * 2.20462);
        }
    }
    public class KmToMConverter : FieldConverter<float>
    {
        public override string Name => "km to m";
        public override string UnitKey => "km";
        public override string Unit => "m";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.KilometersToMiles;

        public override float Convert(float value)
        {
            return value * 0.621371F;
        }
    }
    public class LToGConverter2 : LToGConverter
    {
        public override string UnitKey => "l";
    }
    public class BarToLbsSqInConverter : FieldConverter<float>
    {
        public override string Name => "bar to Lbs/in^2";
        public override string UnitKey => "bar";
        public override string Unit => "Lbs/in^2";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.BarToPoundsPerSquareInch;

        public override float Convert(float value)
        {
            return value * 14.5038F;
        }
    }


    public class KphToMphConverter2 : KphToMphConverter
    {
        public override string UnitKey => "km/h";
        public override string Name => "km/h to mph";
        public override string Unit => "mph";
    }
    public class KphToMphConverter : FieldConverter<float>
    {
        public override string Name => "kph to mph";
        public override string UnitKey => "kph";
        public override string Unit => "mph";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.KphToMph;

        public override float Convert(float value)
        {
            return value * 0.621371F;
        }
    }
    public class CelciusToFarenheitConverter : FieldConverter<float>
    {
        public override string Name => "Celcius to Farenheit";
        public override string UnitKey => "C";
        public override string Unit => "F";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.CelciusToFarenheit;

        public override float Convert(float value)
        {
            return (float)(value * 1.8) + 32;
        }
    }
    public class MsToFsConverter : FieldConverter<float>
    {
        public override string Name => "Meters/second to Feet/second";
        public override string UnitKey => "m/s";
        public override string Unit => "f/s";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.CelciusToFarenheit;

        public override float Convert(float value)
        {
            return (float)(value * 3.28084);
        }
    }
    public class MToFConverter : FieldConverter<int>
    {
        public override string Name => "Meters to Feet";
        public override string UnitKey => "m";
        public override string Unit => "f";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.MetersToFeet;

        public override int Convert(int value)
        {
            return (int)(value * 3.28084);
        }
    }

    public class MmToInConverter : FieldConverter<int>
    {
        public override string Name => "Millimeters to Inches";
        public override string UnitKey => "mm";
        public override string Unit => "in";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.MillimetersToInches;

        public override int Convert(int value)
        {
            return (int)(value * 0.0393701);
        }
    }
    public class LToGConverter : FieldConverter<float>
    {
        public override string Name => "Liters to Gallons";
        public override string UnitKey => "L";
        public override string Unit => "G";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.LitersToGallons;

        public override float Convert(float value)
        {
            return (float)(value * 0.264172);
        }
    }
    public class KgToLbsConverter : FieldConverter<float>
    {
        public override string Name => "Kilograms to Pounds";
        public override string UnitKey => "kg";
        public override string Unit => "lbs";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.KilogramsToPounds;

        public override float Convert(float value)
        {
            return (float)(value * 2.20462);
        }
    }
    public class KpaToInHgConverter : FieldConverter<float>
    {
        public override string Name => "Kilopascals to Inches Of Mercury";
        public override string UnitKey => "kPa";
        public override string Unit => "in/Hg";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.KilopascalsToInchesMercury;

        public override float Convert(float value)
        {
            return (float)(value * 0.2953);
        }
    }
    public class NewtonsToLbsConverter : FieldConverter<float>
    {
        public override string Name => "Newtons to Pounds";
        public override string UnitKey => "N";
        public override string Unit => "Lbs";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.NewtonsToPounds;

        public override float Convert(float value)
        {
            return (float)(value * 0.224809);
        }
    }

    public class NewtonsPerMillimeterToLbsInchConverter : FieldConverter<float>
    {
        public override string Name => "Newtons/millimeter to Pounds/inch";
        public override string UnitKey => "N/mm";
        public override string Unit => "Lbs/in";

        public override FieldConversionTypes FieldConversionType => FieldConversionTypes.NewtonsPerMillimeterToPoundsPerInch;

        public override float Convert(float value)
        {
            return (float)(value * 5.71015);
        }
    }
}
