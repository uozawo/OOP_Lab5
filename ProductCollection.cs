using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4_v3
{
    class ProductCollection : IEnumerable<Product>
    {
        private Product[] products;

        public ProductCollection(Product[] products)
        {
            this.products = products;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            Product[] sorted = new Product[products.Length];
            Array.Copy(products, sorted, products.Length);

            Array.Sort(sorted);

            for (int i = 0; i < sorted.Length; i++)
                yield return sorted[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
