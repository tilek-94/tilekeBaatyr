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
    /// 
    /// Логика взаимодействия для addBuilding.xaml
    /// 
    /// </summary>
    public partial class addBuilding : UserControl
    {
        Open_File open = new Open_File();
        public addBuilding()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {

            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" && text5.Text != "" && text6.Text != "")
            {
                open.Registr("INSERT INTO dom(name,floor,count_kv,porch,parking,nom_flat,addres) " +
                  "values('"+text1.Text+"'," +
                 "'"+text2.Text+"'," +
                 "'"+text3.Text+ "'," +
                 "'" + text4.Text + "'," +
                 "'" + text7.Text + "'," +
                 "'" + text6.Text + "'," +
                 "'" + text5.Text + "')");
               RegistData("select * from dom");
                ClearData();
                messageReg.Foreground = Brushes.Green;
                
            }
            else
            {
               messageReg.Content= "Заполните все полии!";
                messageReg.Foreground = Brushes.Red;
            }
        }
        
        private void ClearData()
        {
            text2.Text = "";
            text1.Text = "";
            text3.Text = "";
            text4.Text = "";
            text5.Text = "";
            text6.Text = "";
            text7.Text = "";
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

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpade_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            update.del_ += () => UpdateData();
            update.ShowDialog();
        }
        private void UpdateData()
        {
            /*open.Registr("UPDATE dom d SET " +
                "d.name='"+ +"'," +
                "d.floor=''," +
                "d.porch=''," +
                "d.count_kv = '', " +
                "d.parking = '', " +
                "d.nom_flat = ''," +
                " d.addres = '' WHERE id = '' ");
            */
            RegistData("select * from dom");

        }

        private void CancelData_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }
}
