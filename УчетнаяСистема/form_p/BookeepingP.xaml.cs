using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.otchet;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for BookeepingP.xaml
    /// </summary>
    public partial class BookeepingP : UserControl
    {
        public BookeepingP()
        {
            InitializeComponent();
        }
        dbConnect dbCon;
        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            Bookeeping bookeeping = new Bookeeping();
            bookeeping.Flag = 1;
            bookeeping.del += () => RegistDataP("SELECT * FROM _prihod");
           bookeeping.ShowDialog();
        }
        private void RegistData(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                myDataGrid2.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void RegistDataP(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                myDataGrid.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void ReadSum()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                itogUSD.Text = "$ " + db.Rows[0][0].ToString();
                itogKGS.Text = db.Rows[0][1].ToString()+" Сом";
            };
            dbCon.SoursData("SELECT ROUND(SUM(to_usd),2),ROUND(SUM(Rto_kgs),2) FROM otchetprihod");

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            RegistData("SELECT r.id,r.operationU,r.organ, " +
                "if ((`r`.`typev` = '(KGS)'), round((`r`.summa / `cur`.`usd`),2),`r`.summa) AS `to_usd`, " +
                "if ((`r`.`typev` = '(USD)'),round((`r`.summa * `cur`.`usd`),2),`r`.summa) AS `Rto_kgs`, " +
                "r.`data` ,u.name AS users,(SELECT name FROM users WHERE id = r.remov) AS remov " +
                "FROM(rashod r INNER JOIN currency cur) INNER JOIN users u  ON r.kurs = cur.id AND r.sotrud = u.id AND r.remov='0'; ");
            RegistDataP("SELECT * FROM _prihod");
            ReadSum();


        }
        string id_1 = "";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)myDataGrid2.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "rashod";
                    messageO.del_ += () => RegistData("SELECT r.id,r.operationU,r.organ, " +
                "if ((`r`.`typev` = '(KGS)'), round((`r`.summa / `cur`.`usd`),2),`r`.summa) AS `to_usd`, " +
                "if ((`r`.`typev` = '(USD)'),round((`r`.summa * `cur`.`usd`),2),`r`.summa) AS `Rto_kgs`, " +
                "r.`data` ,u.name AS users,(SELECT name FROM users WHERE id = r.remov) AS remov " +
                "FROM(rashod r INNER JOIN currency cur) INNER JOIN users u  ON r.kurs = cur.id AND r.sotrud = u.id AND r.remov='0';");
                    messageO.ShowDialog();
                }
            }
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            Bookeeping bookeeping = new Bookeeping();
            bookeeping.Flag = 2;
            bookeeping.del += () => RegistData("SELECT r.id,r.operationU,r.organ, " +
                "if ((`r`.`typev` = '(KGS)'), round((`r`.summa / `cur`.`usd`),2),`r`.summa) AS `to_usd`, " +
                "if ((`r`.`typev` = '(USD)'),round((`r`.summa * `cur`.`usd`),2),`r`.summa) AS `Rto_kgs`, " +
                "r.`data` ,u.name AS users,(SELECT name FROM users WHERE id = r.remov) AS remov " +
                "FROM(rashod r INNER JOIN currency cur) INNER JOIN users u  ON r.kurs = cur.id AND r.sotrud = u.id AND r.remov='0'; ");
            bookeeping.ShowDialog();
        }

      }
}
