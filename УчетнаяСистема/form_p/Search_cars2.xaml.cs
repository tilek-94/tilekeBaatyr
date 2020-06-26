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
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Search_cars2.xaml
    /// </summary>
    public partial class Search_cars2 : Window
    {
        public Search_cars2()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        public delegate void MessageID(string id, string name,string summa,string kurs);
        public event MessageID mes_;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO cars(marka,data,nomer,prih_summ,kurs,info)" +
                "values (" +
                "'" + marka.Text + "'," +
                "'" + data.Text + "'," +
                "'"+ nomer.Text + "'," +
                "'" + prih_summ.Text + "'," +
                "'" + kurs.Text + "'," +
                "'" + info.Text + "')");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM cars");
        }

        private void myDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM cars");

        }
        string id_1 = "", marka_1, prih_summ_1="", kurs_1="";

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridColumnEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].Column.DisplayIndex;
        }

        private void dataGridView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            int index = dataGridView1.CurrentCell.Column.DisplayIndex;
             id_1 = dataRow.Row.ItemArray[0].ToString();
             marka_1 = dataRow.Row.ItemArray[1].ToString();
            string data_1 = dataRow.Row.ItemArray[2].ToString();
            string nomer_1 = dataRow.Row.ItemArray[3].ToString();
             prih_summ_1 = dataRow.Row.ItemArray[4].ToString();
             kurs_1 = dataRow.Row.ItemArray[5].ToString();
            string info_1 = dataRow.Row.ItemArray[6].ToString();
            /*,data,nomer,prih_summ,kurs,info;*/
            marka.Text = marka_1;
            data.Text = data_1;
            nomer.Text = nomer_1;
            prih_summ.Text = prih_summ_1;
            kurs.Text = kurs_1;
            info.Text = info_1;
        }

        private void button_vbor_Click(object sender, RoutedEventArgs e)
        {
            mes_(id_1,marka_1, prih_summ_1, kurs_1);
            this.Close();
        }
    }
}
