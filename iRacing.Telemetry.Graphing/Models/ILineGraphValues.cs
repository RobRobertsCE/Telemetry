namespace iRacing.Telemetry.Graphing.Models
{
    public interface ILineGraphValues
    {
        int GetLength(int i);
        int GetLength(ArrayIndex i);
        float GetValue(int lapIdx, int frameIdx, int fieldIdx);
        float[] GetLapFieldValues(int lapIdx, int fieldIdx);
        float[,] GetSessionFieldValues(int fieldIdx);
        float[] GetLapFrameValue(int lapIdx, int frameIdx);
        void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value);
    }
}