using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.Model;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for ProdPhous.xaml
    /// </summary>
    public partial class ProdPhous : Window
    {
        public ProdPhous()
        {
            InitializeComponent();
            this.ComboBox2.SelectedValuePath = "Key";
            this.ComboBox2.DisplayMemberPath = "Value";
        }
        public delegate void ReStart();
        public event ReStart del_;
        dbConnect dbCon;
        RaschetSum raschetSum = new RaschetSum();
        List<Cars> cars = new List<Cars>();
        lang lanG = new lang();
        int cars_id = 0;
        int client_id = 0;
        double KgsCars = 0, UsdCars = 0;
        string currency_id = "0", basaSum = "0", typeV = "";
        string IdCarsCurs = "0", ItogPrice = "0", Vznos = "0", DebZa = "0";
        double UsdSum = 0, USDCars = 0;
        double VznosSum = 0, KgsSUM = 0, UsdCarsSum = 0;
        double m2 = 0, sena = 0, vznos = 0, summ = 0, KGS = 0, USD = 0;
        double usd = 0, eur = 0, rub = 0;
        int data11 = 1;


        CarsService ObjCarsService;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ObjCarsService = new CarsService();
            LoadDisplay();

        }

        void LoadDisplay()
        {
            dbCon = new dbConnect();

            dbCon.eventDysplay += delegate (DataTable db)
            {
                // dataGridView1.ItemsSource = db.DefaultView;

            };
            dbCon.SoursData("SELECT * FROM dysplayaddbuild WHERE dom_id='" + staticClass.StaticDomID + "' ORDER BY id DESC");

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

            dbCon.SoursData("SELECT id,name FROM phous p WHERE p.dom_id='21' AND p.remov='0' " +
                "AND p.id NOT IN(SELECT phous_id FROM prodphous WHERE remov = '0')");

        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            view_year view_Year = new view_year();
            //view_Year.ShowDialog();
        }

        private void btn_graf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (USD != 0 && KGS != 0 && d1 != "" && d2 != "" && ComboBox2.Text != "")
                {
                    DateTime nd = kon_n.DisplayDate.Date;
                    DateTime kd = kon_d.DisplayDate.Date;
                    data11 = ((kd.Year - nd.Year) * 12) + kd.Month - nd.Month;
                    MessageBox.Show(data11.ToString());

                    view_year view_Year = new view_year();
                    view_Year.Flag = true;
                    view_Year.ClientId = client_id.ToString();
                    view_Year.NumberF = ComboBox2.Text;
                    view_Year.KGS = Math.Round(KGS / data11, 2);
                    view_Year.USD = Math.Round(USD / data11, 2);
                    view_Year.d1 = d1;
                    view_Year.m1 = mon1;
                    view_Year.y1 = y1;
                    view_Year.d2 = d2;
                    view_Year.m2 = mon2;
                    view_Year.y2 = y2;

                    view_Year.ShowDialog();
                }
                else
                {
                    MessageM messageM = new MessageM();
                    messageM.Mees = "Заполните все полии";
                    messageM.ShowDialog();
                }
            }
            catch { }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
        
        private void registr_client_btn_Click(object sender, RoutedEventArgs e)
        {

            string json = JsonConvert.SerializeObject(cars);
            if (textbox_dogovor.Text != "" && client_id != 0 && pId != 0 && currency_id != "0" && textbox_dogovor.Text != null && basaSum != "0" && data_n != "" && data_k != "")
            {

                dbCon.Registr("INSERT INTO prodphous(" +
                    "dom_id," +
                    "client_id," +
                    "phous_id," +
                    "cars_id," +
                    "contract," +
                    "price_kvm," +
                    "itog_price," +
                    "vznos," +
                    "debu_za," +
                    "typev," +
                    "kurs," +
                    "kvm," +
                    "data_n," +
                    "data_k,emp) " +

                      "values('" + staticClass.StaticDomID + "'," +
                      "'" + client_id + "'," +
                      "'" + pId + "'," +
                      "'" + json + "'," +
                      "'" + textbox_dogovor.Text + "'," +
                      "'" + basaSum + "'," +
                      "'" + ItogPrice + "'," +
                      "'" + Vznos + "'," +
                      "'" + DebZa + "'," +
                      "'" + typeV + "'," +
                      "'" + currency_id + "'," +
                      "'" + kvm.Replace(',', '.') + "'," +
                      "'" + data_n + "','" + data_k + "','8')");
                LoadDisplay();
                del_();
                this.Close();
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните все поля!";
                messageM.ShowDialog();

            }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
       
        private void x1_Click(object sender, RoutedEventArgs e)
        {
        }
        Cars value;
        Double RemovSumKg = 0, RemovSumUsd = 0;

        private void ComboBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboBoxCars.SelectedValue != null)
                value = (Cars)ComboBoxCars.SelectedValue;
            for (int index = 0; index < cars.Count; index++)
            {
                if (cars[index].Id == value.Id)
                {
                    RemovSumKg = cars[index].Kgs;
                    RemovSumUsd = cars[index].Usd;
                    UsdCars -= RemovSumUsd;
                    KgsCars -= RemovSumKg;
                    textboxCarsUsd.Text = UsdCars.ToString();
                    textboxCarsKGS.Text = KgsCars.ToString();
                    cars.RemoveAt(index);
                    ComboBoxCars.ItemsSource = null;
                    ComboBoxCars.ItemsSource = cars;
                    break;
                }
            }

            ItogoR();
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int pId = 0;
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedValue != null) { 
                pId = Convert.ToInt16(ComboBox2.SelectedValue);
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                kvm = db.Rows[0][0].ToString();

            };
            dbCon.SoursData("SELECT (SELECT SUM(m2) FROM typephous t WHERE p.id=t.phous_id AND t.remov='0' ) " +
                "FROM phous p WHERE p.id = '"+pId+"'");
            if (kvm == "")
                label_kvm.Text = "";
            label_kvm.Text = kvm;
            }
        }

        private void show_client_Cars_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.mes_ += (x, y, USD, KGS, IdCurs) =>
            {
                KgsCars = 0;
                UsdCars = 0;
                ComboBoxCars.ItemsSource = null;
                cars_id = Convert.ToInt32(x);

                ComboBoxCars.Text = y;
                IdCarsCurs = IdCurs;
                cars.Add(new Cars { Id = cars_id, Name = y, Kgs = Convert.ToDouble(KGS), Usd = Convert.ToDouble(USD) });
                foreach (Cars c in cars)
                {
                    KgsCars += c.Kgs;
                    UsdCars += c.Usd;

                }
                ComboBoxCars.ItemsSource = cars;
                textboxCarsUsd.Text = UsdCars.ToString();
                textboxCarsKGS.Text = KgsCars.ToString();
            };
            search_Cars2.ShowDialog();


        }

        string kvm = "";
        string data_n = "", data_k = "", d1 = "", mon1 = "", y1 = "", d2 = "", mon2 = "", y2 = "";

        private void kon_d_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            data_k = kon_d.DisplayDate.ToString("yyyy-MM-dd");

            d2 = kon_d.DisplayDate.ToString("dd");
            mon2 = kon_d.DisplayDate.ToString("MM");
            y2 = kon_d.DisplayDate.ToString("yyyy");

        }

        private void kon_n_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            data_n = kon_n.DisplayDate.ToString("yyyy-MM-dd");

            d1 = kon_n.DisplayDate.ToString("dd");
            mon1 = kon_n.DisplayDate.ToString("MM");
            y1 = kon_n.DisplayDate.ToString("yyyy");


        }

        private void textBox_vz_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (currency_id != "0")
                {
                    if (textBox_vz.Text != "")
                        vznos = Convert.ToDouble(textBox_vz.Text);
                    else vznos = 0;
                    textbox_Som_vz2.Text = raschetSum.Kurs(ComboBox3.Text, vznos, usd, eur, rub).ToString();
                    SummItogo();
                }
            }
            catch { }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        void SummItogo()
        {

            double M2sum = 0, M2sum2 = 0;
            if (textbox_Dol.Text != "")
                M2sum = Convert.ToDouble(textbox_Dol.Text);
            if (textbox_Summ.Text != "")
                UsdSum = Convert.ToDouble(textbox_Summ.Text);
            if (textBox_vz.Text != "")
                vznos = Convert.ToDouble(textBox_vz.Text);
            if (textboxCarsUsd.Text != "")
                USDCars = Convert.ToDouble(textboxCarsUsd.Text);
            else
                USDCars = 0;

            USD = UsdSum - (vznos + USDCars);
            string itogDol = String.Format("{0:C}", USD);
            label_summ_Dol_itog.Text = itogDol.Substring(0, itogDol.Length - 2);

            if (textbox_m2.Text != "")
                M2sum2 = Convert.ToDouble(textbox_m2.Text);
            if (textbox_summ.Text != "")
                KgsSUM = Convert.ToDouble(textbox_summ.Text);
            if (textbox_Som_vz2.Text != "")
                VznosSum = Convert.ToDouble(textbox_Som_vz2.Text);
            if (textboxCarsKGS.Text != "")
                UsdCarsSum = Convert.ToDouble(textboxCarsKGS.Text);
            else
                UsdCarsSum = 0;
            KGS = KgsSUM - (VznosSum + UsdCarsSum);
            string itogSOM = String.Format("{0:C}", KGS);
            label_summ_Som_itog.Text = itogSOM.Substring(0, itogSOM.Length - 2);

            if (LangName[1] == "(KGS)")
            {
                // м2 учун цена
                basaSum = M2sum2.ToString().Replace(',', '.');
                // Квартиранын жалпы суммасы
                ItogPrice = KgsSUM.ToString().Replace(',', '.');
                //Дебуторский за дольжность
                DebZa = KGS.ToString().Replace(',', '.');
                // Валютанын тиби
                typeV = "(KGS)";

                // первоначальный взнос
                Vznos = (VznosSum + UsdCarsSum).ToString().Replace(',', '.');

            }
            else if (LangName[1] == "(USD)")
            {
                basaSum = M2sum.ToString().Replace(',', '.');
                ItogPrice = UsdSum.ToString().Replace(',', '.');
                DebZa = USD.ToString().Replace(',', '.');
                typeV = "(USD)";
                Vznos = (vznos + USDCars).ToString().Replace(',', '.');

            }
            else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
            {
                basaSum = M2sum2.ToString().Replace(',', '.');
                ItogPrice = KgsSUM.ToString().Replace(',', '.');
                DebZa = KGS.ToString().Replace(',', '.');
                typeV = "(KGS)";
                Vznos = (VznosSum + UsdCarsSum).ToString().Replace(',', '.');
            }


        }

        private void textbox_Dol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox_Dol.Text != "")
            {

                if (label_kvm.Text != "")
                {
                    m2 = Convert.ToDouble(label_kvm.Text);
                    sena = Convert.ToDouble(textbox_Dol.Text);
                    summ = m2 * sena;
                    textbox_Summ.Text = summ.ToString();
                }
                else
                    m2 = 0;
                if (currency_id != "0")
                {
                    textbox_m2.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
                    textbox_summ.Text = raschetSum.Kurs(ComboBox3.Text, summ, usd, eur, rub).ToString();
                }
                SummItogo();
            }

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

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // data_n = Calendar1.DisplayDate.ToString("yyyy-MM-dd");
        }

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            ItogoR();
        }
        public void ItogoR()
        {

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

        }

        string[] LangName = new string[3];
        
    }
}