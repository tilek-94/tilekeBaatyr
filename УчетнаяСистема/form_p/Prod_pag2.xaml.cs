using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Prod_pag2.xaml
    /// </summary>
    public partial class Prod_pag2 : Page
    {
        public Prod_pag2()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        dbConnect dbCon2 = new dbConnect();
        RaschetSum raschetSum = new RaschetSum();
        lang lanG = new lang();
        int cars_id = 0;
        int client_id = 0;
        string currency_id="0",KgsCars="0",UsdCars="0";
        string IdCarsCurs = "0";
        
        double summ_cars = 0;
        double kurs_cars = 0;
        double m2 = 0,sena=0, vznos=0,summ=0;
        double usd = 0, eur = 0, rub = 0; 
        

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
                for (int i = 0; i < db.Rows.Count; i++)
                {
                   //MessageBox.Show( db.Rows[0][7].ToString());

                }
            };
            dbCon.SoursData("SELECT * FROM zakaz_z  ORDER BY id DESC ");

            string[] s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            DelegATE(Convert.ToInt32( s[2]));
        }
        private void DelegATE(int f)
        {
            ComboBox2.Items.Clear();
            dbCon.eventDysplay2 += delegate (string[] a)
            {

                for (int i = 0; i < f; i++)
                {
                    if (Array.IndexOf(a, i.ToString()) < 0)
                        ComboBox2.Items.Add(i.ToString());
                }
            };
            dbCon.Display("SELECT number_f FROM zakaz");
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            view_year view_Year = new view_year();
            //view_Year.ShowDialog();
        }

        private void registr_client_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO zakaz(dom_id,klient_id,number_f,cars_id,contract,price_kvm,kurs,kvm,data_n,data_k) " +
                  "values('6','" + client_id + "','" + ComboBox2.Text + "','" + cars_id + "','" + textbox_dogovor.Text + "','"+ (dollar.ToString()).Replace(',','.') + "'" +
                  ",'"+(kurs.ToString()).Replace(',', '.') + "','"+kvm.Replace(',', '.') + "','"+data_n+"','"+data_k+"')");
           
            dbCon.eventDysplay +=  db=>  { dataGridView1.ItemsSource = db.DefaultView; };
            dbCon.SoursData("SELECT * FROM zakaz_z ORDER BY id DESC");

        }

        private void show_client_btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
          window1.ValueChanged += new Action<string,string>((x,y) =>
            {
                client_id = Convert.ToInt32(x);
                FIO.Text = y;

            });
            window1.ShowDialog();
        }

        private void show_client_Cars_Click(object sender, RoutedEventArgs e)
        {

            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.mes_ += (x,  y,  USD, KGS,IdCurs)=>
            {
                cars_id = Convert.ToInt32(x);
                summ_cars = Convert.ToDouble(summ);
                kurs_cars = Convert.ToDouble(kurs);
                textboxCarsUsd.Text = USD;
                textboxCarsKGS.Text = KGS;
                textbox_cars.Text = y;
                IdCarsCurs = IdCurs;
                KgsCars = KGS;
                UsdCars = USD;
            };
            search_Cars2.ShowDialog();
        }

        string  kvm = "";
        double dollar = 0,kurs=0, som=0;
               
        string data_n = "",data_k="";

        private void Calendar2_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
           // data_k = Calendar2.DisplayDate.ToString("yyyy-MM-dd");
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_vz_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currency_id != "0")
            {
                if (textBox_vz.Text != "")
                    vznos = Convert.ToDouble(textBox_vz.Text);
                else vznos = 0;
                textbox_Som_vz2.Text = raschetSum.Kurs(ComboBox3.Text, vznos, usd, eur, rub).ToString();
                //SummItogo();
            }
        }

        void SummItogo(string valuta)
        {
            /*double UsdSum = 0,UsdCars=0;
            double VznosSum = 0, KgsSUM = 0, UsdCarsSum = 0;
            if (textbox_Summ.Text != "")
                UsdSum = Convert.ToDouble(textbox_Summ.Text);
            if (textBox_vz.Text != "")
                vznos = Convert.ToDouble(textBox_vz.Text);
           if (textboxCarsUsd.Text != "")
                UsdCars = Convert.ToDouble(textboxCarsUsd.Text);
            label_summ_Dol_itog.Content = String.Format("{0:C}", UsdSum - (vznos + UsdCars)) + " $";

            if (textbox_summ.Text != "")
                KgsSUM = Convert.ToDouble(textbox_summ.Text);
            if (textbox_Som_vz2.Text != "")
                VznosSum = Convert.ToDouble(textbox_Som_vz2.Text);
            if (textboxCarsKGS.Text != "")
                UsdCarsSum = Convert.ToDouble(textboxCarsKGS.Text);
*/
            //label_summ_Som_itog.Content = String.Format("{0:C}", KgsSUM - (VznosSum + UsdCarsSum))+" Сом";
            //label_summ_Som_itog.Content = raschetSum.ReaderBasa(valuta,KgsSUM,IdCarsCurs);
           // textboxCarsKGS.Text = raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
            //textboxCarsKGS.Text = raschetSum.ReaderBasa(ComboBox3.Text,Convert.ToDouble(UsdCars), IdCarsCurs).ToString();

        }

        private void textboxCarsUsd_TextChanged(object sender, TextChangedEventArgs e)
        {
            //textboxCarsKGS.Text = raschetSum.ReaderBasa(ComboBox3.Text,Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
            //SummItogo();
        }

        private void textbox_Dol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox_Dol.Text != "") { 

            if (label_kvm.Text != "") { 
                m2 = Convert.ToDouble(label_kvm.Text);
            sena = Convert.ToDouble(textbox_Dol.Text);
            summ = m2 * sena;
            textbox_Summ.Text = summ.ToString();
            }
            else
                m2 = 0;
            if (currency_id != "0") { 
                textbox_m2.Text = Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub));
            textbox_summ.Text = raschetSum.Kurs(ComboBox3.Text, summ, usd, eur, rub).ToString();
            }
               // SummItogo();
            }
        }

        private void btn_valuta_Click(object sender, RoutedEventArgs e)
        {   

            Kurs kurs = new Kurs();
            kurs.del_+=(nid,nusd,neur,nrub )=> {
                currency_id = nid;
                usd = Convert.ToDouble( nusd.Replace('.',','));
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
            textbox_m2.Text =Convert.ToString(raschetSum.Kurs(ComboBox3.Text, sena, usd, eur, rub) );
            textbox_summ.Text = raschetSum.Kurs(ComboBox3.Text, summ, usd, eur, rub).ToString();
            if (textBox_vz.Text != "")
                vznos = Convert.ToDouble(textBox_vz.Text);
            else vznos = 0;

            textbox_Som_vz2.Text = raschetSum.Kurs(ComboBox3.Text, vznos, usd, eur, rub).ToString();

            // MessageBox.Show();
            textboxCarsKGS.Text = raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString();
            MessageBox.Show(ComboBox3.Text+"--"+ KgsCars+"--"+ IdCarsCurs);
            MessageBox.Show(raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString());
            LangName = lanG.ReturnName(ComboBox3.Text);
            l1.Content = LangName[1];
            l2.Content = LangName[1];
            l3.Content = LangName[1];
            l4.Content = LangName[1];
            l12.Content = LangName[2];
            l22.Content = LangName[2];
            l32.Content = LangName[2];
            l42.Content = LangName[2];
            li2.Content= LangName[2]+":";
            li1.Content=LangName[1]+":";
            textboxCarsUsd.Text= raschetSum.ReaderBasa(ComboBox3.Text, Convert.ToDouble(KgsCars), IdCarsCurs).ToString();
            textboxCarsKGS.Text= raschetSum.ReaderBasa2(ComboBox3.Text, Convert.ToDouble(UsdCars), IdCarsCurs).ToString();
            // SummItogo();
        }

        string[] LangName = new string[3];
        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            dbCon2.eventDysplay += delegate (DataTable db)
            {
                kvm = db.Rows[0][0].ToString();

            };
            dbCon2.SoursData("SELECT  sum(kvm) FROM flat join type_flat on flat.dom_id = type_flat.dom_id and " +
                "                flat.porch = type_flat.porch and flat.room = type_flat.room and flat.number_f = '"+ComboBox2.Text+"'" +
                "                and flat.type_flat = type_flat.`type` ");
            if (kvm == "")
                label_kvm.Text = "";
            label_kvm.Text = kvm;



        }

    }
}
