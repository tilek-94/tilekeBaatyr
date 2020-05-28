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
        int cars_id = 0;
        int client_id = 0;
        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("select * from zakaz");

           string[] s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            DelegATE(Convert.ToInt32( s[3]));
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
            view_Year.ShowDialog();
        }

        private void registr_client_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO zakaz(dom_id,klient_id,number_f,cars_id,contract,price_kvm,kurs) " +
                  "values('6','" + client_id + "','" + ComboBox2.Text + "','" + cars_id + "','" + textbox_dogovor.Text + "','"+ textbox_summa .Text+ "','"+ textbox_kusr.Text+ "')");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("select * from zakaz");

        }

        private void show_client_btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
          window1.ValueChanged += new Action<string,string>((x,y) =>//подписываемся на событие
            {
                client_id = Convert.ToInt32(x);
                FIO.Text = y;

            });
            window1.ShowDialog();
        }

        private void show_client_Cars_Click(object sender, RoutedEventArgs e)
        {

            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.mes_ += delegate (string x, string y)
            {
                cars_id = Convert.ToInt32(x);
                textbox_cars.Text = y;

            };
            search_Cars2.ShowDialog();
        }

        private void address_Copy1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        double summa = 0,kurs=0,som=0;

        private void textbox_som_MouseUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void textbox_kusr_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void textbox_kusr_KeyUp(object sender, KeyEventArgs e)
        {
            if (textbox_kusr.Text != "") { 
            summa = Convert.ToDouble(textbox_summa.Text);
            kurs = Convert.ToDouble(textbox_kusr.Text);
            som = summa * kurs;
            textbox_som.Text = Convert.ToString(som);
            }

        }

        private void textbox_som_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void textbox_kusr_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
