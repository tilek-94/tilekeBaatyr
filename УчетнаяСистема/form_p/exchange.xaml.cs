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
                    messageO.TableBasa = "exchange";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }
        }

        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT e.number_kv,c.name,p.name,e.`data` FROM (exchange e INNER JOIN client c ) " +
                "INNER JOIN product p ON e.client_id = c.id AND p.id = e.product_id WHERE e.remov = '0'" +
                "AND e.dom_id = '"+staticClass.StaticDomID+"'");

        }



    }
}
