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
            //return value only used for testing
            String allProducts = String.Empty;  
            const String Header = "Name | Price | Quantity";
            allProducts = $"{Header}\n________________________________________________________________________\n";
            Console.WriteLine(Header);
            Console.WriteLine("________________________________________________________________________");
            foreach (Product product in products) 
            {
                allProducts += $"{product.ToString()}\n________________________________________________________________________\n";
                Console.WriteLine(product.ToString());
                Console.WriteLine("________________________________________________________________________");
            }
            return allProducts;
        }

    public static void Edit(Product product)
        {
            const String success = "Edit was successful";
            const String failed = "Edit failed: product may not exist";
            if(Search(product.name).Count != 0)
            {
                Search(product.name)[0].price = product.price;
                Search(product.name)[0].quantity = product.quantity;
                Console.WriteLine(success);
            }
            else
            {
                Console.WriteLine(failed);
            }
           
           
        }

    public static void Delete(String name)
        {
            const String success = "Product deleted successfully";
            const String failed = "delete failed: product may not exist";
            if (Search(name).Count != 0)
            {
                products.Remove(Search(name)[0]);
                Console.WriteLine(success);
            }
            else
            {
                Console.WriteLine(failed);
            }
        }
        


    }
}
