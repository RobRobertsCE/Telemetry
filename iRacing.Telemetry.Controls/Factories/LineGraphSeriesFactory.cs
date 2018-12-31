using iRacing.Telemetry.Controls.Models;
using iRacing.Telemetry.Controls.Models.Default;
using System.Drawing;

namespace iRacing.Telemetry.Controls.Factories
{
    public static class LineGraphSeriesFactory
    {
        public static ILineGraphSeries GetGenericSeries(
                        string key,
                        string displayName,
                        Color color,
                        float lineThickness,
                        string format,
                        string unit,
                        int min,
                        int max)
        {
            return new GenericLineGraphSeries(key, displayName, color, lineThickness, format, unit, min, max);
        }
        public static ILineGraphSeries GetSeries(string key)
        {
            ILineGraphSeries series = null;

            switch (key)
            {
                case ("Telemetry.RPM"):
                    {
                        series = new RpmLineGraphSeries();
                        break;
                    }
                case ("Telemetry.Throttle"):
                    {
                        series = new ThrottleLineGraphSeries();
                        break;
                    }
                case ("Telemetry.SteeringWheelAngle"):
                    {
                        series = new SteeringLineGraphSeries();
                        break;
                    }
                case ("Telemetry.Brake"):
                    {
                        series = new BrakeLineGraphSeries();
                        break;
                    }
                case ("Telemetry.Speed"):
                    {
                        series = new SpeedLineGraphSeries();
                        break;
                    }
            }

            return series;
        }
    }
}
