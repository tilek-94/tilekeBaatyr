using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.Model;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for ProdPar.xaml
    /// </summary>
    public partial class ProdPar : Window
    {
        public ProdPar()
        {
            InitializeComponent();
        }
        string client_id = "",  IdCarsCurs="", typeV = "";
        string currency_id = "0", basaSum="0" ,PriceSum;
        int cars_id = 0;
        string[] LangName = new string[3];
        double usd = 0, eur = 0, rub = 0;
        dbConnect dbCon;
        List<Cars> cars = new List<Cars>();
        double KgsCars = 0, UsdCars = 0;
        RaschetSum raschetSum = new RaschetSum();
        lang lanG = new lang();
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
                SummItogo();
            };
            search_Cars2.ShowDialog();
        }
        string[] s;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbCon = new dbConnect();
            
            s = dbCon.RedInfor("SELECT parking,id,id FROM dom WHERE id='" + staticClass.StaticDomID + "'");
            DelegATE(Convert.ToInt16(s[0]));
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
            dbCon.Display("SELECT number FROM parking WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
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
                    SummItogo();
                    break;
                }
            }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = x;
                text1.Text = y;

            });
            window1.ShowDialog();
        }

        private void text9_TextChanged(object sender, TextChangedEventArgs e)
        {
            SummItogo();
            double priceP = 0;
            if (text9.Text != "")
                priceP = Convert.ToDouble(text9.Text);
            text10.Text = raschetSum.Kurs(ComboBox3.Text, priceP, usd, eur, rub).ToString();
        }
        void SummItogo()
        {
            GetDataCom();
            text7.Text = (PriceUSD - CarsUSD -  PrihUSD).ToString();
            text8.Text = (PriceKGS - CarsKGS - PrihKGS).ToString();

            if (LangName[1] == "(KGS)")
            {
                basaSum = text7.Text.Replace(',', '.');
                PriceSum=text5.Text.Replace(',', '.');
                typeV = "(KGS)";


            }
            else if (LangName[1] == "(USD)")
            {
                basaSum = text7.Text.Replace(',', '.');
                PriceSum = text5.Text.Replace(',', '.');
                typeV = "(USD)";


            }
            else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
            {
                basaSum = text8.Text.Replace(',', '.');
                PriceSum = text6.Text.Replace(',', '.');
                typeV = "(KGS)";

            }

        }

        double CarsUSD = 0,CarsKGS=0, PriceUSD=0, PriceKGS=0,PrihUSD=0,PrihKGS=0;
        private void GetDataCom()
        {  if(textboxCarsUsd.Text!="")
                CarsUSD = Convert.ToDouble(textboxCarsUsd.Text);
            if (textboxCarsKGS.Text != "")
                CarsKGS = Convert.ToDouble(textboxCarsKGS.Text);
            if (text5.Text != "")
                PriceUSD = Convert.ToDouble(text5.Text);
            if (text5.Text != "")
                PriceKGS = Convert.ToDouble(text6.Text);
            if (text9.Text != "")
                PrihUSD = Convert.ToDouble(text9.Text);
            if (text10.Text != "")
                PrihKGS = Convert.ToDouble(text10.Text);
                      
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SummItogo();
            double priceP = 0;
            if (text5.Text != "")
                priceP = Convert.ToDouble(text5.Text);
            text6.Text = raschetSum.Kurs(ComboBox3.Text, priceP, usd, eur, rub).ToString();
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
            if (KgsCars != 0)
                textboxCarsUsd.Text = raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString();

             if (UsdCars != 0)
                textboxCarsKGS.Text = raschetSum.ReaderBasa2(ComboBox3.Text, Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
           
            LangName = lanG.ReturnName(ComboBox3.Text);
            U1.Content= LangName[1];
            U2.Content= LangName[1];
            U3.Content= LangName[1];
            U4.Content= LangName[1];

            K1.Content = LangName[2];
            K2.Content = LangName[2];
            K3.Content = LangName[2];
            K4.Content = LangName[2];
            SummItogo();
            
        }

        

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(cars);
            if (cars.Count == 0)
                json = "";
            SummItogo();
            //f(staticClass.StaticDomID != "0" && ComboBox_E.Text != "" && ComboBox_P.Text != "" && ComboBox_flat.Text != "" && ComboBox_t.Text != "" && ComboBox_kv.Text != "") {

            dbCon.Registr("INSERT INTO parking(dom_id,number,client_id,cars_id,itogPrice,zadol,typev,curr_id) " +
                  "values('" + staticClass.StaticDomID + "'," +
                  "'" + ComboBox1.Text + "'," +
                  "'" + client_id + "'," +
                  "'" + json + "'," +
                  "'" + PriceSum  + "'," +
                  "'" + basaSum  + "'," +
                  "'" + typeV + "'," +
                  "'" + currency_id + "'" +
                  ")");

                //RegistData();

                DelegATE(Convert.ToInt16(s[3]));
           // }


            //MessageBox.Show($"{basaSum} {typeV}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
