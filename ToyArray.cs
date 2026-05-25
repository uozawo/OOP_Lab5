using System;

namespace Lab4_v3
{
    // масив іграшок з індексатором
    class ToyArray
    {
        private Toy[] toys;

        public int Length => toys.Length;

        public ToyArray(int size)
        {
            toys = new Toy[size];
            for (int i = 0; i < size; i++)
                toys[i] = new Toy();
        }

        // індексатор для доступу за номером
        public Toy this[int index]
        {
            get
            {
                if (index < 0 || index >= toys.Length)
                    throw new IndexOutOfRangeException("неправильний індекс");
                return toys[index];
            }
            set
            {
                if (index < 0 || index >= toys.Length)
                    throw new IndexOutOfRangeException("неправильний індекс");
                toys[index] = value;
            }
        }

        // вивід усіх елементів масиву
        public void DisplayAll()
        {
            Console.WriteLine($"\n=== масив іграшок, {toys.Length} штук ===");
            for (int i = 0; i < toys.Length; i++)
            {
                Console.WriteLine($"\nелемент [{i}]");
                this[i].DisplayInfo();
            }
        }
    }
}
