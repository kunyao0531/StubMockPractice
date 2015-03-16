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
                //Select 資料庫
                return 27;
            }
            else if (Name == "Tom")
            {
                //Select 資料庫
                return 88;
            }
            else if (Name == "Kevin")
            {
                //Select 資料庫
                return 15;
            }
            else
            {
                //Select 資料庫
                return 99;
            }
        }
    }
}
