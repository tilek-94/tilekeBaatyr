using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using УчетнаяСистема.All_classes;
using System.Data;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для view_year.xaml
    /// </summary>
    public partial class view_year : Window
    {
          public view_year()
        {
            InitializeComponent();
            
       }

        dbConnect dbCon = new dbConnect();
        ChartRapyment chartRapyment = new ChartRapyment();
        public string ZakazId = "", ClientId="",NumberF="";
        public bool Flag = false;
        public double KGS = 0, USD = 0;
       public string d1 = "0", d2 = "0", m1 = "0", m2 = "0", y1 = "0", y2 = "0";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Flag==false)
            BasaQuery();
            else
            {
                BasaPred();
                GridLength grd = new GridLength(0, GridUnitType.Pixel);
                ContentV.Height = grd;
            }
        }

        private void BasaQuery()
        {

           
            dbCon.connection.Open();
            string sql = "SELECT * FROM grafplat WHERE id='" + ZakazId + "'";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[1].ToString();
                textBox2.Text = reader[3].ToString();
                textBox3.Text = reader[5].ToString();
                textBox4.Text = reader[7].ToString();
                textBox5.Text = reader[2].ToString();
                textBox6.Text = reader[4].ToString();
                textBox7.Text = reader[6].ToString();
                textBox8.Text = reader[8].ToString();

                d1 = reader[10].ToString();
                m1 = reader[11].ToString();
                y1 = reader[12].ToString();
                d2 = reader[13].ToString();
                m2 = reader[14].ToString();
                y2 = reader[15].ToString();

                USD = Convert.ToDouble(textBox4.Text) / Convert.ToDouble(reader[9].ToString());
                KGS = Convert.ToDouble(textBox8.Text) / Convert.ToDouble(reader[9].ToString());

            }
            dbCon.connection.Close();
            string SqlQry = "SELECT SUM(summa), SUM(usd),DATE_FORMAT(data_month, '%m-%Y') " +
                "FROM repayment WHERE client_id='" + ClientId + "' AND dom_id='" + staticClass.StaticDomID + "' AND number_f='" + NumberF + "' GROUP by DATE_FORMAT(data_month, '%yyyy %m')";
            chartRapyment.Display(SqlQry, Math.Round(KGS, 2), Math.Round(USD, 2), myDataGrid, d1, m1, y1, d2, m2, y2);

        }

        private void BasaPred()
        {

            // MessageBox.Show($"1{d1}, {m1}, {y1}, {d2}, {m2}, {y2}");
            dbCon.connection.Close();
            string SqlQry = "SELECT SUM(summa), SUM(usd),DATE_FORMAT(data_month, '%m-%Y') " +
                "FROM repayment WHERE client_id='" + ClientId + "' AND dom_id='" + staticClass.StaticDomID + "' AND number_f='" + NumberF + "' GROUP by DATE_FORMAT(data_month, '%yyyy %m')";
            chartRapyment.Display(SqlQry, Math.Round(KGS, 2), Math.Round(USD, 2), myDataGrid, d1, m1, y1, d2, m2, y2);


        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
