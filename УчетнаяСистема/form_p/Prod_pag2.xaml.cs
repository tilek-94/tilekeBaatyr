using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.form_p;

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
        int cars_id = 0;
        int client_id = 0;
        double summ_cars = 0;
        double kurs_cars = 0;

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
            search_Cars2.mes_ += (x,  y,  summ, kurs)=>
            {
                
                cars_id = Convert.ToInt32(x);
                summ_cars = Convert.ToDouble(summ);
                kurs_cars = Convert.ToDouble(kurs);
                textbox_cars.Text = y;

            };
            search_Cars2.ShowDialog();
        }

        string  kvm = "";
        double dollar = 0,kurs=0,som=0;

        private void textbox_kurs_KeyUp(object sender, KeyEventArgs e)
        {/*
            if (textbox_kurs.Text != "" && textbox_Dol.Text!="" )
            {
                dollar = Convert.ToDouble(textbox_Dol.Text);
                kurs = Convert.ToDouble(textbox_kurs.Text);
                som = dollar * kurs;
                textbox_Som.Text = Convert.ToString(som);
            }else if (textbox_kurs.Text != "" && textbox_Som.Text != "" )
            {
                dollar = Convert.ToDouble(textbox_Som.Text);
                kurs = Convert.ToDouble(textbox_kurs.Text);
                som = dollar * kurs;
                textbox_Dol.Text = Convert.ToString(som);
            }
            if (kvm != "") { 
            label_summ_Dol.Content = Convert.ToString(Convert.ToDouble(kvm)* dollar);
            label_summ_Som.Content = Convert.ToString((Convert.ToDouble(kvm)* dollar)*kurs);

            label_summ_Dol_itog.Content = Convert.ToString((Convert.ToDouble(kvm) * dollar)-summ_cars)+" $";
            label_summ_Som_itog.Content = Convert.ToString(((Convert.ToDouble(kvm) * dollar) * kurs)-(summ_cars*kurs_cars))+" Сом";
                label_summ_Cars.Content = summ_cars.ToString();
            }
*/
        }
        string data_n = "",data_k="";

        private void Calendar2_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
           // data_k = Calendar2.DisplayDate.ToString("yyyy-MM-dd");
        }

        private void textbox_Dol_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
           // data_n = Calendar1.DisplayDate.ToString("yyyy-MM-dd");
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textbox_cars_Copy1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        string[] LangName = new string[3];
        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            /*TextBlock_kvm.Text = "Всего: " + dbCon2.DisplayReturn("SELECT SUM(kvm) FROM type_flat " +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_t.Text + "' and room='" + ComboBox_flat.Text + "'") + " кв. м.";
*/

            /*
            lang lanG = new lang();
           LangName =lanG.ReturnName(ComboBox3.Text);
            l1.Content = LangName[1];
            l2.Content = LangName[1];
            l3.Content = LangName[1];
            l4.Content = LangName[1];
            l12.Content = LangName[2];
            l22.Content = LangName[2];
            l32.Content = LangName[2];
            l42.Content = LangName[2];
            li2.Content= LangName[2]+":";
            li1.Content=LangName[1]+":";*/
            //MessageBox.Show(LangName[1]+" "+ LangName[2]);


        }

    }
}
