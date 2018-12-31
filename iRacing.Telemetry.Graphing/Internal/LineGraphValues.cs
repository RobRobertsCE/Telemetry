using iRacing.Telemetry.Graphing.Models;

namespace iRacing.Telemetry.Graphing.Internal
{
    internal class LineGraphValues : ILineGraphValues
    {
        #region fields
        float[,,] _valueArray;
        #endregion

        #region ctor
        private LineGraphValues()
        {

        }
        public LineGraphValues(int lapCount, int maxFrameCount, int fieldCount)
        {
            _valueArray = new float[lapCount, maxFrameCount, fieldCount];
        }
        #endregion

        #region public
        public void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value)
        {
            _valueArray[lapIdx, frameIdx, fieldIdx] = value;
        }
        public float GetValue(int lapIdx, int frameIdx, int fieldIdx)
        {
            return _valueArray[lapIdx, frameIdx, fieldIdx];
        }
        public float[] GetLapFieldValues(int lapIdx, int fieldIdx)
        {
            int valueCount = GetLength(ArrayIndex.Frame);

            float[] values = new float[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                values[i] = _valueArray[lapIdx, i, fieldIdx];
            }

            return values;
        }
        public float[,] GetSessionFieldValues(int fieldIdx)
        {
            int lapCount = GetLength(ArrayIndex.Lap);
            int frameCount = GetLength(ArrayIndex.Frame);

            float[,] values = new float[lapCount, frameCount];

            for (int lapIdx = 0; lapIdx < lapCount; lapIdx++)
            {
                for (int frameIdx = 0; frameIdx < frameCount; frameIdx++)
                {
                    values[lapIdx, frameIdx] = _valueArray[lapIdx, frameIdx, fieldIdx];
                }
            }

            return values;
        }
        public float[] GetLapFrameValue(int lapIdx, int frameIdx)
        {
            int valueCount = GetLength(ArrayIndex.Field);

            float[] values = new float[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                values[i] = _valueArray[lapIdx, frameIdx, i];
            }

            return values;
        }
        public int GetLength(int i)
        {
            return _valueArray.GetLength(i);
        }
        public int GetLength(ArrayIndex i)
        {
            return _valueArray.GetLength((int)i);
        }
        #endregion
    }
}
