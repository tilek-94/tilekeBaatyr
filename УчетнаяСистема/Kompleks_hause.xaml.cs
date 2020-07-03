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

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Kompleks_hause : Window
    {
        Open_File open = new Open_File();
        dbConnect dbCon = new dbConnect();
        public Kompleks_hause()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbCon.connection.Open();
            using (MySqlCommand cmd = new MySqlCommand("select id,name from dom", dbCon.connection))
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
                            //byte[] array = (byte[])reader["img"];
                            dbCon.For_Kompleks_Window(Panell, button, reader["name"].ToString());
                        }
                    }

                }

            }
            dbCon.connection.Close();
            dbCon.connection.Dispose();


        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.IsEnabled = true;
            this.Hide();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}