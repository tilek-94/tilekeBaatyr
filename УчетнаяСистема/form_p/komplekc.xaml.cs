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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;


namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для komplekc.xaml
    /// </summary>
    public partial class komplekc : Page

    {
        dbConnect dbCon = new dbConnect();
        public komplekc()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
/*
            dbCon.connection.Open();
            using (MySqlCommand cmd = new MySqlCommand("select id,name,img from dom", dbCon.connection))
            {
                
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Button button = new Button();
                            button.VerticalAlignment = VerticalAlignment.Top;
                            button.Style = (Style)this.TryFindResource("menuCom");
                            button.Name = "Dom" + reader["id"].ToString();
                            button.Click += new RoutedEventHandler(Button_Click);
                            dbCon.For_Kompleks_Window(Panell, button, reader["name"].ToString(), reader["img"].ToString());

                        }
                    }

                }

            }
            dbCon.connection.Close();
            dbCon.connection.Dispose();
*/

        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            MessageBox.Show(b.Name.ToString());
        }

    }
}
