using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

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
        dbConnect dbCon;
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

        private void DelegATE()
        {
            dbCon = new dbConnect();
            ComboBox1.Items.Clear();
            dbCon.eventDysplay += delegate (DataTable db)
            {
               // MessageBox.Show(db.Rows[0][0].ToString());
                  for(int i=0; i < db.Rows.Count;i++) 
                ComboBox1.Items.Add(db.Rows[i][0].ToString());
                
            };

            dbCon.SoursData("SELECT f.number_f FROM flat f WHERE f.number_f " +
                "NOT IN(SELECT e.number_f FROM exchange e WHERE e.remov = '0' " +
                "AND e.dom_id = '"+staticClass.StaticDomID+"') AND f.number_f " + 
                "NOT IN(SELECT z.number_f FROM zakaz z WHERE z.remov = '0' " +
                "AND z.dom_id = '" + staticClass.StaticDomID + "') AND f.number_f " +
                "NOT IN(SELECT b.number_f FROM bron b WHERE b.remov = '0' AND b.dom_id = '" + staticClass.StaticDomID + "') " +
                "AND f.dom_id = '" + staticClass.StaticDomID + "' AND f.remov = '0' ORDER BY number_f ");

        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO bron (client_id,dom_id,number_f,price_kv,typev,kurs,sotrudnic_id) " +
                "VALUES ('"+ client_id + "','"+staticClass.StaticDomID+"','"+ComboBox1.Text+"','"+ basaSum + "','"+typeV+"','"+ currency_id + "','"+staticClass.StaticEmplayID+"')");
            Display();
            ComboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            DelegATE();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dataGridView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if(dataRow!=null)
            id_1 = dataRow.Row.ItemArray[0].ToString();
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
                    messageO.TableBasa = "bron";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DelegATE();
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
            dbCon =new dbConnect();
            
            dbCon.eventDysplay +=  (DataTable db)=>
            {
                
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM bron_pres b WHERE b.dom_id='"+staticClass.StaticDomID+"'");

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
