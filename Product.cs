using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
  

    public class Product
    {
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
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
