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
    public partial class analis : UserControl
    {
        public analis()
        {
            InitializeComponent();
            
        }

        DataTable db1;
        dbConnect dbCon;
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            Display("SELECT * FROM _zakaz_otchot WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");

        }
        
        private void Display(string s)
        {
            if(db1!=null)
            db1.Clear();
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
                db1 = db;
            };
            dbCon.SoursData(s);

            dbCon = new dbConnect();
            DataRow dr1 = db1.NewRow();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                if (db.Rows.Count > 0 && db.Rows[0][0].ToString() != "")
                {
                    
                    dr1[10] = db.Rows[0][0].ToString();
                    dr1[11] = db.Rows[0][1].ToString();
                    dr1[12] = db.Rows[0][2].ToString();
                    dr1[13] = db.Rows[0][3].ToString();
                    db1.Rows.Add(dr1);
                    dataGridView1.ItemsSource = db1.AsDataView();
                }

            };
            dbCon.SoursData("SELECT ROUND( SUM(to_usd),2),ROUND ( SUM(Rto_kgs),2) " +
                           ", ROUND(SUM(usd), 2), ROUND(SUM(kgs), 2) " +
                           "FROM _zakaz_otchot WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");

        }

        private void dataGridView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int columnIndex =  dataGridView1.CurrentColumn.DisplayIndex;
            
            if (columnIndex>1 && 6> columnIndex)
            {
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                string number_f = dataRow.Row.ItemArray[3].ToString();
               viewFlat view_lat = new viewFlat();
                view_lat.sqlQery = "SELECT t.name, t.kvm, f.floor,f.porch,f.number_f,f.room FROM flat f inner join " +
                    "type_flat t on t.dom_id = '"+ staticClass.StaticDomID + "' AND f.dom_id='" + staticClass.StaticDomID + "' and t.porch = f.porch " +
                    "and t.room = f.room and t.`type`= f.type_flat and f.number_f = '"+ number_f + "' ";
                view_lat.ShowDialog();


            }
            else if(columnIndex == 7)
            {
               viewPeopleinAnalis peopleinAnalis = new viewPeopleinAnalis();
                

                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[16].ToString() != "") {
                        string ClientId = dataRow.Row.ItemArray[16].ToString();
                        peopleinAnalis.ClientID = ClientId;
                        peopleinAnalis.ShowDialog();
                    }
                }
                    }
            else if (columnIndex == 8)
            {
                
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[17].ToString() != "")
                    {
                        ViewCarsinAnalise viewCarsinAnalise = new ViewCarsinAnalise();
                        string CarsId = dataRow.Row.ItemArray[17].ToString();
                        viewCarsinAnalise.SqlQury = CarsId;
                        viewCarsinAnalise.ShowDialog();
                    }
                }
            }
            else if (columnIndex>8)
            {
                view_year View_Year = new view_year();
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null) { 
                    if(dataRow.Row.ItemArray[7].ToString()!="" && 
                        dataRow.Row.ItemArray[8].ToString() != "" && 
                        dataRow.Row.ItemArray[10].ToString() != "" &&
                        dataRow.Row.ItemArray[11].ToString() != "" && 
                        dataRow.Row.ItemArray[12].ToString() != "" &&
                        dataRow.Row.ItemArray[13].ToString() != "") { 
                string marka_1 = dataRow.Row.ItemArray[1].ToString();
                string NumberF = dataRow.Row.ItemArray[3].ToString();
                string ClientId = dataRow.Row.ItemArray[16].ToString();
                    //MessageBox.Show(marka_1);
                    View_Year.ZakazId = marka_1;
                    View_Year.NumberF= NumberF;
                    View_Year.ClientId = ClientId;
                    View_Year.ShowDialog();
                    }
                }
               

            }
        }

        double Total = 0;
        


        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridColumnEventArgs e)
        {   /*
            int index = dataGridView1.SelectedCells[0].Column.DisplayIndex;
            MessageBox.Show("d");*/
        }
        string id_1 = "";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[1].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "zakaz";
                    messageO.del_ += () => Display("SELECT * FROM _zakaz_otchot WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
                    messageO.ShowDialog();
                }
            }
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            Prod_pag2 prod_Pag2 = new Prod_pag2();
            prod_Pag2.del_ += () => Display("SELECT * FROM _zakaz_otchot WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
            prod_Pag2.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Display("SELECT * FROM _zakaz_otchot z " +
                "WHERE dom_id = '"+staticClass.StaticDomID+"' AND " +
                "(z.number_f LIKE '%"+ Search_Text.Text + "%' OR z.contract LIKE '%" + Search_Text.Text + "%' OR z.`client` LIKE '%" + Search_Text.Text + "%' or z.name LIKE '%" + Search_Text.Text + "%') and remov = '0'");
        }
    }
}
