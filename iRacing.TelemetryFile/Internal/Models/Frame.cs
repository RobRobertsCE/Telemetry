using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.TelemetryFile.Internal.Models
{
    internal partial class Frame
    {
        #region properties
        public IList<IValue> FieldValues { get; set; }
        #endregion

        #region ctor
        public Frame()
        {
            FieldValues = new List<IValue>();
        }
        #endregion

        #region public methods
        public T GetTelemetryValue<T>(string key)
        {
            var field = FieldValues.FirstOrDefault(f => f.FieldName == key);

            if (null == field)
                return default(T);

            var readData = field.FieldValue;

            if (readData is T)
            {
                return (T)readData;
            }
            else
            {
                try
                {
                    return (T)Convert.ChangeType(readData, typeof(T));
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }
        }
        #endregion
    }
}