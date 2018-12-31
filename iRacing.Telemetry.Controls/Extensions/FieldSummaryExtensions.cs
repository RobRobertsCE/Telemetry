using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.Telemetry.Controls.Extensions
{
    public static class FieldSummaryExtensions
    {
        public static int StandardDeviation(this IEnumerable<int> values)
        {
            double avg = values.Average();
            return (int)Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static float StandardDeviation(this IEnumerable<float> values)
        {
            float avg = values.Average();
            return (float)Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static int Mode(this IEnumerable<int> values)
        {
            return values.GroupBy(n => n).
                OrderByDescending(g => g.Count()).
                Select(g => g.Key).FirstOrDefault();
        }

        public static float Mode(this IEnumerable<float> values)
        {
            return values.GroupBy(n => n).
               OrderByDescending(g => g.Count()).
               Select(g => g.Key).FirstOrDefault();
        }

        public static double Mode(this IEnumerable<double> values)
        {
            return values.GroupBy(n => n).
              OrderByDescending(g => g.Count()).
              Select(g => g.Key).FirstOrDefault();
        }
    }
}
