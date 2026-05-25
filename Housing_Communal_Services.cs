using System;

namespace Lab4_v3
{
    // новий клас житлово-комунальн≥ послуги
    class Housing_Communal_Services : Product
    {
        // закрит≥ пол€
        private string serviceType;
        private string provider;
        private decimal tariff;
        private string unit;
        private double monthlyConsumption;
        private string billingPeriod;

        // в≥дкрит≥ властивост≥ дл€ доступу
        public string ServiceType { get => serviceType; set => serviceType = value; }
        public string Provider { get => provider; set => provider = value; }
        public decimal Tariff { get => tariff; set => tariff = value; }
        public string Unit { get => unit; set => unit = value; }
        public double MonthlyConsumption { get => monthlyConsumption; set => monthlyConsumption = value; }
        public string BillingPeriod { get => billingPeriod; set => billingPeriod = value; }

        // конструктор без параметр≥в
        public Housing_Communal_Services() : base()
        {
            serviceType = "нев≥домо";
            provider = "нев≥домо";
            tariff = 0m;
            unit = "нев≥домо";
            monthlyConsumption = 0.0;
            billingPeriod = "нев≥домо";
        }

        // конструктор з параметрами
        public Housing_Communal_Services(string brand, decimal price, string size, double weight, string quality,
                                         string serviceType, string provider, decimal tariff,
                                         string unit, double monthlyConsumption, string billingPeriod)
            : base(brand, price, size, weight, quality)
        {
            this.serviceType = serviceType;
            this.provider = provider;
            this.tariff = tariff;
            this.unit = unit;
            this.monthlyConsumption = monthlyConsumption;
            this.billingPeriod = billingPeriod;
        }

        // конструктор коп≥юванн€
        public Housing_Communal_Services(Housing_Communal_Services other) : base(other)
        {
            serviceType = other.serviceType;
            provider = other.provider;
            tariff = other.tariff;
            unit = other.unit;
            monthlyConsumption = other.monthlyConsumption;
            billingPeriod = other.billingPeriod;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n=== житлово-комунальна послуга ===");
            base.DisplayInfo();
            Console.WriteLine($"тип послуги: {serviceType}, постачальник: {provider}, тариф: {tariff} грн/{unit}, споживанн€: {monthlyConsumption} {unit}/м≥с., пер≥од оплати: {billingPeriod}");
        }

        // послуги задовольн€ють ф≥зичн≥ потреби
        public override string Benefit()
        {
            return $"послуга {serviceType} задовольн€Ї ф≥зичн≥ потреби людини";
        }

        // послугами користуютьс€ вс≥
        public override int Popularity()
        {
            return 100;
        }

        // варт≥сть послуги за р≥к
        public override decimal BasketCost(int monthsPerYear)
        {
            return tariff * (decimal)monthlyConsumption * monthsPerYear;
        }

        // м≥с€чна варт≥сть послуги
        public decimal MonthlyCost() => tariff * (decimal)monthlyConsumption;

        // б≥нарн≥ оператори

        public static Housing_Communal_Services operator +(Housing_Communal_Services a, Housing_Communal_Services b)
        {
            Housing_Communal_Services r = new Housing_Communal_Services(a);
            r.tariff += b.tariff;
            r.monthlyConsumption += b.monthlyConsumption;
            r.Price += b.Price;
            return r;
        }

        public static Housing_Communal_Services operator -(Housing_Communal_Services a, Housing_Communal_Services b)
        {
            Housing_Communal_Services r = new Housing_Communal_Services(a);
            r.tariff = Math.Max(0, r.tariff - b.tariff);
            r.monthlyConsumption = Math.Max(0, r.monthlyConsumption - b.monthlyConsumption);
            r.Price = Math.Max(0, r.Price - b.Price);
            return r;
        }

        public static bool operator ==(Housing_Communal_Services? a, Housing_Communal_Services? b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.serviceType == b.serviceType && a.tariff == b.tariff;
        }

        public static bool operator !=(Housing_Communal_Services? a, Housing_Communal_Services? b) => !(a == b);

        // пор≥вн€нн€ за повною м≥с€чною варт≥стю
        public static bool operator >(Housing_Communal_Services a, Housing_Communal_Services b) => a.MonthlyCost() > b.MonthlyCost();
        public static bool operator <(Housing_Communal_Services a, Housing_Communal_Services b) => a.MonthlyCost() < b.MonthlyCost();

        // унарн≥ оператори

        // зб≥льшити споживанн€
        public static Housing_Communal_Services operator ++(Housing_Communal_Services a)
        {
            a.monthlyConsumption += 1;
            return a;
        }

        // зменшити споживанн€
        public static Housing_Communal_Services operator --(Housing_Communal_Services a)
        {
            if (a.monthlyConsumption >= 1) a.monthlyConsumption -= 1;
            return a;
        }

        public override bool Equals(object? obj) => obj is Housing_Communal_Services h && this == h;
        public override int GetHashCode() => HashCode.Combine(serviceType, tariff);
    }
}
