using System;
using System.Reflection;
using System.Linq;
using iRacing.Telemetry.Controls.Models;
using iRacing.Telemetry.Controls.Attributes;

namespace iRacing.Telemetry.Controls.Extensions
{
    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

        public static SummaryColumnFlags GetSummaryFieldColumn(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(SummaryFieldColumnAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((SummaryFieldColumnAttribute)_Attribs.ElementAt(0)).SummaryColumnFlags;
                }
            }
            return SummaryColumnFlags.All;
        }
    }
}