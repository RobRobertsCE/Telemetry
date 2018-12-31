using iRacing.Common;

namespace iRacing.Setups.Models
{
    public class Weights : CornerValues<decimal>
    {
        public decimal Front
        {
            get
            {
                return this[Positions.LeftFront] +
                    this[Positions.RightFront];
            }
        }
        public decimal Left
        {
            get
            {
                return this[Positions.LeftFront] +
                  this[Positions.LeftRear];
            }
        }
        public decimal Cross
        {
            get
            {
                return this[Positions.LeftRear] +
                  this[Positions.RightFront];
            }
        }
        public decimal Total
        {
            get
            {
                return this[Positions.LeftFront] +
                  this[Positions.LeftRear] +
                  this[Positions.RightFront] +
                  this[Positions.RightRear];
            }
        }

        public decimal FrontPercent
        {
            get
            {
                return (Front / Total) * 100;
            }
        }
        public decimal LeftPercent
        {
            get
            {
                return (Left / Total) * 100;
            }
        }
        public decimal CrossPercent
        {
            get
            {
                return (Cross / Total) * 100;
            }
        }
    }
}
