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
using УчетнаяСистема.form_p;
using System.Data;
using УчетнаяСистема.All_classes;
using Microsoft.Win32;
using System.IO;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Peple_pag.xaml
    /// </summary>
    public partial class Peple_pag : Page
    {
        public Peple_pag()
        {
            InitializeComponent();
        }

        dbConnect dbCon = new dbConnect();

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }
        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM client");
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 search_Cars2 = new Window1();
            search_Cars2.Height = 330;
            search_Cars2.ShowDialog();
        }
    }
}
