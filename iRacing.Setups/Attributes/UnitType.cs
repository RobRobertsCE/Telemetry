namespace iRacing.Setups.Attributes
{
    public class UnitType
    {
        public SystemOfMeasurement System { get; set; }
        public UnitTypes Type { get; set; }
        public bool IsConvertible
        {
            get { return (System != SystemOfMeasurement.General); }
        }
        public string DisplayTitle { get; set; }

        public UnitType(UnitTypes type, string displayTitle)
        {
            this.Type = type;
            this.DisplayTitle = displayTitle;
        }

        public UnitType(UnitTypes type, string displayTitle, SystemOfMeasurement system)
            : this(type, displayTitle)
        {
            this.System = system;
        }
    }
}
