using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceCartSystem
{
    public class Cart
    {
        private List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public decimal GetTotalAmount()
        {
            return products.Sum(p => p.Price);
        }
    }
}
