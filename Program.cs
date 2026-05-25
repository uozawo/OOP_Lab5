using System.Text;

namespace Lab4_v3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Ћабораторна робота є5, в1ар≥ант 9 ===\n");

            // пункт 2: три конструктори
            Console.WriteLine(">>> ѕункт 2. три конструктори <<<");

            // конструктор без параметр≥в
            Toy t_default = new Toy();
            Console.WriteLine("\n[конструктор без параметр≥в]");
            t_default.DisplayInfo();

            // конструктор з параметрами
            Toy t_param = new Toy("LEGO Star Wars", 1500m, "середн≥й", 1.2, "висока",
                                  "8+", "пластик", 120, 85);
            Console.WriteLine("\n[конструктор з параметрами]");
            t_param.DisplayInfo();

            // конструктор коп≥юванн€
            Toy t_copy = new Toy(t_param);
            Console.WriteLine("\n[конструктор коп≥юванн€]");
            t_copy.DisplayInfo();

            // пункт 1: новий клас житлово-комунальн≥ послуги
            Console.WriteLine("\n\n>>> пункт 1. новий клас житлово_комунальн≥_послуги <<<");

            Food food1 = new Food("молоко", 45.5m, "1 л≥тр", 1.0, "висока",
                                  "молочн≥", "корисний", "в≥д +2 до +6", 5, 60);
            Toy toy1 = t_param;
            Housing_Communal_Services hcs1 = new Housing_Communal_Services(
                " ињвенерго", 5.50m, "квартира", 0, "стандарт",
                "електроенерг≥€", "ƒ“≈ ", 4.32m, "к¬тЈгод", 250.0, "щом≥с€чно");

            hcs1.DisplayInfo();

            // пункт 3: користь ≥ попул€рн≥сть через в≥ртуальн≥ методи
            Console.WriteLine("\n\n>>> пункт 3. користь ≥ попул€рн≥сть <<<");
            Product[] products = { food1, toy1, hcs1 };
            foreach (Product p in products)
            {
                Console.WriteLine($"\n[{p.GetType().Name}: {p.Brand}]");
                Console.WriteLine($"  користь: {p.Benefit()}");
                Console.WriteLine($"  попул€рн≥сть: {p.Popularity()}/100");
            }

            // пункт 4: варт≥сть споживчого кошика
            Console.WriteLine("\n\n>>> пункт 4. варт≥сть споживчого кошика <<<");

            // м≥н≥мальн≥ норми дл€ працездатноњ людини
            Console.WriteLine("\n[кошик працездатноњ людини]");
            decimal foodCost_adult = food1.BasketCost(80);
            decimal toyCost_adult = toy1.BasketCost(1);
            decimal hcsCost_adult = hcs1.BasketCost(12);
            decimal totalAdult = foodCost_adult + toyCost_adult + hcsCost_adult;
            Console.WriteLine($"  молоко 80 кг/р≥к: {foodCost_adult:F2} грн");
            Console.WriteLine($"  ≥грашки 1 шт/р≥к: {toyCost_adult:F2} грн");
            Console.WriteLine($"  електроенерг≥€ 12 м≥с: {hcsCost_adult:F2} грн");
            Console.WriteLine($"  разом: {totalAdult:F2} грн");

            // м≥н≥мальн≥ норми дл€ дитини
            Console.WriteLine("\n[кошик дитини]");
            decimal foodCost_child = food1.BasketCost(110);
            decimal toyCost_child = toy1.BasketCost(4);
            decimal hcsCost_child = hcs1.BasketCost(12);
            decimal totalChild = foodCost_child + toyCost_child + hcsCost_child;
            Console.WriteLine($"  молоко 110 кг/р≥к: {foodCost_child:F2} грн");
            Console.WriteLine($"  ≥грашки 4 шт/р≥к: {toyCost_child:F2} грн");
            Console.WriteLine($"  електроенерг≥€ 12 м≥с: {hcsCost_child:F2} грн");
            Console.WriteLine($"  разом: {totalChild:F2} грн");

            // пункт 5: б≥нарн≥ оператори
            Console.WriteLine("\n\n>>> пункт 5. б≥нарн≥ оператори <<<");

            Food food2 = new Food("хл≥б", 20m, "буханець", 0.5, "висока",
                                  "вип≥чка", "звичайний", "сухе м≥сце", 3, 250);

            Console.WriteLine($"\n  food1: {food1.Brand}, {food1.Price} грн, {food1.Weight} кг, {food1.Calories} ккал");
            Console.WriteLine($"  food2: {food2.Brand}, {food2.Price} грн, {food2.Weight} кг, {food2.Calories} ккал");

            Food foodSum = food1 + food2;
            Console.WriteLine($"\n  food1 + food2 = {foodSum.Price} грн, {foodSum.Weight} кг, {foodSum.Calories} ккал");

            Food foodDiff = food1 - food2;
            Console.WriteLine($"  food1 - food2 = {foodDiff.Price} грн, {foodDiff.Weight} кг, {foodDiff.Calories} ккал");

            Console.WriteLine($"\n  food1 == food2: {food1 == food2}");
            Console.WriteLine($"  food1 != food2: {food1 != food2}");
            Console.WriteLine($"  food1 >  food2: {food1 > food2}");
            Console.WriteLine($"  food1 <  food2: {food1 < food2}");

            Console.WriteLine($"\n  кошик дитини > кошик дорослого: {totalChild > totalAdult}");

            // пункт 6: унарн≥ оператори
            Console.WriteLine("\n\n>>> пункт 6. унарн≥ оператори <<<");
            Console.WriteLine($"\n  toy1.EducationalValue до: {toy1.EducationalValue}");
            toy1++;
            toy1++;
            toy1++;
            Console.WriteLine($"  п≥сл€ трьох ++: {toy1.EducationalValue}");
            toy1--;
            Console.WriteLine($"  п≥сл€ --: {toy1.EducationalValue}");

            Console.WriteLine($"\n  hcs1.MonthlyConsumption до: {hcs1.MonthlyConsumption}");
            hcs1++;
            Console.WriteLine($"  п≥сл€ ++: {hcs1.MonthlyConsumption}");

            // пункт 7: ≥ндексатор
            Console.WriteLine("\n\n>>> пункт 7. ≥ндексатор (масив ≥грашок) <<<");

            ToyArray toyArr = new ToyArray(3);
            toyArr[0] = new Toy("м'€чик", 45m, "малий", 0.3, "середн€", "3+", "гума", 240, 40);
            toyArr[1] = new Toy("конструктор", 850m, "середн≥й", 0.8, "висока", "6+", "пластик", 60, 80);
            toyArr[2] = new Toy("л€лька", 600m, "середн≥й", 0.4, "висока", "3+", "пластик/тканина", 120, 50);

            Console.WriteLine($"\n  к≥льк≥сть елемент≥в: {toyArr.Length}");
            Console.WriteLine("\n  доступ до елемента [1] через ≥ндексатор:");
            toyArr[1].DisplayInfo();

            toyArr.DisplayAll();

            // з≥ староњ верс≥њ: IComparable, IComparer, IEnumerable
            Console.WriteLine("\n\n>>> з≥ старого v3: IComparable, IComparer, IEnumerable <<<");

            Product[] all = new Product[]
            {
                new Toy("LEGO", 1500m, "середн≥й", 1.2, "висока", "8+", "пластик", 120, 85),
                new Food("молоко", 45.5m, "1 л≥тр", 1.0, "висока", "молочн≥", "корисний", "в≥д +2 до +6", 5, 60),
                new Toy("м'€чик", 45.5m, "малий", 0.3, "середн€", "3+", "гума", 240, 40),
                new Food("хл≥б", 20m, "буханець", 0.5, "висока", "вип≥чка", "звичайний", "сухе м≥сце", 3, 250),
                new Housing_Communal_Services(" ињвенерго", 5.5m, "квартира", 0, "стандарт",
                    "електроенерг≥€", "ƒ“≈ ", 4.32m, "к¬тЈгод", 250.0, "щом≥с€чно")
            };

            Console.WriteLine("\n[1] IComparable, сортуванн€ за ц≥ною:");
            Array.Sort(all);
            foreach (Product p in all) p.DisplayInfo();

            Console.WriteLine("\n[2] IComparer, сортуванн€ за ц≥ною ≥ вагою:");
            Array.Sort(all, new ProductPriceSizeComparer());
            foreach (Product p in all) p.DisplayInfo();

            Console.WriteLine("\n[3] IEnumerable, переб≥р через ProductCollection:");
            ProductCollection collection = new ProductCollection(all);
            foreach (Product p in collection) p.DisplayInfo();

            Console.WriteLine("\n\n=== к≥нець програми ===");
            Console.ReadKey();
        }
    }
}
