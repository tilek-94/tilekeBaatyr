using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетнаяСистема.All_classes
{
    class lang
    {
        string[] name = new string[3];
        public string[] ReturnName(string s)
        {
            if (s== "USD-KGS") {
                name[1] = "(USD)";
                name[2] = "(KGS)";
            }else if (s== "KGS-USD") {
                name[1] = "(KGS)";
                name[2] = "(USD)";
            }
            else
            if (s== "RUB-KGS") {
                name[1] = "(RUB)";
                name[2] = "(KGS)";
            }else
            if (s== "KGS-RUB") {
                name[1] = "(KGS)";
                name[2] = "(RUB)";
            }
            if (s== "EUR-KGS") {
                name[1] = "(EUR)";
                name[2] = "(KGS)";
            }
            if (s== "KGS-EUR") {
                name[1] = "(KGS)";
                name[2] = "(EUR)";
            }
            return name;
        }
    }
}
