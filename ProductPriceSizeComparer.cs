using System;
using System.Collections.Generic;

namespace Lab4_v3
{
    class ProductPriceSizeComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if (x == null || y == null) return 0;

            int priceCompare = x.Price.CompareTo(y.Price);
            if (priceCompare != 0)
                return priceCompare;

            return x.Weight.CompareTo(y.Weight);
        }
    }
}
