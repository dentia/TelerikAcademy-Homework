namespace School
{
    public static class Validator
    {
        public static bool StringIsInvalid(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public static bool IdIsInRange(int id, int min, int max)
        {
            return min <= id && id <= max;
        }
    }
}
