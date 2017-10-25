namespace CSharpLinq.Examples
{
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
