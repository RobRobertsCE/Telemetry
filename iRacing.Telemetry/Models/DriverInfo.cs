using System.Collections.Generic;

namespace iRacing.Telemetry.Models
{
    public class DriverInfo
    {
        #region properties
        public int DriverCarIdx { get; set; }
        public int DriverUserID { get; set; }
        public int PaceCarIdx { get; set; }
        public decimal DriverHeadPosX { get; set; }
        public decimal DriverHeadPosY { get; set; }
        public decimal DriverHeadPosZ { get; set; }
        public decimal DriverCarIdleRPM { get; set; }
        public decimal DriverCarRedLine { get; set; }
        public int DriverCarEngCylinderCount { get; set; }
        public decimal DriverCarFuelKgPerLtr { get; set; }
        public decimal DriverCarFuelMaxLtr { get; set; }
        public decimal DriverCarMaxFuelPct { get; set; }
        public decimal DriverCarSLFirstRPM { get; set; }
        public decimal DriverCarSLShiftRPM { get; set; }
        public decimal DriverCarSLLastRPM { get; set; }
        public decimal DriverCarSLBlinkRPM { get; set; }
        public decimal DriverPitTrkPct { get; set; }
        public decimal DriverCarEstLapTime { get; set; }
        public string DriverSetupName { get; set; }
        public int DriverSetupIsModified { get; set; }
        // TODO: public enum DriverSetupLoadTypeName { get; set; }
        public string DriverSetupLoadTypeName { get; set; }
        public int DriverSetupPassedTech { get; set; }
        public int DriverIncidentCount { get; set; }
        public IList<Driver> Drivers { get; set; } = new List<Driver>();
        #endregion

        #region ctor
        public DriverInfo()
        {
        }
        #endregion
    }
}

