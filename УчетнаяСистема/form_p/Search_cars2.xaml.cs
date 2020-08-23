using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Search_cars2.xaml
    /// </summary>
    public partial class Search_cars2 : Window
    {
        public Search_cars2()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        public delegate void MessageID(string id, string name, string USD, string KGS, string Id);
        public delegate void CloseDel();
        public event CloseDel clDel;
        public event MessageID mes_;
        RaschetSum raschetSum = new RaschetSum();
        lang lanG = new lang();
        public bool flag = false;
        string currency_id = "0", basaSum = "0", typeV = "", CarsName = "";
        double sena = 0;
        double usd = 0, eur = 0, rub = 0;
        string[] LangName = new string[3];
        string activUSD = "0";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (marka.Text != "" && data.Text != "" && nomer.Text != "" && ComboBox3.Text != "" && condition_t.Text != "" && activUSD != "0" && currency_id != "" && client_id != 0)
            {
                dbCon.Registr("INSERT INTO cars(marka,data,nomer,condition_c, prih_summ,type_v,kurs,client_id)" +
                    "values (" +
                    "'" + marka.Text + "'," +
                    "'" + data.Text + "'," +
                    "'" + nomer.Text + "'," +
                    "'" + condition_t.Text + "'," +
                    "'" + activUSD.Replace(',', '.') + "'," +
                    "'" + typeV + "'," +
                    "'" + currency_id + "'," +
                    "'" + client_id + "')");

                marka.Text = "";
                data.Text = "";
                nomer.Text = "";
                condition_t.Text = "";
                text_sum1.Text = "";
                text_sum2.Text = "";
                FIO.Text = "";
                if (flag == true)
                {
                    clDel();
                    this.Close();
                }
                else
                    Display();
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните все полии!";
                messageM.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                Display();


            }
            else
            {
                dataGridView1.Visibility = Visibility.Collapsed;
            }
        }

        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT c.id,c.marka,c.data,c.nomer,c.condition_c," +
                "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
                "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs," +
                "(SELECT name FROM client WHERE id = c.client_id) as client, " +
                "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov=0 AND c.prod_cars='0' " +
                "ORDER BY  c.id DESC;");

        }

        string id_1 = "";

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            Raschot();
        }
        void Raschot()
        {
            if (ComboBox3.Text != "" && currency_id != "0")
            {
                sena = text_sum1.Text != "" ? Convert.ToDouble(text_sum1.Text) : 0;
                LangName = lanG.ReturnName(ComboBox3.Text);
                l1.Content = LangName[1];
                l2.Content = LangName[2];
                text_sum2.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
                activUSD = sena.ToString();
                if (LangName[1] == "(KGS)")
                {
                    basaSum = text_sum1.Text.Replace(',', '.');
                    typeV = "(KGS)";
                }
                else if (LangName[1] == "(USD)")
                {
                    basaSum = text_sum1.Text.Replace(',', '.');
                    typeV = "(USD)";
                }
                else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
                {
                    basaSum = text_sum2.Text.Replace(',', '.');
                    typeV = "(KGS)";
                }
            }
        }


        private void text_sum1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Raschot();
        }

        int client_id = 0;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*columnIndex = dataGridView1.CurrentColumn.DisplayIndex;
            if (columnIndex == 9)
            {
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null)
                {
                    id_1 = dataRow.Row.ItemArray[0].ToString();
                    MessageO messageO = new MessageO();
                    if (id_1 != "")
                    {
                        messageO.Id = id_1;
                        messageO.TableBasa = "cars";
                        messageO.del_ += () => Display();
                        messageO.ShowDialog();
                    }
                }
            }*/

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
                    messageO.TableBasa = "cars";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }

        }
        string[] PriceCars = new string[5];
        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                CarsName = dataRow.Row.ItemArray[1].ToString();
                if (id_1 != "")
                {
                    PriceCars = dbCon.ReadMassiv("SELECT  c.id, " +
                        "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd, " +
                        "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs, c.kurs  " +
                        "FROM cars c INNER JOIN currency cur ON c.kurs = cur.id and c.id='" + id_1 + "'");
                    // MessageBox.Show(PriceCars[3]);
                    mes_(id_1, CarsName, PriceCars[1], PriceCars[2], PriceCars[3]);
                    this.Close();

                }
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void show_client_btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                FIO.Text = y;

            });
            window1.ShowDialog();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT c.id,c.marka,c.data,c.nomer,c.condition_c, " +
                "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
                "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs, " +
                "(SELECT name FROM client WHERE id = c.client_id) as client, " +
                "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov = 0 and c.prod_cars='0' and " +
                "CONCAT_WS('', c.marka, c.nomer) LIKE '%" + TextBox_search.Text + "%'");
        }

        private void btn_valuta_Click(object sender, RoutedEventArgs e)
        {
            Kurs kurs = new Kurs();
            kurs.del_ += (nid, nusd, neur, nrub) =>
            {
                currency_id = nid;
                usd = Convert.ToDouble(nusd.Replace('.', ','));
                eur = Convert.ToDouble(neur.Replace('.', ','));
                rub = Convert.ToDouble(nrub.Replace('.', ','));

            };
            kurs.ShowDialog();
        }


    }
}
