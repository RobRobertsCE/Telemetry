using System;

namespace iRacing.Setups.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class UnitTypeAttribute : Attribute
    {
        private UnitTypes _valueType;

        public UnitTypeAttribute(UnitTypes valueType)
        {
            _valueType = valueType;
        }
    }
}
