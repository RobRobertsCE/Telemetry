namespace iRacing.Telemetry.Controls.Models
{
    public interface ILineGraphSeries : ILineGraphYAxis
    {
        int FieldIndex { get; set; }
        string Key { get; set; }
        float LineThickness { get; set; }
        bool ShowMinimumWarning { get; set; }
        float MinWarning { get; set; }
        bool ShowMaximumWarning { get; set; }
        float MaxWarning { get; set; }
        SummaryColumnFlags SummaryColumnFlags { get; set; }
        SeriesMapper SeriesMapper { get; }

        void Save(string fileName);
    }

    //public interface ILineGraphSeries : INotifyPropertyChanged
    //{
    //    string Name { get; set; }

    //    int FieldIndex { get; set; }
    //    string Key { get; set; }
    //    string Unit { get; set; }
    //    int Precision { get; set; }
    //    string Format { get; set; }

    //    Color Color { get; set; }
    //    float LineThickness { get; set; }

    //    float RangeStart { get; set; }
    //    float RangeEnd { get; set; }

    //    int Minimum { get; set; }
    //    bool ShowMinimumWarning { get; set; }
    //    float MinWarning { get; set; }

    //    int Maximum { get; set; }
    //    bool ShowMaximumWarning { get; set; }
    //    float MaxWarning { get; set; }
    //    SummaryColumnFlags SummaryColumnFlags { get; set; }

    //    LineGraphYAxis YAxis { get; set; }

    //    void Save(string fileName);
    //}
}
