using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public interface IExistsStrategy
    {
        public bool Exists(Product p1 , Product p2);
    }
}
