using System.Threading;

namespace CSharpLinq.Examples
{
    public static class Helper
    {
        public static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
                result *= i;
            return result;
        }

        public static int FactorialWithSleep(int x, int s)
        {
            Thread.Sleep(s);

            int result = 1;
            for (int i = 1; i <= x; i++)
                result *= i;
            return result;
        }
    }

    class Customer
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Name - {Name}, Age - {Age}, Language - {Language}";
        }
    }

    class Phone
    {
        public string Model { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Model - {Model}, Company - {Company}";
        }
    }

    class Player
    {
        public string Name { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }

    class Team
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Name} ({Country})";
        }
    }
}
