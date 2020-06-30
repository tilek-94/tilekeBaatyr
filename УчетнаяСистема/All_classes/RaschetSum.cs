using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетнаяСистема.All_classes
{
    class RaschetSum
    {
        public double Kurs(string a, double KGS, double USD, double EUR, double RUB)
        {
            double ob = 0;
            if (a == "KGS-USD")
            {
                ob = KGS / USD;

            }
            else if (a == "KGS-EUR")
            {
                ob = KGS / EUR;

            }
            else if (a == "KGS-RUB")
            {
                ob = KGS / RUB;

            }
            else if (a == "USD-KGS")
            {
                ob = KGS * USD;

            }
            else if (a == "EUR-KGS")
            {
                ob = KGS * EUR;

            }
            else if (a == "RUB-KGS")
            {
                ob = KGS * RUB;

            }
            return  Math.Round(ob, 2);
        }

    }
}
