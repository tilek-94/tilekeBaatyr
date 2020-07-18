using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProdPar.xaml
    /// </summary>
    public partial class ProdPar : Window
    {
        public ProdPar()
        {
            InitializeComponent();
        }
        string client_id = "", cars_id="", IdCarsCurs="", KgsCars="0", UsdCars="0", typeV = "";
        string currency_id = "0", basaSum="0";
        string[] LangName = new string[3];
        double usd = 0, eur = 0, rub = 0;
        RaschetSum raschetSum = new RaschetSum();
        dbConnect dbCon = new dbConnect();
        lang lanG = new lang();
        private void show_client_Cars_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.mes_ += (x, y, USD, KGS, IdCurs) =>
            {
                cars_id = x;
                text4.Text = USD;
                textbox_cars.Text = y;
                IdCarsCurs = IdCurs;
                KgsCars = KGS;
                UsdCars = USD;
            };
            search_Cars2.ShowDialog();
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

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SummItogo();
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
            if (KgsCars != "0")
                text4.Text = raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString();

            /* if (UsdCars != "0")
                 text4.Text = raschetSum.ReaderBasa2(ComboBox3.Text, Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
           */
            LangName = lanG.ReturnName(ComboBox3.Text);
            SummItogo();
            
        }

        void SummItogo()
        {

            double priceP = 0;
            if (text5.Text != "")
                priceP = Convert.ToDouble(text5.Text);
              text6.Text= raschetSum.Kurs(ComboBox3.Text, priceP, usd, eur, rub).ToString();

            if (LangName[1] == "(KGS)")
            {
                basaSum = (priceP - Convert.ToDouble( KgsCars)).ToString().Replace(',', '.');
                typeV = "(KGS)";

                
            }
            else if (LangName[1] == "(USD)")
            {
                basaSum = (priceP - Convert.ToDouble(UsdCars)).ToString().Replace(',', '.');

                typeV = "(USD)";
               

            }
            else if (LangName[1] == "(EUR)" || LangName[1] == "(RUB)")
            {
                basaSum = (Convert.ToDouble(text6.Text) - Convert.ToDouble(KgsCars)).ToString().Replace(',', '.');
                typeV = "(KGS)";
               
            }


        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{basaSum} {typeV}");
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
