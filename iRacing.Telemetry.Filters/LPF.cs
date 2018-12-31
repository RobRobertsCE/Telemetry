namespace iRacing.Telemetry.Filters
{
    // Low pass filter

    public static class LPF
    {
        private static readonly float ALPHA = 0.1F;

        public static float[] Filter(float x, float y, float z)
        {
            float[] filteredValues = new float[3];
            filteredValues[0] = x * ALPHA + filteredValues[0] * (1.0f - ALPHA);
            filteredValues[1] = y * ALPHA + filteredValues[1] * (1.0f - ALPHA);
            filteredValues[2] = z * ALPHA + filteredValues[2] * (1.0f - ALPHA);
            return filteredValues;
        }
    }
}
