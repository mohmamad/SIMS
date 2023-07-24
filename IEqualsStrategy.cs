using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    /// <summary>
    /// IEqualsStrategy Interface intializes methods that compare two products based on a choosen factor.
    /// </summary>
    public interface IEqualsStrategy
    {
        public bool Equals(Product p1 , Product p2);
    }
}
