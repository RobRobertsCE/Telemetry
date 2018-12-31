using System.Collections.Generic;
using System.Linq;

namespace iRacing.Telemetry.Controls.Models
{
    public class LineGraphDataModel : ILineGraphDataModel
    {
        #region fields
        private IList<TelemetryValues> _values = new List<TelemetryValues>();
        private IDictionary<int, IEnumerable<TelemetryValues>> _sessionValuesCache = null;
        #endregion

        #region properties
        public int FieldCount => _values.Select(v => v.FieldIdx).Distinct().Count();

        public bool HasValues => _values.Any();

        public int LapCount => _values.Select(v => v.LapIdx).Distinct().Count();
        #endregion

        #region public
        public int GetLapFrameCount(int lapIdx)
        {
            return _values.Where(v => v.LapIdx == lapIdx).Select(v => v.FrameIdx).Distinct().Count();
        }

        public float GetValue(int lapIdx, int frameIdx, int fieldIdx)
        {
            return _values.FirstOrDefault(v => v.LapIdx == lapIdx && v.FrameIdx == frameIdx && v.FieldIdx == fieldIdx).Value.GetValueOrDefault();
        }

        public IEnumerable<TelemetryValues> GetLapValues(int lapIdx)
        {
            return _values.Where(v => v.LapIdx == lapIdx);
        }
        public IEnumerable<TelemetryValues> GetFrameValues(int frameIdx)
        {
            return _values.Where(v => v.FrameIdx == frameIdx);
        }
        public IEnumerable<TelemetryValues> GetSessionFieldValues(int fieldIdx)
        {
            return GetSessionValues(fieldIdx);
        }
        public IEnumerable<TelemetryValues> GetLapFieldValues(int lapIdx, int fieldIdx)
        {
            return _values.Where(v => v.LapIdx == lapIdx && v.FieldIdx == fieldIdx);
        }

        public void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value)
        {
            _values.Add(new TelemetryValues() { LapIdx = lapIdx, FrameIdx = frameIdx, FieldIdx = fieldIdx, Value = value });
        }
        #endregion

        #region protected
        protected virtual IEnumerable<TelemetryValues> GetSessionValues(int fieldIdx)
        {
            if (_sessionValuesCache == null)
            {
                _sessionValuesCache = new Dictionary<int, IEnumerable<TelemetryValues>>();
            }

            if (!_sessionValuesCache.ContainsKey(fieldIdx))
            {
                _sessionValuesCache.Add(fieldIdx, _values.Where(v => v.FieldIdx == fieldIdx));
            }

            return _sessionValuesCache[fieldIdx];
        }
        #endregion
    }
}
