using System;

namespace Lab4_v3
{
    // базовий клас товар
    abstract class Product : IComparable<Product>
    {
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public string Quality { get; set; }

        // конструктор без параметрів
        public Product()
        {
            Brand = "невідомо";
            Price = 0m;
            Size = "невідомо";
            Weight = 0.0;
            Quality = "невідомо";
        }

        // конструктор з параметрами
        public Product(string brand, decimal price, string size, double weight, string quality)
        {
            Brand = brand;
            Price = price;
            Size = size;
            Weight = weight;
            Quality = quality;
        }

        // конструктор копіювання
        public Product(Product other)
        {
            Brand = other.Brand;
            Price = other.Price;
            Size = other.Size;
            Weight = other.Weight;
            Quality = other.Quality;
        }

        // вивід інформації про товар
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"торгова марка: {Brand}, ціна: {Price} грн, розмір: {Size}, вага: {Weight} кг, якість: {Quality}");
        }

        // користь товару для людини
        public virtual string Benefit()
        {
            return "товар приносить загальну користь";
        }

        // популярність товару від 0 до 100
        public virtual int Popularity()
        {
            return 50;
        }

        // вартість у споживчому кошику
        public virtual decimal BasketCost(int quantity)
        {
            return Price * quantity;
        }

        // порівняння за ціною
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }
}
