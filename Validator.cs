using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public static class Validator
    {
        public static Boolean validate(String command)
        {

           // HashSet<String> commands = new HashSet<string>() { "add", "edit", "search", "view", "delete", "exist" };
            if (command == null)
            {
                return false;
            }
           
            switch(command.Split(" ")[0])
            {
                case "add":
                    try
                    {
                        int.Parse(command.Split(" ")[3]);
                        int.Parse(command.Split(" ")[2]);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    // to catch if the command given have more attributes than it supposed
                    if (command.Split(" ").Length > 4)
                    {
                        return false;
                    }
                    break;
                case "edit":
                    try
                    {
                        int.Parse(command.Split(" ")[3]);
                        int.Parse(command.Split(" ")[2]);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    if (command.Split(" ").Length > 4)
                    {
                        return false;
                    }
                    if (command.Split(" ").Length > 4)
                    {
                        return false;
                    }
                    break;
                case "search":
                    if (command.Split(" ").Length > 2)
                    {
                        return false;
                    }
                    break;
                case "view":
                    if (command.Split(" ").Length > 1)
                    {
                        return false;
                    }
                    break;
                case "delete":
                    if (command.Split(" ").Length > 2)
                    {
                        return false;
                    }
                    break;
                case "exit":
                    if (command.Split(" ").Length > 1)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
                    
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
                    product.price = int.Parse(command.Split(" ")[2]);
                    product.quantity = int.Parse(command.Split(" ")[3]);
                    Console.WriteLine(Inventory.Add(product));
                    break;
                case "view":
                    Inventory.ViewAll();
                    break;
                case "edit":
                    product.name = command.Split(" ")[1].ToLower();
                    product.price = int.Parse(command.Split(" ")[2]);
                    product.quantity = int.Parse(command.Split(" ")[3]);
                    Inventory.Edit(product);
                    break;
                case "delete":
                    Inventory.Delete(command.Split(" ")[1].ToLower());
                    break;
            }
 
        }
    }
}
