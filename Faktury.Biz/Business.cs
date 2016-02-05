using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Biz
{
    public class Business
    {
        /// <summary>
        /// Creating new product and adding it to List
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="name">Product name</param>
        /// <param name="vat">VAT</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="nettoprice">Netto price</param>
        /// <param name="products">List of products</param>
        public void AddProduct(int productId, string name, decimal vat, decimal quantity, decimal nettoprice, List<Product> products)
        {
            products.Add(new Product(productId, name, vat, quantity, nettoprice));
        }
    }
}
