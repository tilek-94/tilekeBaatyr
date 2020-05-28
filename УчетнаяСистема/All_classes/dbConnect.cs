using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Principal;

namespace УчетнаяСистема.All_classes
{
    class dbConnect
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306;Initial Catalog='u_system';username=STROI;password=123456;CharSet=utf8;");
        public delegate void DisplaySourse(DataTable db);
        public delegate void DisplaySourse2(string[] a);
        public event DisplaySourse eventDysplay;
        public event DisplaySourse2 eventDysplay2;
        public dbConnect() {
          }

        public void SoursData(string s)
        {
           // string s = "select * from kvartira";
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            DataTable dta1 = new DataTable();
            MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
            dataadap.Fill(dta1);
            eventDysplay(dta1);
            connection.Close();
        }
        public void Registr(string s)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void Display(string s)
        {
            string[] a= new string[10000];
            int i = 0;
            connection.Open();
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               a[i]= reader[0].ToString();
                i++;
            }
            connection.Close();
            eventDysplay2(a);
        }
        public string[] RedInfor(string s)
        {
            connection.Open();
            string[] f=new string[5];
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               f[1]= reader[0].ToString();
               f[2]= reader[1].ToString();
               f[3]= reader[2].ToString();

            }
            connection.Close();
            return f;

        }
    }
}
