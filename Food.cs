using System;

namespace Lab4_v3
{
    // продукти харчування
    class Food : Product
    {
        public string ProductType { get; set; }
        public string HealthInfo { get; set; }
        public string StorageType { get; set; }
        public int ExpirationDays { get; set; }
        public int Calories { get; set; }

        // конструктор без параметрів
        public Food() : base()
        {
            ProductType = "невідомо";
            HealthInfo = "невідомо";
            StorageType = "невідомо";
            ExpirationDays = 0;
            Calories = 0;
        }

        // конструктор з параметрами
        public Food(string brand, decimal price, string size, double weight, string quality,
                    string productType, string healthInfo, string storageType,
                    int expirationDays, int calories)
            : base(brand, price, size, weight, quality)
        {
            ProductType = productType;
            HealthInfo = healthInfo;
            StorageType = storageType;
            ExpirationDays = expirationDays;
            Calories = calories;
        }

        // конструктор копіювання
        public Food(Food other) : base(other)
        {
            ProductType = other.ProductType;
            HealthInfo = other.HealthInfo;
            StorageType = other.StorageType;
            ExpirationDays = other.ExpirationDays;
            Calories = other.Calories;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n=== продукт харчування ===");
            base.DisplayInfo();
            Console.WriteLine($"тип: {ProductType}, корисність: {HealthInfo}, зберігання: {StorageType}, термін придатності: {ExpirationDays} днів, калорійність: {Calories} ккал/100г");
        }

        // продукти дають енергію
        public override string Benefit()
        {
            return $"продукт харчування дає енергію ({Calories} ккал/100г), {HealthInfo}";
        }

        // що калорійніше, то популярніше
        public override int Popularity()
        {
            return Math.Min(100, 50 + Calories / 10);
        }

        // вартість продукту у кошику за рік
        public override decimal BasketCost(int annualNormKg)
        {
            decimal pricePerKg = Weight > 0 ? Price / (decimal)Weight : Price;
            return pricePerKg * annualNormKg;
        }

        // бінарні оператори

        // додавання двох продуктів
        public static Food operator +(Food a, Food b)
        {
            Food r = new Food(a);
            r.Price += b.Price;
            r.Weight += b.Weight;
            r.Calories += b.Calories;
            return r;
        }

        // віднімання
        public static Food operator -(Food a, Food b)
        {
            Food r = new Food(a);
            r.Price = Math.Max(0, r.Price - b.Price);
            r.Weight = Math.Max(0, r.Weight - b.Weight);
            r.Calories = Math.Max(0, r.Calories - b.Calories);
            return r;
        }

        // рівність за брендом і ціною
        public static bool operator ==(Food? a, Food? b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Brand == b.Brand && a.Price == b.Price;
        }

        public static bool operator !=(Food? a, Food? b) => !(a == b);
        public static bool operator >(Food a, Food b) => a.Price > b.Price;
        public static bool operator <(Food a, Food b) => a.Price < b.Price;

        // унарні оператори

        // збільшити калорійність на 1
        public static Food operator ++(Food a)
        {
            a.Calories++;
            return a;
        }

        // зменшити калорійність на 1
        public static Food operator --(Food a)
        {
            if (a.Calories > 0) a.Calories--;
            return a;
        }

        // потрібні при перевантаженні ==
        public override bool Equals(object? obj) => obj is Food f && this == f;
        public override int GetHashCode() => HashCode.Combine(Brand, Price);
    }
}
