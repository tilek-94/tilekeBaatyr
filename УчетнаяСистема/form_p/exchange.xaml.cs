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

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для exchange.xaml
    /// </summary>
    public partial class exchange : Window
    {
        public exchange()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        int client_id = 0, product_id;
     

        private void view_client_btn_Click(object sender, RoutedEventArgs e)
        {
            form_p.Window1 window1 = new form_p.Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                text1.Text = y;

            });
            window1.ShowDialog();
        }

        private void view_product_btn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new form_p.Product();
            product.ValueChanged += new Action<string, string>((x, y) =>
            {
                product_id = Convert.ToInt32(x);
                text2.Text = y;

            });
            product.ShowDialog();
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.Text!="") { 
            dbCon.Registr("INSERT INTO exchange(client_id,product_id,number_kv,dom_id)" +
                "VALUES('" + client_id + "','" + product_id + "','" + ComboBox1.Text + "','6')");
            Display();
                ComboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Выберите квартиру!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM exchange ORDER BY id DESC");

        }



    }
}
