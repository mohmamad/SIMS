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
            return $"{this.name} | {this.price} | {this.quantity}" ;
        }
        public String name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
