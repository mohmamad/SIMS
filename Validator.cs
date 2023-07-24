using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    /// <summary>
    /// Validator class has two methods validate and excute.
    /// </summary>
    /// <remarks>
    /// The Validate method makes sure that the given command is correct.
    /// The excute method excutes calls the correct method from Inventory gives feedback to the user.
    /// </remarks>
    public static class Validator
    {
        public static Boolean validate(String command)
        {
            if (command == null) return false;
    
            switch(command.Split(" ")[0])
            {
                case "add":
                    // to check the correctness of the price quantity inputs.
                    try
                    {
                        int.Parse(command.Split(" ")[3]);
                        double.Parse(command.Split(" ")[2]);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    // to catch if the command given have more attributes than its supposed.
                    if (command.Split(" ").Length > 4) return false;
                   
                    break;
                case "edit":
                   
                    try
                    {
                        int.Parse(command.Split(" ")[4]);
                        double.Parse(command.Split(" ")[3]);
                    }
                    catch (Exception e)
                    {
                        
                        return false;
                    }
                    if (command.Split(" ").Length > 5) return false;
                  
                    break;
                case "search":  if (command.Split(" ").Length > 2) return false; break;

                case "view": if (command.Split(" ").Length > 1) return false; break;

                case "delete": if (command.Split(" ").Length > 2) return false; break;

                case "exit": if (command.Split(" ").Length > 1) return false; break;

                default: return false;

            }
            return true;
           
        }

        public static void ExcuteCommand(string command)
        {
            
            Product product = new Product();
           
            switch(command.Split(" ")[0])
            {
                case "add":
                    product.name = command.Split(" ")[1].ToLower();
                    product.price = double.Parse(command.Split(" ")[2]);
                    product.quantity = int.Parse(command.Split(" ")[3]);
                    Console.WriteLine(Inventory.Add(product));
                    break;
                case "view":  Console.WriteLine(Inventory.ViewAll()); break;


                case "edit": 
                    Console.WriteLine(Inventory.Edit(command.Split(" ")[1] , command.Split(" ")[2] , double.Parse(command.Split(" ")[3]) , int.Parse(command.Split(" ")[4]))); 
                    break;

                case "delete": Console.WriteLine(Inventory.Delete(command.Split(" ")[1].ToLower())); break;

                case "search":
                    
                    if(Inventory.Search(command.Split(" ")[1].ToLower()).Count != 0)
                    {
                        //print the found products
                        const String Header = "Name | Price | Quantity";
                        Console.WriteLine(Header);
                        Console.WriteLine("________________________________________________________________________");
                        foreach (Product foundProduct in Inventory.Search(command.Split(" ")[1].ToLower()))
                        {
                            Console.WriteLine(foundProduct.ToString());
                            Console.WriteLine("________________________________________________________________________");
                        }
                    }
                    else Console.WriteLine("Product Not Found: product may not exist. \n Make sure you wrote the correct name.");
                    break;

            }
 
        }
    }
}
