namespace Fiscalizator.Helpers
{
    public static class EnumHelper
    {
        public static bool IsDefined<T>(string value) where T : Enum
        {
            return Enum.GetNames(typeof(T))
                       .Any(name => name.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
    }
}
