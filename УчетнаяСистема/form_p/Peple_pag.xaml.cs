using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data;
using УчетнаяСистема.All_classes;
using System.IO;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Peple_pag.xaml
    /// </summary>
    public partial class Peple_pag : UserControl
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
            RegistData("SELECT * FROM client WHERE remov='0'");
        }
        /*public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 search_Cars2 = new Window1();
            search_Cars2.Height = 330;
            search_Cars2.ShowDialog();
        }
        string id_1 = "";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "client";
                    messageO.del_ += () => RegistData("SELECT * FROM client WHERE remov='0'");
                    messageO.ShowDialog();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegistData("SELECT * FROM client WHERE (name LIKE '%"+ textSearch.Text + "%' or AN LIKE '%" + textSearch.Text + "%') and remov='0'");
            
        }
    }
}
