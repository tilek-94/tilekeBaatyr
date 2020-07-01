using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using УчетнаяСистема.All_classes;

namespace Роли
{
    class log_pass
    {
        public string DisplayReturn(string s)
        {
            dbConnect dbCon = new dbConnect();
            MySqlConnection connection = dbCon.connection;
            connection.Open();
            string sql = s, value = "";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                value = reader[0].ToString();

            }
            connection.Close();
            return value;
        }
        public string Log_Pass(string s1, string s2)
        {
            string s = DisplayReturn("SELECT rol_id FROM Us_Ro INNER JOIN Users INNER JOIN Rols on login = user_id WHERE login = '" + s1 + "' and pass = '" + s2 + "'");

            return s;
        }
    }
}
