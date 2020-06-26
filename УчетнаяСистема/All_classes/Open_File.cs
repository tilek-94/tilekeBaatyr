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
        private string BASE64;
        public void Open_Image(Image img)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select a picture";
            open.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (open.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(open.FileName));
            }
            if (open.FileName != String.Empty)
            {
                BASE64 = Convert.ToBase64String(File.ReadAllBytes(open.FileName));
            }
        }
        public string Base64()
        {
            return BASE64.ToString();
        }
    }
}
