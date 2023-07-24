using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleInventoryManagementSystem
{

    /// <summary>
    /// Product class to make a product, and convert it to the wanted string format,
    /// By overriding ToString method.
    /// </summary>
    public class Product
    {
        //Converts product object to "name | price | quantity" string format.
        public override string ToString()
        {
            char[] name = this.name.ToArray();
            char capital = name[0];
            capital = char.ToUpper(capital);
            name[0] = capital;
            String capitalizedName = new string(name); 

             
            return $"{capitalizedName} | {this.price} | {this.quantity}" ;
        }
        public String name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
