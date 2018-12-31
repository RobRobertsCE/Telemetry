using System.ComponentModel;
using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models
{
    public interface ILineGraphSeries : INotifyPropertyChanged
    {
        LineGraphYAxis YAxis { get; set; }
        Color Color { get; set; }
        int FieldIndex { get; set; }
        string Format { get; set; }
        string Key { get; set; }
        int Maximum { get; set; }
        float? MaxWarning { get; set; }
        int Minimum { get; set; }
        float? MinWarning { get; set; }
        string Name { get; set; }
        bool ShowMaximumWarning { get; set; }
        bool ShowMinimumWarning { get; set; }
        bool ShowLapMinimum { get; set; }
        bool ShowLapMaximum { get; set; }
        bool ShowLapAverage { get; set; }
        string Unit { get; set; }
        float LineThickness { get; set; }

        void Save(string fileName);

        event PropertyChangedEventHandler PropertyChanged;
    }
}
