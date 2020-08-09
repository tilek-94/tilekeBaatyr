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
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        
        public Product()
        {
            InitializeComponent();
        }
        public event Action<string, string> ValueChanged;
        dbConnect dbCon = new dbConnect();
        string id = "";
        RaschetSum raschetSum = new RaschetSum();
        lang lanG = new lang();
        string currency_id = "0", basaSum = "0", typeV = "";
        double sena = 0;
        double usd = 0, eur = 0, rub = 0;
        string[] LangName = new string[3];
        double activUSD = 0;
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }

        string name;
        private void myDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            int index = dataGridView1.CurrentCell.Column.DisplayIndex;
            id = dataRow.Row.ItemArray[0].ToString();
            name = dataRow.Row.ItemArray[1].ToString();
            string price = dataRow.Row.ItemArray[2].ToString();
            string kurs = dataRow.Row.ItemArray[3].ToString();
            text1.Text = name;
                       
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void button_vbor_Click(object sender, RoutedEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        void Raschot()
        {
            if (ComboBox3.Text != "" && currency_id != "0")
            {
                sena = textBox1.Text != "" ? Convert.ToDouble(textBox1.Text) : 0;
                LangName = lanG.ReturnName(ComboBox3.Text);
                l1.Content = LangName[1];
                l2.Content = LangName[2];
                textBox2.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
                activUSD = sena * usd;
                if (LangName[1] == "(KGS)")
                {
                    basaSum = textBox1.Text.Replace(',', '.');
                    typeV = "(KGS)";
                }
                else if (LangName[1] == "(USD)")
                {
                    basaSum = textBox1.Text.Replace(',', '.');
                    typeV = "(USD)";
                }
                else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
                {
                    basaSum = textBox2.Text.Replace(',', '.');
                    typeV = "(KGS)";
                }
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_valuta_Click(object sender, RoutedEventArgs e)
        {
            Kurs kurs = new Kurs();
            kurs.del_ += (nid, nusd, neur, nrub) => {
                currency_id = nid;
                usd = Convert.ToDouble(nusd.Replace('.', ','));
                eur = Convert.ToDouble(neur.Replace('.', ','));
                rub = Convert.ToDouble(nrub.Replace('.', ','));

            };
            kurs.ShowDialog();
        }

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            Raschot();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Raschot();
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if(text1.Text!="" && textBox1.Text!="" && currency_id != "") { 
            dbCon.Registr("INSERT INTO product(name,price,typev,kurs) VALUES('"+text1.Text+"','"+ basaSum+"','"+typeV+"','"+currency_id+"')");
            Display();
            }
            else
            {
                MessageBox.Show("Заполните все полии!");
            }
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT c.id, c.name, " +
                "    IF(c.typev = '(KGS)', ROUND(c.price / cur.usd, 2), c.price) AS to_usd," +
                "    IF(c.typev = '(USD)', ROUND(c.price * cur.usd, 2), c.price) AS Rto_kgs, c.data " +
                "    FROM product c    INNER JOIN currency cur ON c.kurs = cur.id");

        }
    }
}
