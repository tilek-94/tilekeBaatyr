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
    /// Interaction logic for ProdCars.xaml
    /// </summary>
    public partial class ProdCars : Window
    {
        public ProdCars()
        {
            InitializeComponent();
        }
        string[] LangName = new string[3];
        RaschetSum raschetSum = new RaschetSum();
        dbConnect dbCon = new dbConnect();
        lang lanG = new lang();
        double sena = 0;
        double activUSD = 0;
        string basaSum = "0", typeV = "", id_1="0";
        double usd = 0, eur = 0, rub = 0;
        string cars_id = "0", client_id="0", currency_id = "0";
        private void view_btnС_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.mes_ += (x, y, USD, KGS, IdCurs) =>
            {
                cars_id = x;
                text1.Text=y;


            };
            search_Cars2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Raschot();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if(cars_id!="0" && client_id!="0" && basaSum!="0" && typeV!="" && currency_id != "0") { 
            dbCon.Registr("UPDATE cars SET remov = '"+staticClass.StaticEmplayID+ "' , prod_cars='" + staticClass.StaticEmplayID + "' WHERE id = '" + cars_id + "'; " +
                "INSERT INTO prod_cars (cars_id,client_id,price,typev,curren_id,employee_id) " +
                "VALUES ('" + cars_id + "','" + client_id + "','" + basaSum + "','" + typeV + "','" + currency_id + "','" + staticClass.StaticEmplayID + "')");
            Display();
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните все полии!";
                messageM.ShowDialog();
            }
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT p.id,(SELECT marka FROM cars where id=p.cars_id) AS cars," +
                " (SELECT name FROM client where id=p.client_id) as client, " +
                "IF(p.typev = '(KGS)', ROUND(p.price / cur.usd, 2), p.price) AS to_usd, " +
                "IF(p.typev = '(USD)', ROUND(p.price * cur.usd, 2), p.price) AS Rto_kgs, " +
                "p.data  FROM prod_cars p INNER JOIN currency cur ON p.curren_id = cur.id WHERE remov = '0' ORDER BY p.id DESC");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
            staticClass.StaticEmplayID = "7";
        }

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
                    messageO.TableBasa = "prod_cars";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            Raschot();
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

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = x;
                text2.Text = y;

            });
            window1.ShowDialog();
        }
    }
}
