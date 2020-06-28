using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;
using fotm_p=УчетнаяСистема.form_p;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for analis.xaml
    /// </summary>
    public partial class analis : Page
    {
        public analis()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT f.number_f, f.floor, " +
                "(SELECT SUM(kvm)  FROM type_flat WHERE dom_id = '6' " +
                "and porch = f.porch and type = f.type_flat and room = f.room) as kvm, " +
                "z.contract, c.name,ca.marka, z.kurs,z.price_kvm, z.price_kvm*z.kurs som, " +
                "z.price_kvm* kvm as us, ROUND((z.price_kvm * z.kurs) * kvm, 2) as kg " +
                "FROM flat f left join((zakaz z join client c) join cars ca )  " +
                "on z.number_f = f.number_f and z.cars_id = ca.id and z.klient_id = c.id ORDER BY f.number_f; ");

        }

        private void dataGridView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int columnIndex =  dataGridView1.CurrentColumn.DisplayIndex;
            
            if (columnIndex>0 && 4> columnIndex)
            {
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                string marka_1 = dataRow.Row.ItemArray[0].ToString();
                viewFlat view_lat = new viewFlat();
                view_lat.sqlQery = "SELECT t.name, t.kvm FROM flat f inner join " +
                    "type_flat t on t.dom_id = '6' and t.porch = f.porch " +
                    "and t.room = f.room and t.`type`= f.type_flat and f.number_f = '"+ marka_1 + "' ";
                view_lat.ShowDialog();


            }
            else if(columnIndex == 5)
            {
                viewPeopleinAnalis peopleinAnalis = new viewPeopleinAnalis();
                peopleinAnalis.ShowDialog();
            }
            else if (columnIndex == 6)
            {
                ViewCarsinAnalise viewCarsinAnalise = new ViewCarsinAnalise();
                viewCarsinAnalise.ShowDialog();
            }
            else if (columnIndex>6)
            {
                view_year View_Year = new view_year();
                //View_Year.ShowDialog();

            }
        }

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridColumnEventArgs e)
        {/*
            int index = dataGridView1.SelectedCells[0].Column.DisplayIndex;
            MessageBox.Show("d");*/
        }
    }
}
