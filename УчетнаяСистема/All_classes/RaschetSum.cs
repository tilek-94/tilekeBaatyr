using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.All_classes
{
    class RaschetSum
    {
        dbConnect dbCon = new dbConnect();
       
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
        public double ReaderBasa(string valuta, double summa, string Id)
        {
            MySqlConnection connection = dbCon.connection;
            connection.Open();
            string[] f = new string[5];
            string sql = "SELECT * FROM currency WHERE id='"+Id+"'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                f[1] = reader[1].ToString();
                f[2] = reader[2].ToString();
                f[3] = reader[3].ToString();

            }
            connection.Close();
            return CarsRaschet(valuta, summa, Convert.ToDouble( f[1]), Convert.ToDouble(f[2]), Convert.ToDouble(f[3]));

        }


        public double CarsRaschet(string a, double KGS, double USD, double EUR, double RUB)
        {
            double ob = 0;
            if (a == "KGS-USD")
            {
                ob = KGS;

            }
            else if (a == "KGS-EUR")
            {
                ob = KGS;

            }
            else if (a == "KGS-RUB")
            {
                ob = KGS;

            }
            else if (a == "USD-KGS")
            {
                ob = KGS / USD;

            }
            else if (a == "EUR-KGS")
            {
                ob = KGS / EUR;

            }
            else if (a == "RUB-KGS")
            {
                ob = KGS / RUB;

            }
            return Math.Round(ob, 2);
        }



        public double ReaderBasa2(string valuta, double summa, string Id)
        {
            MySqlConnection connection = dbCon.connection;
            connection.Open();
            string[] f = new string[5];
            string sql = "SELECT * FROM currency WHERE id='" + Id + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                f[1] = reader[1].ToString();
                f[2] = reader[2].ToString();
                f[3] = reader[3].ToString();

            }
            connection.Close();
            return CarsRaschet2(valuta, summa, Convert.ToDouble(f[1]), Convert.ToDouble(f[2]), Convert.ToDouble(f[3]));

        }


        public double CarsRaschet2(string a, double KGS, double USD, double EUR, double RUB)
        {
            double ob = 0;
            if (a == "KGS-USD")
            {
                ob = KGS;

            }
            else if (a == "KGS-EUR")
            {
                ob = (KGS*USD)/EUR;

            }
            else if (a == "KGS-RUB")
            {
                ob = (KGS * USD)/RUB;

            }
            else if (a == "USD-KGS")
            {
                ob = KGS*USD;

            }
            else if (a == "EUR-KGS")
            {
                ob = (KGS * USD);

            }
            else if (a == "RUB-KGS")
            {
                ob = (KGS * USD);

            }
            return Math.Round(ob, 2);
        }

    }
}
