using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class NameStrategy : IExistsStrategy
    {
        public bool Exists(Product p1 , Product p2)
        {
            return p1.name == p2.name;
        }
    }
}
