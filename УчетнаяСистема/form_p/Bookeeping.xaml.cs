using System;
using System.Windows;
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
        int type_c=0;
        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxOrg.Tag = " Ф.И.О";
            LabelOrg.Content = "Ф.И.О";
        }
        string kodSchets = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string fmt = "№ 000000000.##";
            if (Flag == 1)
            {
                int intdata = Convert.ToInt16(dbCon.DisplayReturn("Select max(`id`) as `maxid` from prihod")) + 1;
                text1.Text = intdata.ToString(fmt);
                TextHeader.Text = "Приходный кассовый ордер";
            }
            else if (Flag == 2) {
                int intdata = Convert.ToInt16(dbCon.DisplayReturn("Select max(`id`) as `maxid` from rashod")) + 1;
                text1.Text = intdata.ToString(fmt);
                TextHeader.Text = "Расходный кассовый ордер";
            }
            
           
            
           
            DateTime thisDay = DateTime.Now;
            DataText.Text = thisDay.ToLocalTime().ToString();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operation operation = new Operation();
            operation.del += s => text3.Text=s;
            operation.ShowDialog();
        }
        int client_id = 0;
        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == true)
            {

                Window1 window1 = new Window1();
                window1.ValueChanged += new Action<string, string>((x, y) =>
                {
                    client_id = Convert.ToInt32(x);
                    TextBoxOrg.Text = y;

                });
                window1.ShowDialog();
                type_c = 0;
            }
            else { 
            Organization organization = new Organization();
            organization.del += s => TextBoxOrg.Text = s;
            organization.Show();
                type_c = 1;
            }

        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Flag==2)
            {
                dbCon.Registr("INSERT INTO rashod (operationU,organ,summa,currency,sotrud)" +
                "VALUES(" +
                "'" + text3.Text + "'," +
                "'" + TextBoxOrg.Text + "'," +
                "'" + text4.Text + "'," +
                "'" + kurs.Text + "'," +
                "'"+staticClass.StaticEmplayID+"'" +
                ")");
                del();
                this.Close();
            }else if (Flag == 1)
            {
                dbCon.Registr("INSERT INTO prihod (operationU,organ,summa,currency,sotrud)" +
                "VALUES(" +
                "'" + text3.Text + "'," +
                "'" + TextBoxOrg.Text + "'," +
                "'" + text4.Text + "'," +
                "'" + kurs.Text + "'," +
                "'" + staticClass.StaticEmplayID + "'" +
                ")");
                del();
                this.Close();
            }
            
            
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxOrg.Tag = "Организация";
            LabelOrg.Content = "Организация";
        }
    }
}
