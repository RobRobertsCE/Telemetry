using System;
using System.Linq;
using System.Text;

namespace iRacing.TelemetryFile.Models
{
    public class TelemetryFieldValueOfT<T>
    {
        #region properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public Int32 DataType { get; set; }
        public int Size
        {
            get
            {
                if (DataType == 1) // 1 = bool
                    return 1;
                else if (DataType == 2) // 2 = int?
                    return 4;
                else if (DataType == 3) // 3 = irsdk_EngineWarnings only
                    return 4;
                else if (DataType == 4) // 4 = float?
                    return 4;
                else if (DataType == 5) // 5 = float?
                    return 8;
                else
                    return 0;
            }
        }
        public Int32 Position { get; set; }
        public T Value { get { return GetFieldValue(); } }
        public string ByteString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int s = 0; s < Bytes.Count(); s++)
                {
                    var hexString = Bytes[s].ToString("X");
                    hexString = (hexString.Length % 2 == 0 ? "" : "0") + hexString + " ";
                    sb.Append(hexString);
                }
                return sb.ToString();
            }
        }
        public byte[] Bytes { get; set; }
        #endregion

        #region private methods
        T GetFieldValue()
        {
            object fieldValue = null;

            switch (DataType)
            {
                case 1:
                {
                    fieldValue = BitConverter.ToBoolean(Bytes, 0);
                    break;
                }
                case 2:
                {
                    fieldValue = BitConverter.ToInt16(Bytes, 0);
                    break;
                }
                case 3:
                {
                    fieldValue = BitConverter.ToInt16(Bytes, 0);
                    break;
                }
                case 4:
                {
                    fieldValue = BitConverter.ToSingle(Bytes, 0);
                    break;
                }
                case 5:
                {
                    fieldValue = BitConverter.ToDouble(Bytes, 0);
                    break;
                }
            }
            return (T)fieldValue;
        }
        #endregion
    }
}