using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    /// <summary>
    /// NameStrategy class extendes IEqualsStrategy interface to implement equals method,
    /// Which compares based on name.
    /// </summary>
    public class NameStrategy : IEqualsStrategy
    {
        public bool Equals(Product p1 , Product p2)
        {
            return p1.name == p2.name;
        }
    }
}
