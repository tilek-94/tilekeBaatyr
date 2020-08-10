using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for ProdBclass.xaml
    /// </summary>
    public partial class ProdBclass : Window
    {
        public ProdBclass()
        {
            InitializeComponent();
            this.ComboBox2.SelectedValuePath = "Key";
            this.ComboBox2.DisplayMemberPath = "Value";
        }
        public delegate void Dl();
        public event Dl del_;
        lang lanG = new lang();
        dbConnect dbCon;
        RaschetSum raschetSum = new RaschetSum();
        int client_id = 0;
        double usd = 0, eur = 0, rub = 0;
        string currency_id = "0", basaSum = "0", typeV = "";
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
        string data_n="";
        private void bRegistr_Click(object sender, RoutedEventArgs e)
        {
            dbCon = new dbConnect();
            if (ComboBox2.Text!="" && kvm!="" && textDol.Text!="" && textSumDol.Text!="" && currency_id!="")
            {
                data_n = CalendarM.DisplayDate.ToString("yyyy-MM-dd");
              dbCon.Registr("INSERT INTO prodbclass(" +
                    "number_id," +
                    "client_id," +
                    "price," +
                    "summ," +
                    "typev," +
                    "kurs," +
                    "data," +
                    "emp" +
                    ") VALUES(" +
                    "'"+pId+"'," +
                    "'"+client_id+"'," +
                    "'"+sena+"'," +
                    "'"+basaSum+"'," +
                    "'"+typeV+"'," +
                    "'"+currency_id+"'," +
                    "'"+ data_n + "'," +
                    "'"+staticClass.StaticEmplayID+"'" +
                    ")");
                this.Close();
                del_();
            }
        }
        double pId = 0;
        string kvm = "";
        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox2.SelectedValue != null)
            {
                pId = Convert.ToInt16(ComboBox2.SelectedValue);
                dbCon = new dbConnect();
                dbCon.eventDysplay += delegate (DataTable db)
                {
                    kvm = db.Rows[0][0].ToString();

                };
                dbCon.SoursData("SELECT m2 FROM bisnesclass b WHERE b.id= '" + pId + "'");
                if (kvm == "")
                    textm2.Text = "";
                textm2.Text = kvm;
            }
        }
        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            LangName = lanG.ReturnName(ComboBox3.Text);
            l1.Content = LangName[1];
            l2.Content = LangName[2];
            l21.Content = LangName[1];
            l22.Content = LangName[2];
            SummItogo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DelegATE();
        }

        private void DelegATE()
        {
            dbCon = new dbConnect();
            ComboBox2.Items.Clear();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for (int i = 0; i < db.Rows.Count; i++)
                    ComboBox2.Items.Add(new KeyValuePair<string, string>(db.Rows[i][0].ToString(), db.Rows[i][1].ToString()));


            };

            dbCon.SoursData("SELECT id,name FROM bisnesclass b WHERE b.id " +
                "NOT IN(SELECT p.number_id FROM prodbclass p WHERE p.remov = '0') " +
                "AND b.remov = '0' AND b.dom_id='"+staticClass.StaticDomID+"'");

        }
        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
        double m2, sena, summ;
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
               SummItogo();
            
        }

        private void SummItogo()
        {
            if (textDol.Text != "")
            {
                if (textm2.Text != "")
                {
                    m2 = Convert.ToDouble(textm2.Text);
                    sena = Convert.ToDouble(textDol.Text);
                    summ = m2 * sena;
                    textSom.Text = summ.ToString();
                }
                else
                    m2 = 0;
                if (currency_id != "0")
                {
                    textSumDol.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
                    textSumKg.Text = raschetSum.Kurs(ComboBox3.Text, summ, usd, eur, rub).ToString();
                }
            }

            if (LangName[1] == "(KGS)")
            {
                // м2 учун цена
                basaSum = textSumDol.Text.ToString().Replace(',', '.');
               // Валютанын тиби
                typeV = "(KGS)";

            }
            else if (LangName[1] == "(USD)")
            {
                basaSum = textSumDol.Text.ToString().Replace(',', '.');
                typeV = "(USD)";
               

            }
            else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
            {
                basaSum = textSumKg.Text.ToString().Replace(',', '.');
                typeV = "(KGS)";
                
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

        public void ItogoR()
        {
/*
            textbox_m2.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
            textbox_summ.Text = raschetSum.Kurs(ComboBox3.Text, summ, usd, eur, rub).ToString();
            if (textBox_vz.Text != "")
                vznos = Convert.ToDouble(textBox_vz.Text);
            else vznos = 0;

            textbox_Som_vz2.Text = raschetSum.Kurs(ComboBox3.Text, vznos, usd, eur, rub).ToString();
            LangName = lanG.ReturnName(ComboBox3.Text);
            l1.Content = LangName[1];
            l2.Content = LangName[1];
            l3.Content = LangName[1];
            l4.Content = LangName[1];
            l12.Content = LangName[2];
            l22.Content = LangName[2];
            l32.Content = LangName[2];
            l42.Content = LangName[2];
            li2.Content = LangName[2] + ":";
            li1.Content = LangName[1] + ":";
            if (KgsCars != 0)
                textboxCarsUsd.Text = raschetSum.ReaderBasa(ComboBox3.Text, KgsCars, IdCarsCurs).ToString();
            if (UsdCars != 0)
                textboxCarsKGS.Text = raschetSum.ReaderBasa2(ComboBox3.Text, UsdCars, IdCarsCurs).ToString();
            SummItogo();
*/
        }

        string[] LangName = new string[3];
    }
}
