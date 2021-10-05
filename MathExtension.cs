using System;

namespace BeaversDestiny
{
    public static class MathExtensions
    {
        public static int Ceiling(float n, int numDigits)
        {
            var f = Math.Pow(10, numDigits);
            return (int)(Math.Ceiling(n / f) * f);
        }

        public static int Floor(float n, int numDigits)
        {
            var f = Math.Pow(10, numDigits);
            return (int)(Math.Floor(n / f) * f);
        }

        public static int NumberOfDigits(int n)
        {
            return (int)Math.Floor(Math.Log10(n) + 1);
        }
    }
}