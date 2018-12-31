using System.Collections.Generic;

namespace iRacing.TelemetrySessions.Models
{
    public class TreadReadings : Dictionary<TreadReadingPositions, decimal>
    {
        public decimal Inside
        {
            get
            {
                return this[TreadReadingPositions.Inside];
            }
            set
            {
                this[TreadReadingPositions.Inside] = value;
            }
        }
        public decimal Middle
        {
            get
            {
                return this[TreadReadingPositions.Middle];
            }
            set
            {
                this[TreadReadingPositions.Middle] = value;
            }
        }
        public decimal Outside
        {
            get
            {
                return this[TreadReadingPositions.Outside];
            }
            set
            {
                this[TreadReadingPositions.Outside] = value;
            }
        }
    }
}
