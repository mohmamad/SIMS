using SimpleInventoryManagementSystem;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


/// <summary>
/// App class to interact with the user, take the user input and give him feedbacks.
/// </summary>
internal class App
{
   
    
    private static void Main(string[] args)
    {
        const String commandFormat = "Here are the commands you can use: \n"
            + "* add <product name> <price> <quantity>: to add new product. \n" +
            "* edit <name> <new name> <new price> <new quantity>: to edit an existing product. \n" +
            "* search <product name>: to search about a product. \n" +
            "* view: to view all products. \n" +
            "* delete <procudt name>: to delete a product./n" +
            "exit: to exit the programe.";
        String? command = String.Empty;
        Console.WriteLine("Welcome to Simple Inventory Management System! \n \n" + commandFormat);
        while (command != "exit") 
        {
            command = Console.ReadLine();
            if (!Validator.validate(command)) Console.WriteLine("Please write the correct command format. \n" + commandFormat);
           
            else Validator.ExcuteCommand(command);
          
        }
    }

   
}