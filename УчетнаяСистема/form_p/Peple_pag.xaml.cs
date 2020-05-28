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
        private void registr_client_btn_Click(object sender, RoutedEventArgs e)
        {
            if (FIO.Text != "" && data_r.Text != "" && AN.Text != "" && address.Text != "" )
            {
                dbCon.Registr("INSERT INTO client(name,data,tel_nom,address,foto) " +
                  "values('" + FIO.Text + "','" + data_r.Text + "','"+AN.Text+ "','" + address.Text + "'" +
                  ",'"+ getJPGFromImageControl(image.Source as BitmapImage) +"')");
                RegistData("SELECT * FROM client");

                

            }
            else
            {
                MessageBox.Show("ds");   
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM client");
        }

        private void load_foto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Chose Image(*.jpg; *.png; *.fig)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == true)
            {
                image.Source= new BitmapImage(new Uri(opf.FileName));
            }
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
    }
}
