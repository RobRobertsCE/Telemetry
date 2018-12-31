using System.Collections.ObjectModel;
using System.ComponentModel;

namespace iRacing.Telemetry.Controls.Models
{
    public interface ILineGraphModel : INotifyPropertyChanged
    {
        ObservableCollection<ILineGraphSeries> SeriesCollection { get; }
        SummaryColumnFlags SummaryFlags { get; }

        void Save(string fileName);
        string Serialize();
    }
}