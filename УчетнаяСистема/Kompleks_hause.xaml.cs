using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.ViewModel;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Kompleks_hause : UserControl
    {
        dbConnect dbCon = new dbConnect();
        string[] BuildName=new string[500]; 
        public Kompleks_hause()
        {
            InitializeComponent();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Panell.Children.Clear();
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
                            dbCon.For_Kompleks_Window(Panell, button, reader["name"].ToString());
                            BuildName[Convert.ToInt16(reader["id"].ToString())] = reader["name"].ToString();
                        }
                    }

                }

            }
            dbCon.connection.Close();
            dbCon.connection.Dispose();


        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            staticClass.StaticDomID = button.Name.ToString().Substring(3);
           FrameworkElement fe = sender as FrameworkElement;
            button.Command = ((MainViewModel)fe.DataContext).bMenuAnalis;
            staticClass.BuildName=BuildName[Convert.ToInt16( staticClass.StaticDomID)];
        }

    }
}