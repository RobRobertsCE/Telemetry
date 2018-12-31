namespace iRacing.Telemetry.Graphing.Models
{
    public interface ILineGraphModel
    {
        bool HasValues { get; }
        int FieldCount { get; }
        int FrameCount { get; }
        int LapCount { get; }
        int SeriesCount { get; }
        SummaryColumnFlags SummaryFlags { get; }

        int AddSeries(ILineGraphSeries series);
        float[] GetLapFieldValues(int lapIdx, int fieldIdx);
        float[] GetLapFrameValue(int lapIdx, int frameIdx);
        ILineGraphSeries GetSeries(int fieldIdx);
        float[,] GetSessionFieldValue(int fieldIdx);
        float GetValue(int lapIdx, int frameIdx, int fieldIdx);
        void Save(string fileName);
        void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value);
        void UpdateSeries(ILineGraphSeries series);
    }
}