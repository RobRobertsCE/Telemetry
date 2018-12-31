namespace iRacing.Telemetry.Filters
{
    // Moving average filter

    public static class MAA
    {
        private const int SMOOTH_FACTOR_MAA = 2;//increase for better results   but hits cpu bad

        public static float[] processWithMovingAverageGravity(float[] list, float[] gList)
        {
            int listSize = list.Length;//input list
            int iterations = listSize / SMOOTH_FACTOR_MAA;
            if (gList.Length != 0)
            {
                gList = new float[listSize];
            }
            int gListCount = 0;
            for (int i = 0, node = 0; i < iterations; i++)
            {
                float num = 0;
                for (int k = node; k < node + SMOOTH_FACTOR_MAA; k++)
                {
                    num = num + list[k];
                }
                node = node + SMOOTH_FACTOR_MAA;
                num = num / SMOOTH_FACTOR_MAA;
                //gList.add(num);//out put list
                gList[gListCount] = num;
                gListCount++;
            }
            return gList;
        }
    }
}
