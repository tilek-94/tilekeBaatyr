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

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for Bookeeping.xaml
    /// </summary>
    public partial class Bookeeping : Window
    {
        public Bookeeping()
        {
            InitializeComponent();
        }
        public delegate void MessageDel();
        public event MessageDel del;
        dbConnect dbCon = new dbConnect();
        public int Flag = 0;
        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxOrg.Tag = "Организация";
            LabelOrg.Content = "Организация";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxOrg.Tag = " Ф.И.О";
            LabelOrg.Content = "Ф.И.О";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Flag == 1)
            {
                TextHeader.Text = "Приходный кассовый ордер";
            }
            else if (Flag == 2) {
                TextHeader.Text = "Расходный кассовый ордер";
            }
            
            string fmt = "№ 000000000.##";
            
            int intdata = Convert.ToInt16( dbCon.DisplayReturn("SELECT COUNT(id) FROM finance"))+1; 
            text1.Text =intdata.ToString(fmt);
            DateTime thisDay = DateTime.Now;
            DataText.Text = thisDay.ToLocalTime().ToString();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operation operation = new Operation();
            operation.del += s => text3.Text=s;
            operation.ShowDialog();
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            Organization organization = new Organization();
            organization.del += s => TextBoxOrg.Text = s;

            organization.Show();
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO finance (operationU,organ,summa,currency,typeO,sotrud)" +
                "VALUES(" +
                "'"+text3.Text+"'," +
                "'"+TextBoxOrg.Text+"'," +
                "'"+text4.Text+"'," +
                "'"+kurs.Text+"'," +
                "'"+Flag+"'," +
                "'6'" +
                ")");
            del();
            this.Close();
            
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
