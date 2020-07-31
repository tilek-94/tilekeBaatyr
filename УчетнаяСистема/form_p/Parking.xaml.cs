using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

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
                    messageO.TableBasa = "parking";
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
            dbCon.SoursData("SELECT p.id, p.remov,p.client_id, p.cars_id , p.dom_id,p.NUMBER, " +
                "(SELECT NAME FROM client WHERE client.id = p.client_id) AS client, " +
                "if ((`p`.cars_id <> ''),'Имеиит','') AS `Cars`, " +
                "if ((`p`.`typev` = '(KGS)'), round((`p`.itogPrice / `cur`.`usd`),2),`p`.itogPrice) AS `to_usd`, " +
                "if ((`p`.`typev` = '(USD)'),round((`p`.itogPrice * `cur`.`usd`),2),`p`.itogPrice) AS `Rto_kgs`, " +
                "if ((`p`.`typev` = '(KGS)'), round((`p`.zadol / `cur`.`usd`),2),`p`.zadol ) AS `dolg`, " +
                "if ((`p`.`typev` = '(USD)'),round((`p`.zadol * `cur`.`usd`),2),`p`.zadol ) AS `dolg2`, p.`data`,( SELECT name FROM users WHERE id= p.emp) AS empl " +
                "FROM parking p join currency cur ON p.curr_id = cur.id WHERE p.dom_id = '21' and remov = '0'");

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
                    if (dataRow.Row.ItemArray[2].ToString() != "")
                    {
                        string ClientId = dataRow.Row.ItemArray[2].ToString();
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
                    if (dataRow.Row.ItemArray[3].ToString() != "")
                    {
                        ViewCarsinAnalise viewCarsinAnalise = new ViewCarsinAnalise();
                        string CarsId = dataRow.Row.ItemArray[3].ToString();
                        viewCarsinAnalise.SqlQury = CarsId;
                        viewCarsinAnalise.ShowDialog();
                    }
                }
            }



        }
    }
}

