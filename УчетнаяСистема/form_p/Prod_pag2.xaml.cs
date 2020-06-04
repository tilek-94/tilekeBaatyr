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
            dbCon.SoursData("SELECT * FROM zakaz_z ");

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
            view_Year.ShowDialog();
        }

        private void registr_client_btn_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO zakaz(dom_id,klient_id,number_f,cars_id,contract,price_kvm,kurs,kvm) " +
                  "values('6','" + client_id + "','" + ComboBox2.Text + "','" + cars_id + "','" + textbox_dogovor.Text + "','"+ sena_kvm.Replace(',','.') + "'" +
                  ",'"+kurs.Replace(',', '.') + "','"+kvm.Replace(',', '.') + "')");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT zakaz.id, dom.name as 'Дом',client.name as 'Клиент', " +
                "cars.marka as 'Машина марка', zakaz.number_f as 'Номер квартира', " +
                " zakaz.contract as 'Контракт', zakaz.kvm as 'Квадрат м.'," +
                "zakaz.price_kvm as 'Цена за 1 кв. м.', zakaz.kurs as 'Курс валюта'," +
                " zakaz.price_kvm * zakaz.kvm as 'Цена кв. доллар'," +
                " ROUND((zakaz.price_kvm * zakaz.kvm) * zakaz.kurs, 2) as 'Цена кв. сом'" +
                " FROM zakaz JOIN dom JOIN client JOIN cars ON dom.id = zakaz.dom_id and " +
                "zakaz.klient_id = client.id and zakaz.cars_id = cars.id; ");

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

        string sena_kvm = "", kurs = "", kvm = "", summa = "", summa_kg = "";
        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {           
            dbCon2.eventDysplay += delegate (DataTable db)
            {
                sena_kvm=db.Rows[0][0].ToString();
                kurs = db.Rows[0][1].ToString();
                kvm = db.Rows[0][2].ToString();
                summa = db.Rows[0][3].ToString();
                summa_kg = db.Rows[0][4].ToString();
            };
            dbCon2.SoursData("SELECT  sena_kvm,kurs,sum(kvm), sena_kvm*sum(kvm),ROUND((sena_kvm*kurs)*sum(kvm),2) FROM " +
                "flat join type_flat on flat.dom_id = type_flat.dom_id and " +
                "flat.porch = type_flat.porch and flat.room = type_flat.room and flat.number_f = '"+ ComboBox2.Text+ "' " +
                "and flat.type_flat = type_flat.`type`  ");
            label_kvm.Content = kvm;
            label_sena.Content = summa;
            label_kurs.Content = kurs;
            label_summ.Content = summa_kg;
        }

    }
}
