using System;
using System.Collections.Generic;
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
            HashSet<String> commands = new HashSet<string>() { "add", "edit", "search", "view all", "delete", "exist" };
            try{
                int.Parse(command.Split(" ")[3]);
                int.Parse(command.Split(" ")[2]);
            }
            catch(Exception e){
                return false;
            }
            if (command == null)
            {
                return false;
            }
            else if (!commands.Contains(command.Split(" ")[0]))
            {
                return false;
            }
            else { return true; }
           
        }

        public static void ExcuteCommand(string command)
        {

            Product product = new Product();
            if (command.Split(" ")[0] == "add")
            {
                product.name = command.Split(" ")[1];
                product.price = int.Parse(command.Split(" ")[2]);
                product.quantity = int.Parse(command.Split(" ")[3]);
               
            }
            Console.WriteLine(Inventory.Add(product));
        }
    }
}
