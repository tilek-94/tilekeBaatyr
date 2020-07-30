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
        string id_1="";
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
            dbCon.SoursData("SELECT p.id, p.remov, p.dom_id,p.NUMBER,(SELECT NAME FROM client WHERE client.id=p.client_id) AS client," +
                "cars_id, if ((`p`.`typev` = '(KGS)'), round((`p`.`itog` / `cur`.`usd`),2),`p`.`itog`) AS `to_usd`," +
                "if ((`p`.`typev` = '(USD)'),round((`p`.`itog` * `cur`.`usd`),2),`p`.`itog`) AS `Rto_kgs`,p.`data` " +
                "FROM parking p join currency cur ON p.curr_id = cur.id WHERE p.dom_id = '" + staticClass.StaticDomID + "' and remov='0'");

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }
    }
}
