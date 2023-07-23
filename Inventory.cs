using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public static class Inventory
    {
        public static List<Product> products = new List<Product>();

        public static List<Product> Search(String value)
        {
            Product productToSearch = new Product() {name =  value};
            NameStrategy nameSearch = new NameStrategy();
            List<Product> foundProducts = new List<Product>();
            foreach(Product productInList in  products)
            {
                if(nameSearch.Exists(productInList, productToSearch))
                {
                   
                    foundProducts.Add(productInList);
                }
            }
            return foundProducts;
        }




    public static String Add(Product product)
        {
            const String success = "Product added successfully";
            const String failed = "Product already exists";
            
            if(Search(product.name).Count == 0)
            {
                products.Add(product);
                return success;
            }
            else
            {
                return failed;
            }
            
        }
    }
}
