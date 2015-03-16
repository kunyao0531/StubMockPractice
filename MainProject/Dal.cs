using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Dal
    {
        public int GetSomethingbyName(string Name)
        {
            if (Name == "Frank")
            {
                return 27;
            }
            else if (Name == "Tom")
            {
                return 88;
            }
            else if (Name == "Kevin")
            {
                return 15;
            }
            else
            {
                return 99;
            }
        }
    }
}
