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
using System.Data;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для addBuilding.xaml
    /// </summary>
    public partial class addBuilding : Page
    {
        public addBuilding()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {

            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" && text5.Text != "" && text6.Text != "")
            {
                dbCon.Registr("INSERT INTO dom(name,floor,porch,count_kv,nom_kv,addres) " +
                  "values('"+text1.Text+"'," +
                 "'"+text2.Text+"','"+text3.Text+ "','" + text4.Text + "','" + text6.Text + "','" + text5.Text + "')");
               RegistData("select * from dom");
                messageReg.Foreground = Brushes.Green;
            }
            else
            {
               messageReg.Content= "Заполните все полии";
                messageReg.Foreground = Brushes.Red;
            }






        }

        private void text1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("select * from dom");
        }
        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }
    }
}
