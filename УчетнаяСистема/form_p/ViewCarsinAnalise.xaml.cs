using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for ViewCarsinAnalise.xaml
    /// </summary>
    public partial class ViewCarsinAnalise : Window
    {
        public ViewCarsinAnalise()
        {
            InitializeComponent();
        }

        string[] LangName = new string[3];
        lang lanG = new lang();
        dbConnect dbCon = new dbConnect();
        RaschetSum raschetSum = new RaschetSum();
        string  KgsCars = "0", IdCarsCurs="0", UsdCars = "0";
        public string SqlQury = "0";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {/*

            dbCon.connection.Open();
            string sql = "SELECT * FROM carsid WHERE id='"+ CarsId + "'";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                text1.Text = reader[1].ToString();
                text2.Text = reader[2].ToString();
                text3.Text = reader[3].ToString();
                text4.Text = reader[4].ToString();
                KgsCars = reader[7].ToString();
                UsdCars = reader[8].ToString();
                text7.Text = reader[5].ToString();
                text8.Text = reader[6].ToString();
                IdCarsCurs = reader[9].ToString();

            }
            dbCon.connection.Close();
*/
            RegistData(SqlQury);
        }

        private void RegistData(string s)
        {

            LangName = lanG.ReturnName(ComboBox3.Text);
            l1.Content = LangName[1];
            l2.Content = LangName[2];
            dbCon.eventDysplay += delegate (DataTable db)
            {
                text1.Text = db.Rows[0][2].ToString();
                text2.Text = db.Rows[0][3].ToString();
                text3.Text = db.Rows[0][4].ToString();
                text4.Text = db.Rows[0][5].ToString();

                text1.Text = db.Rows[0][1].ToString();
                text2.Text = db.Rows[0][2].ToString();
                text3.Text = db.Rows[0][3].ToString();
                text4.Text = db.Rows[0][4].ToString();
                KgsCars = db.Rows[0][7].ToString();
                UsdCars = db.Rows[0][8].ToString();
                text7.Text = db.Rows[0][5].ToString();
                text8.Text = db.Rows[0][6].ToString();
                IdCarsCurs = db.Rows[0][9].ToString();
            };
            dbCon.SoursData(s);

            text5.Text = KgsCars;
            text6.Text = UsdCars;

        }


        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {


            if (KgsCars != "0")
                text5.Text = raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
            if (UsdCars != "0")
                text6.Text = raschetSum.ReaderBasa2(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString();

        }
    }
}
