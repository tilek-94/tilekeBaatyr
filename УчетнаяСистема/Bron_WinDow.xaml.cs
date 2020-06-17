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
using form_p = УчетнаяСистема.form_p;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Bron_WinDow.xaml
    /// </summary>
    public partial class Bron_WinDow : Window
    {
        public Bron_WinDow()
        {
            InitializeComponent();
        }
        int client_id;
        dbConnect dbCon = new dbConnect();
        string[] s;
        double dollar = 0,kurs=0,som=0;
        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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

        private void DelegATE(int f)
        {
            ComboBox1.Items.Clear();
            dbCon.eventDysplay2 += delegate (string[] a)
            {

                for (int i = 0; i < f; i++)
                {
                    if (Array.IndexOf(a, i.ToString()) < 0)
                        ComboBox1.Items.Add(i.ToString());
                }
            };
            dbCon.Display("SELECT number_f FROM zakaz");
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO bron (client_id,number_f,price_kv,kurs,sotrudnic_id) " +
                "VALUES ('"+ client_id + "','"+ComboBox1.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','0')");
            Display();
            ComboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            DelegATE(Convert.ToInt16(s[2]));
            Display();


        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM bron ORDER BY id DESC");

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
