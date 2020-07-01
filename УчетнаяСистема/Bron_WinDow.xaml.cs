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
        RaschetSum raschetSum = new RaschetSum();
        lang lanG = new lang();
        string currency_id = "0", basaSum="0",typeV="";
        double sena = 0;
        double usd = 0, eur = 0, rub = 0;
        string[] LangName = new string[3];
        double activUSD = 0;
        string id_1="";

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

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            Raschot();
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
                if (LangName[1]=="(KGS)") {
                    basaSum = textBox1.Text.Replace(',', '.'); 
                    typeV = "(KGS)";
                }else if (LangName[1] == "(USD)") {
                    basaSum = textBox1.Text.Replace(',', '.'); 
                    typeV = "(USD)";
                }
                else if(LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
                {
                    basaSum = textBox2.Text.Replace(',','.');
                    typeV = "(KGS)";
                }
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Raschot();
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
            dbCon.Registr("INSERT INTO bron (client_id,number_f,price_kv,typev,kurs,sotrudnic_id) " +
                "VALUES ('"+ client_id + "','"+ComboBox1.Text+"','"+ basaSum + "','"+typeV+"','"+ currency_id + "','0')");
            Display();
            ComboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id_1 != "0") { 
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить данные?","Сообщения", MessageBoxButton.YesNo);

                if(result== MessageBoxResult.Yes)
                
                    dbCon.RemoveData("bron", id_1);
                Display();
                }
                else
                {
                    MessageBox.Show("");
                }
            }
            catch { }

        }

        private void dataGridView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            id_1 = dataRow.Row.ItemArray[0].ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            DelegATE(Convert.ToInt16(s[2]));
            Display();


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

        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT b.id, b.number_f, (SELECT name FROM client where id=b.client_id) as client," +
                "IF(b.typev = '(KGS)', ROUND(b.price_kv / cur.usd, 2), b.price_kv) AS to_usd," +
                "IF(b.typev = '(USD)', ROUND(b.price_kv * cur.usd, 2), b.price_kv) AS Rto_kgs," +
                " b.data  FROM bron b INNER JOIN currency cur ON b.kurs = cur.id WHERE remov='0' ORDER BY b.id DESC");

        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
/*
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dollar = Convert.ToDouble(textBox1.Text);
                kurs = Convert.ToDouble(textBox2.Text);
                som = dollar * kurs;
                textBox3.Text = Convert.ToString(som);
            }*/
        }
    }
}
