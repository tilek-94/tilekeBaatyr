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
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;
using MySql.Data.MySqlClient;
namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Cars_pag.xaml
    /// </summary>
    public partial class Cars_pag : UserControl
    {
        public Cars_pag()
        {
            InitializeComponent();
            
        }

        int col_Strok = 2;
        int count = 0;
        string id_1 = "";
        int b1 = 1, b2 = 2, b3 = 3, b4 = 4, b5 = 5, b6 = 6, b7 = 7, b8 = 8, b9 = 9, b10 = 10;//нужные переменные
        string SqlQuery1 = "SELECT  CASE " +
            "WHEN(c.remov >0 AND c.prod_cars>0) THEN 'Продан'" +
            " WHEN(c.remov >0 AND c.prod_cars= 0) THEN 'Удален' " +
            "ELSE 'Наличный' " +
            "END AS STATUS, c.id,c.marka,c.data,c.nomer,c.condition_c, " +
            "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd, " +
            "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs, " +
            "(SELECT name FROM client WHERE id = c.client_id) as client,  " +
            "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id " +
            "ORDER BY c.id DESC;";

        string SqlQuery2 = "SELECT c.id,c.marka,c.data,c.nomer,c.condition_c," +
               "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
               "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs," +
               "(SELECT name FROM client WHERE id = c.client_id) as client, " +
               "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov=0 " +
               "ORDER BY  c.id DESC;";

        string SqlQuery3 = "SELECT " +
                " CASE" +
                " WHEN(c.remov > 0 AND c.prod_cars > 0) THEN 'Продан'" +
                " WHEN(c.remov > 0 AND c.prod_cars = 0) THEN 'Удален'" +
                " ELSE 'Наличный'" +
                " END AS STATUS, " +
                " c.id, c.marka, c.data, c.nomer, c.condition_c, " +
                " IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd, " +
                " IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs, " +
                " (SELECT name FROM client WHERE id = c.client_id) as client, " +
                " datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id " +
                " WHERE c.remov > 0 AND c.prod_cars > 0 OR c.remov = 0 " +
                " ORDER BY  c.id DESC; ";

        string SqlQuery4 = "SELECT " +
                " CASE" +
                " WHEN(c.remov > 0 AND c.prod_cars > 0) THEN 'Продан'" +
                " WHEN(c.remov > 0 AND c.prod_cars = 0) THEN 'Удален'" +
                " ELSE 'Наличный'" +
                " END AS STATUS, " +
                " c.id, c.marka, c.data, c.nomer, c.condition_c, " +
                " IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd, " +
                " IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs, " +
                " (SELECT name FROM client WHERE id = c.client_id) as client, " +
                " datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id " +
                " WHERE c.remov > 0 AND c.prod_cars = 0 OR c.remov = 0 " +
                " ORDER BY  c.id DESC; ";

        private void b_1_Click(object sender, RoutedEventArgs e)
        {
            //Viv("SELECT * FROM Test LIMIT " + col_Strok + " OFFSET " + (b1 - 1) * col_Strok + "");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT id,marka,data,nomer,condition_c," +
                "prih_summ, kurs, prih_summ * kurs as summ_som," +
                "(SELECT name FROM client WHERE id = client_id) as client" +
                ",datatim FROM cars LIMIT " + col_Strok + "OFFSET " + (b1) * col_Strok + "");
            if (b1 > 1)
            {
                b1 -= 1;
                b2 -= 1;
                b3 -= 1;
                b4 -= 1;
                b5 -= 1;
                b6 -= 1;
                b7 -= 1;
                b8 -= 1;
                b9 -= 1;
                b10 -= 1;
                b_1.Content = b1;
                b_2.Content = b2;
                b_3.Content = b3;
                b_4.Content = b4;
                b_5.Content = b5;
        
            }
        }

        private void b_10_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
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
                    messageO.TableBasa = "cars";
                    messageO.del_ += () => Display("SELECT c.id,c.marka,c.data,c.nomer,c.condition_c," +
                "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
                "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs," +
                "(SELECT name FROM client WHERE id = c.client_id) as client, " +
                "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov=0 " +
                "ORDER BY  c.id DESC;");
                    messageO.ShowDialog();
                }
            }
        }

        private void btnProdView_Click(object sender, RoutedEventArgs e)
        {
            ColumRemov.Visibility = Visibility.Collapsed;

            if (brnRemovView.IsChecked == true) {
                Display(SqlQuery1);
                ColumStatus.Visibility = Visibility.Visible;
            }

            else {
                 Display(SqlQuery3);
            }


        }

        private void btnProdView_Unchecked(object sender, RoutedEventArgs e)
        {
            

            if (brnRemovView.IsChecked == true)
                Display(SqlQuery4);
            else
            {
                ColumRemov.Visibility = Visibility.Visible;
                Display(SqlQuery2);
                ColumStatus.Visibility = Visibility.Collapsed;
                
            }
        }

        private void dataGridView1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            
         }

        private void brnRemovView_Checked(object sender, RoutedEventArgs e)
        {
            ColumRemov.Visibility = Visibility.Collapsed;

            if (btnProdView.IsChecked == true) { 
                Display(SqlQuery1);
                ColumStatus.Visibility = Visibility.Visible;
               
            }
            else { 
                Display(SqlQuery4);
               
            }

        }

        private void brnRemovView_Unchecked(object sender, RoutedEventArgs e)
        {
            

            if (btnProdView.IsChecked == true)
                Display(SqlQuery3);
            else { 
                Display(SqlQuery2);
                ColumStatus.Visibility = Visibility.Collapsed;
                ColumRemov.Visibility = Visibility.Visible;

            }

        }

        private void b_2_Click(object sender, RoutedEventArgs e)
        {

            //dViv("SELECT * FROM Test LIMIT " + col_Strok + " OFFSET " + (Convert.ToInt32((sender as Button).Content.ToString()) - 1) * col_Strok + "");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT id,marka,data,nomer,condition_c," +
                "prih_summ, kurs, prih_summ * kurs as summ_som," +
                "(SELECT name FROM client WHERE id = client_id) as client" +
                ",datatim FROM cars LIMIT " + col_Strok + " OFFSET " + (Convert.ToInt32((sender as Button).Content.ToString()) - 1) * col_Strok + "");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

        }

        dbConnect dbCon = new dbConnect();
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display("SELECT c.id,c.marka,c.data,c.nomer,c.condition_c," +
                "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
                "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs," +
                "(SELECT name FROM client WHERE id = c.client_id) as client, " +
                "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov=0 " +
                "ORDER BY  c.id DESC;");
            count = dbCon.DisplayReturn1("select count(*) from cars");
        }
        void Display(string SqlQuruy)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData(SqlQuruy);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.flag = true;
            search_Cars2.Height = 335;
            search_Cars2.clDel+=()=> Display(SqlQuery2);
            search_Cars2.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
            DataGrid dt = sender as DataGrid;
            DataRowView selection = dt.SelectedItem as DataRowView;
            if (selection != null)
            {
                dbCon.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("select img from dom where id='"+selection["id"]+"'", dbCon.connection))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                            }
                        }

                    }

                }
                dbCon.connection.Close();
                dbCon.connection.Dispose();
            }*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Name== "Right")
            {               
                int asd = count / col_Strok;
                if (count % col_Strok != 0) { asd = (count / col_Strok) + 1; }
                if (b10 < asd)
                {
                    b1 += 1;
                    b2 += 1;
                    b3 += 1;
                    b4 += 1;
                    b5 += 1;
                    b6 += 1;
                    b7 += 1;
                    b8 += 1;
                    b9 += 1;
                    b10 += 1;
                    b_1.Content = b1;
                    b_2.Content = b2;
                    b_3.Content = b3;
                    b_4.Content = b4;
                    b_5.Content = b5;
                
                }
            }
            else
            {
                if (b1 > 1)
                {
                    b1 -= 1;
                    b2 -= 1;
                    b3 -= 1;
                    b4 -= 1;
                    b5 -= 1;
                    b6 -= 1;
                    b7 -= 1;
                    b8 -= 1;
                    b9 -= 1;
                    b10 -= 1;
                    b_1.Content = b1;
                    b_2.Content = b2;
                    b_3.Content = b3;
                    b_4.Content = b4;
                    b_5.Content = b5;
            
                }
            }


        }
    }
}
