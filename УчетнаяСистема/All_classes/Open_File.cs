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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace УчетнаяСистема.All_classes
{

    public class Open_File
    {
       OpenFileDialog open = new OpenFileDialog();
       
      public  byte[] image_byte = null;
        public void OpenImg(Image image1)//кнопка для ввода картинки в базу
        {
            BitmapImage image = null;
            image_byte = null;
            open.Filter = "All filles (*.*)|*.*;";
            if (open.ShowDialog() != false)//для ввода картинки в базу
            {

                string img_location = open.FileName.ToString();
                image1.Source = new BitmapImage(new Uri(img_location));
                FileInfo fi = new FileInfo(img_location);
                if (fi.Length > 999999)//после мегабайта
                {
                   
                    image = new BitmapImage(new Uri(img_location));
                    var image_reduce = new TransformedBitmap(image, new ScaleTransform(0.5, 0.5));
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image_reduce));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        image_byte = ms.ToArray();
                    }
                }
                else //До мегабайта
                {
                    FileStream stream = new FileStream(img_location, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    image_byte = brs.ReadBytes((int)stream.Length);
                }

             }
           
        
        }

     
        dbConnect dbCon = new dbConnect();
       
        public void Registr(string Sql)
        {
            if (image_byte != null) {


                MySqlConnection connection = dbCon.connection;
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Sql;
                cmd.Parameters.Add(new MySqlParameter("@bb", image_byte));
                cmd.ExecuteNonQuery();
                connection.Close();
                image_byte = null;
            }
            else
            {
                MySqlConnection connection = dbCon.connection;
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
                connection.Close();
                
            }

        }

        public byte[] DisplayReturn(string s)
        {
            MySqlConnection connection = dbCon.connection;
            connection.Open();
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");//для точной выборки из базы данных,"pict" имя столбца таблицы
            byte[] array = (byte[])ds.Tables[0].Rows[0]["img"];
            connection.Close();
            return array;
        }

    }
}
