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
            dbCon.SoursData("SELECT * FROM display WHERE dom_id='"+staticClass.StaticDomID+"'");

        }

        private void dataGridView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int columnIndex =  dataGridView1.CurrentColumn.DisplayIndex;
            
            if (columnIndex>0 && 4> columnIndex)
            {
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                string marka_1 = dataRow.Row.ItemArray[0].ToString();
                viewFlat view_lat = new viewFlat();
                view_lat.sqlQery = "SELECT t.name, t.kvm, f.floor,f.porch,f.number_f FROM flat f inner join " +
                    "type_flat t on t.dom_id = '"+ staticClass.StaticDomID + "' and t.porch = f.porch " +
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
