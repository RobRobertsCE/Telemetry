using System;

namespace iRacing.Setups.Models
{
    public abstract class SetupBase
    {
        public Guid Id { get; set; }
        public string SetupName { get; set; }
        public int Revision { get; set; }
    }
}
