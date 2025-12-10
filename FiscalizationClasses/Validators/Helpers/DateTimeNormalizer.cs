namespace Fiscalizator.FiscalizationClasses.Validators.Helpers
{
    public static class DateTimeNormalizer
    {
        public static DateTime TrimToMilliseconds(DateTime dt)
        {
            long ticks = dt.Ticks - (dt.Ticks % TimeSpan.TicksPerMillisecond);
            return new DateTime(ticks, dt.Kind);
        }
    }

}
