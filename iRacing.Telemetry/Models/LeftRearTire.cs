﻿namespace iRacing.Telemetry.Models
{
    public class LeftRearTire
    {
        #region properties
        public int ColdPressure { get; set; }
        public int LastHotPressure { get; set; }
        public int[] LastTempsOMI { get; set; }
        public int[] TreadRemaining { get; set; }
        #endregion

        #region ctor
        public LeftRearTire()
        {
        }
        #endregion
    }
}
