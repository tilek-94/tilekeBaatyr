using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.otchet;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for Parking.xaml
    /// </summary>
    public partial class Parking : UserControl
    {
        public Parking()
        {
            InitializeComponent();
        }
        dbConnect dbCon;
        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            ProdPar prodPar = new ProdPar();
            prodPar.ShowDialog();
        }
        string id_1 = "";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)myDataGrid.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "prod_parking";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }

        }

        void Display()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                myDataGrid.DataContext = db;
            };
            dbCon.SoursData("SELECT * FROM _prod_parking");

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }


        private void dataGridView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int columnIndex = myDataGrid.CurrentColumn.DisplayIndex;

            if (columnIndex == 4)
            {
                viewPeopleinAnalis peopleinAnalis = new viewPeopleinAnalis();


                DataRowView dataRow = (DataRowView)myDataGrid.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[10].ToString() != "")
                    {
                        string ClientId = dataRow.Row.ItemArray[10].ToString();
                        peopleinAnalis.ClientID = ClientId;
                        peopleinAnalis.ShowDialog();
                    }
                }
            }
            else if (columnIndex == 5)
            {

                DataRowView dataRow = (DataRowView)myDataGrid.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[11].ToString() != "")
                    {
                        ViewCarsinAnalise viewCarsinAnalise = new ViewCarsinAnalise();
                        string CarsId = dataRow.Row.ItemArray[11].ToString();
                        viewCarsinAnalise.SqlQury = CarsId;
                        viewCarsinAnalise.ShowDialog();
                    }
                }
            }
            else
            if (columnIndex > 5 && columnIndex<10)
            {
                ViewGrafParking viewGrafParking = new ViewGrafParking();


                DataRowView dataRow = (DataRowView)myDataGrid.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[0].ToString() != "")
                    {
                        string ClientId = dataRow.Row.ItemArray[10].ToString();
                        viewGrafParking.NumberF = dataRow.Row.ItemArray[1].ToString();
                        string marka_1 = dataRow.Row.ItemArray[0].ToString();
                        viewGrafParking.ZakazId= marka_1;
                        viewGrafParking.ClientId = ClientId;
                        viewGrafParking.ShowDialog();
                    }
                }
            }


        }
    }
}

