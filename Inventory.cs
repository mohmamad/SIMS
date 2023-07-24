using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    /// <summary>
    /// Inventory class to save a list of products, and implement the methods applied on that list.
    /// </summary>
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
                if(nameSearch.Equals(productInList, productToSearch))
                {
                   
                    foundProducts.Add(productInList);
                }
            }

            return foundProducts;
        }




    public static String Add(Product product)
        {
            const String success = "Product added successfully";
            const String failed = "add failed: Product may already exist";
            
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

    public static String ViewAll()
        {
            String failed = "Products list is empty.";
            if(products.Count != 0)
            {
                const String Header = "Name | Price | Quantity";

                Console.WriteLine(Header);
                Console.WriteLine("________________________________________________________________________");
                foreach (Product product in products)
                {
                    Console.WriteLine(product.ToString());
                    Console.WriteLine("________________________________________________________________________");
                }
                return String.Empty;
            }
            else
            {
                return failed;
            }
            
           
        }

    public static String Edit(Product product)
        {
            const String success = "Edit was successful";
            const String failed = "Edit failed: product may not exist";
            if(Search(product.name).Count != 0)
            {
                Search(product.name)[0].price = product.price;
                Search(product.name)[0].quantity = product.quantity;
                return success;
            }
            else
            {
                return failed;
            }
           
           
        }

    public static String Delete(String name)
        {
            const String success = "Product deleted successfully";
            const String failed = "delete failed: product may not exist";
            if (Search(name).Count != 0)
            {
                products.Remove(Search(name)[0]);
                return success;
            }
            else
            {
                return failed;
            }
        }
        


    }
}
