using iRacing.Telemetry.Controls.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.Telemetry.Controls.Internal
{
    internal static class LineGraphHelper
    {
        #region constants
        public const int DefaultLargeStepMultiplier = 4;
        public const int DefaultSmallStepMultiplier = 4;
        public const float DefaultLargeTickWidth = 6;
        public const float DefaultSmallTickWidth = 3;
        public const int DefaultPrecision = 3;
        #endregion

        #region public
        public static float MapValueToExactCoordinate(float rangeStart, float rangeEnd, float valuesStart, float valuesEnd, float value)
        {
            float rangeSpan = rangeEnd - rangeStart;
            float valuesSpan = valuesEnd - valuesStart;
            float adjustedValue = (valuesStart != 0) ? value - valuesStart : value;
            float valueOffset = adjustedValue / valuesSpan;
            float rangeOffset = valueOffset * rangeSpan;

            return Math.Abs(rangeOffset + rangeStart);
        }

        public static float MapValueToOffsetCoordinate(float coordinateRange, float valueRange, float value)
        {
            float valueOffset = value / valueRange;
            float rangeOffset = valueOffset * coordinateRange;

            return rangeOffset;
        }

        public static AxisTicks MapTicks(
            ILineGraphAxis axis,
            float fixedCoordinate,
            float startCoordinate,
            float endCoordinate)
        {
            AxisTicks ticks = new AxisTicks();

            float startValue = axis.Minimum;
            float endValue = axis.Maximum;

            float coordinateRange = endCoordinate - startCoordinate;
            float valueRange = endValue - startValue;

            float currentTickCoordinate = 0F;

            // iterate through the value scale
            for (float tickValue = startValue; tickValue < endValue; tickValue += axis.TickStep)
            {
                // map the coordinate to the value
                currentTickCoordinate = LineGraphHelper.MapValueToExactCoordinate(
                    startCoordinate,
                    endCoordinate,
                    startValue,
                    endValue,
                    tickValue);

                if (axis.ShowTicks)
                {
                    var newTick = new Tick()
                    {
                        X = fixedCoordinate,
                        Y = currentTickCoordinate
                    };

                    if (axis.ShowTickLabels)
                    {
                        var newLabel = new TickLabel()
                        {
                            X = fixedCoordinate,
                            Y = currentTickCoordinate,
                            Text = FormatLabel(
                               Math.Abs(
                                   Math.Round(
                                       tickValue,
                                       axis.Precision
                                       )
                                   ),
                               axis.Format)
                        };

                        newTick.Label = newLabel;

                        ticks.LargeLabels.Add(newLabel);
                    }

                    ticks.LargeTicks.Add(newTick);
                }
            }

            // Add the last tick
            if (axis.ShowTicks)
            {
                var newTick = new Tick()
                {
                    X = fixedCoordinate,
                    Y = endCoordinate
                };

                if (axis.ShowTickLabels)
                {
                    var newLabel = new TickLabel()
                    {
                        X = fixedCoordinate,
                        Y = endCoordinate,
                        Text = FormatLabel(
                        Math.Round(
                            endValue,
                            axis.Precision
                            ),
                        axis.Format)
                    };

                    newTick.Label = newLabel;

                    ticks.LargeLabels.Add(newLabel);
                }

                ticks.LargeTicks.Add(newTick);
            }

            return ticks;
        }
        #endregion

        #region private
        private static string FormatLabel(float value, string format)
        {
            string formatString = $"{{0:{format}}}";
            string result = String.Format(formatString, value);
            return result;
        }
        private static string FormatLabel(double value, string format)
        {
            string formatString = $"{{0:{format}}}";
            string result = String.Format(formatString, value);
            return result;
        }
        private static string FormatLabel(int value, string format)
        {
            string formatString = $"{{0:{format}}}";
            string result = String.Format(formatString, value).PadLeft(format.Length, ' ');
            return result;
        }
        #endregion
    }

    internal class AxisTicks
    {
        public IList<Tick> SmallTicks { get; set; } = new List<Tick>();
        public IList<Tick> LargeTicks { get; set; } = new List<Tick>();
        public IList<TickLabel> SmallLabels { get; set; } = new List<TickLabel>();
        public IList<TickLabel> LargeLabels { get; set; } = new List<TickLabel>();

        public IList<Tick> AllTicks
        {
            get
            {
                List<Tick> ticks = new List<Tick>(LargeTicks.ToList());
                ticks.AddRange(SmallTicks.ToList());
                return ticks.OrderBy(t => t.Y).ToList();
            }
        }
        public IList<Tick> AllTicksDescending
        {
            get
            {
                List<Tick> ticks = new List<Tick>(LargeTicks.ToList());
                ticks.AddRange(SmallTicks.ToList());
                return ticks.OrderByDescending(t => t.Y).ToList();
            }
        }
    }
}
