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
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Bron_Klient.xaml
    /// </summary>
    public partial class Bron_Klient : Window
    {
        dbConnect dbCon = new dbConnect();
        double dollar = 0, kurs = 0, som = 0;
        public Bron_Klient()
        {
            InitializeComponent();
        }
        int client_id = 0;
        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            form_p.Window1 window1 = new form_p.Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                text1.Text = y;

            });
            window1.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Frame_Bron_Klient.Navigate(new System.Uri("form_p/view_year.xaml", UriKind.RelativeOrAbsolute));
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO repayment(client_id,summa,kurs,data_month)VALUES('" +client_id.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + data1.Text.ToString() + "')");
            data1.Text = "";
            text1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dollar = Convert.ToDouble(textBox1.Text);
                kurs = Convert.ToDouble(textBox2.Text);
                som = dollar * kurs;
                textBox3.Text = Convert.ToString(som);
            }
        }
    }
}
