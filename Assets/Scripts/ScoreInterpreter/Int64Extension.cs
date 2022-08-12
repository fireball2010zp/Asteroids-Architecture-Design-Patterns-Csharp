using UnityEngine;

namespace Asteroids.Interpreter
{
    public static class Int64Extension
    {
        static readonly string[] GroupPostfixes = new[]
        {
            string.Empty, "K", "M", "B", "T", "KT", "MT"
        };

        public static string ToAbbreviatedString(this long number, int startDigits = 5)
        {
            startDigits = Mathf.Clamp(startDigits, 4, int.MaxValue);
            int groups = 0;

            long remainder = number;
            while (remainder >= 1000L)
            {
                remainder /= 1000L;
                groups++;
            }

            long categoryDigits = 1;
            long categoryRemainder = remainder;
            while (categoryRemainder >= 10L)
            {
                categoryRemainder /= 10L;
                categoryDigits++;
            }

            if (groups * 3 + categoryDigits < startDigits)
            {
                return number.ToString();
            }

            float subgroupRatio = number / Mathf.Pow(1000.0f, groups) - 0.001f;
            if (subgroupRatio > 0.0f)
            {
                return $"{subgroupRatio:#.#}{GroupPostfixes[groups]}";
            }

            return $"{remainder:0}{GroupPostfixes[groups]}";
        }
    }
}
