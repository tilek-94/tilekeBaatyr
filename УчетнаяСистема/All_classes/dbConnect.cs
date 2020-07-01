using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;

namespace УчетнаяСистема.All_classes
{
    class dbConnect
    {


        public MySqlConnection connection = new MySqlConnection("datasource=192.168.0.108; port=3306;Initial Catalog='u_system';username=STROI2;password=123456;CharSet=utf8;");


        public delegate void DisplaySourse(DataTable db);
        public delegate void DisplaySourse2(string[] a);
        public event DisplaySourse eventDysplay;
        public event DisplaySourse2 eventDysplay2;
        public dbConnect() {
          }

        public void RemoveData(string table,string id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE "+table+" SET remov='1' WHERE id='"+id+"';";
            cmd.ExecuteNonQuery();
            connection.Close();
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
        public string[] ReadMassiv(string s)
        {
            string[] a = new string[20];
            int i = 0;
            connection.Open();
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                a[0] = reader[0].ToString();
                a[1] = reader[1].ToString();
                a[2] = reader[2].ToString();
                a[3] = reader[3].ToString();
                
            }
            connection.Close();
            return a;
        }

        public string DisplayReturn(string s)
        {
            connection.Open();
            string sql = s,value="";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                value = reader[0].ToString();
               
            }
            connection.Close();
            return value;
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
               f[0]= reader[0].ToString();
               f[1]= reader[1].ToString();
               f[2]= reader[2].ToString();
               /* if(reader!=null)
               f[3]= reader[3].ToString();*/

            }
            connection.Close();
            return f;

        }
        ImageSource src;
        public void For_Kompleks_Window(WrapPanel Panell, Button button,string text,string surot)
        {            
            Grid grid = new Grid();
            grid.Height = 250;
            grid.Width = 190;
            grid.Margin = new Thickness(60, 15, 0, 0);

            if (surot != String.Empty)
            {
                src = Base64StringToImageSource(surot);
                
            }
            
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = src;
            Border image = new Border();
            image.Margin = new Thickness(3,3,3,3);
            image.Height = 200;
            image.Width = 185;
            image.CornerRadius= new CornerRadius(13,13,13,13);
            image.Name = "image";
            if (surot!= String.Empty)
            {
                image.Background=ib;
            }

            Grid border = new Grid();
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.Height = double.NaN;
            border.Background = Brushes.White;

            TextBlock textblock = new TextBlock();
            Color color = (Color)ColorConverter.ConvertFromString("#0A6E9E");
            textblock.Foreground = new SolidColorBrush(color);
            textblock.FontSize = 18;
            textblock.HorizontalAlignment = HorizontalAlignment.Center;
            textblock.TextWrapping = TextWrapping.Wrap;
            textblock.Text = text;
            textblock.Name = "textblock";

            button.Content = image;
            border.Children.Add(textblock);
            grid.Children.Add(button);
            grid.Children.Add(border);
            Panell.Children.Add(grid);
        }
        public static System.Windows.Media.ImageSource Base64StringToImageSource(string base64String)
        {
            /*using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64String)))
            {
                System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                bi.EndInit();
                bi.Freeze();
                return bi;
            }*/
            return null;
        }
    }
}
