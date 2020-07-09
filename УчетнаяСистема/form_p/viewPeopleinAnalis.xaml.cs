using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for viewPeopleinAnalis.xaml
    /// </summary>
    public partial class viewPeopleinAnalis : Window
    {
        public viewPeopleinAnalis()
        {
            InitializeComponent();
        }
        public string ClientID { get; set; }
        dbConnect dbCon = new dbConnect();
        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {       
            dbCon.connection.Open();
            string sql = "SELECT * FROM client WHERE id='"+ClientID+"' ";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                text1.Text = reader[1].ToString();
                text2.Text = reader[2].ToString();
                text3.Text = reader[3].ToString();
                text4.Text = reader[8].ToString();
                text5.Text = reader[4].ToString();
                text6.Text = reader[5].ToString();
                text7.Text = reader[6].ToString();
                text8.Text = reader[7].ToString();
            }
            dbCon.connection.Close();
         }
    }
}
