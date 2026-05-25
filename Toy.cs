using System;

namespace Lab4_v3
{
    // іграшка
    class Toy : Product
    {
        public string AgeGroup { get; set; }
        public string Material { get; set; }
        public int ExpirationMonths { get; set; }
        public int EducationalValue { get; set; }

        // конструктор без параметрів
        public Toy() : base()
        {
            AgeGroup = "невідомо";
            Material = "невідомо";
            ExpirationMonths = 0;
            EducationalValue = 0;
        }

        // конструктор з параметрами
        public Toy(string brand, decimal price, string size, double weight, string quality,
                   string ageGroup, string material, int expirationMonths, int educationalValue)
            : base(brand, price, size, weight, quality)
        {
            AgeGroup = ageGroup;
            Material = material;
            ExpirationMonths = expirationMonths;
            EducationalValue = educationalValue;
        }

        // конструктор копіювання
        public Toy(Toy other) : base(other)
        {
            AgeGroup = other.AgeGroup;
            Material = other.Material;
            ExpirationMonths = other.ExpirationMonths;
            EducationalValue = other.EducationalValue;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n=== іграшка ===");
            base.DisplayInfo();
            Console.WriteLine($"вікова група: {AgeGroup}, матеріал: {Material}, строк користування: {ExpirationMonths} міс., освітня цінність: {EducationalValue}/100");
        }

        // іграшки розвивають інтелект
        public override string Benefit()
        {
            return $"іграшка розвиває інтелект (освітня цінність {EducationalValue}/100)";
        }

        // популярність дорівнює освітній цінності
        public override int Popularity()
        {
            return EducationalValue;
        }

        // вартість іграшок у кошику за рік
        public override decimal BasketCost(int annualQuantity)
        {
            return Price * annualQuantity;
        }

        // бінарні оператори

        public static Toy operator +(Toy a, Toy b)
        {
            Toy r = new Toy(a);
            r.Price += b.Price;
            r.Weight += b.Weight;
            r.EducationalValue = Math.Min(100, r.EducationalValue + b.EducationalValue);
            return r;
        }

        public static Toy operator -(Toy a, Toy b)
        {
            Toy r = new Toy(a);
            r.Price = Math.Max(0, r.Price - b.Price);
            r.Weight = Math.Max(0, r.Weight - b.Weight);
            r.EducationalValue = Math.Max(0, r.EducationalValue - b.EducationalValue);
            return r;
        }

        public static bool operator ==(Toy? a, Toy? b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Brand == b.Brand && a.Price == b.Price;
        }

        public static bool operator !=(Toy? a, Toy? b) => !(a == b);
        public static bool operator >(Toy a, Toy b) => a.Price > b.Price;
        public static bool operator <(Toy a, Toy b) => a.Price < b.Price;

        // унарні оператори

        // збільшити освітню цінність
        public static Toy operator ++(Toy a)
        {
            if (a.EducationalValue < 100) a.EducationalValue++;
            return a;
        }

        // зменшити освітню цінність
        public static Toy operator --(Toy a)
        {
            if (a.EducationalValue > 0) a.EducationalValue--;
            return a;
        }

        public override bool Equals(object? obj) => obj is Toy t && this == t;
        public override int GetHashCode() => HashCode.Combine(Brand, Price);
    }
}
