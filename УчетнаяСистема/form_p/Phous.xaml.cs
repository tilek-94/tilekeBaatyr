using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.otchet;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for Phous.xaml
    /// </summary>
    public partial class Phous : UserControl
    {
        public Phous()
        {
            InitializeComponent();
        }
        dbConnect dbCon; 
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            ProdBclass prodPhous = new ProdBclass();
            prodPhous.del_ += () => Display();
            prodPhous.ShowDialog();
        }
        string id_1;
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
                    messageO.TableBasa = "prodbclass";
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
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT p.id as pid, bi.id,bi.name,cl.name as client, " +
                "if ((`p`.`typev` = '(KGS)'), round((`p`.price / `cur`.`usd`),2),`p`.price) AS `price_usd`," +
                "if ((`p`.`typev` = '(USD)'),round((`p`.price * `cur`.`usd`),2),`p`.price) AS `price_kgs`, " +
                "if ((`p`.`typev` = '(KGS)'), round((`p`.summ / `cur`.`usd`),2),`p`.summ) AS `summ_usd`, " +
                "if ((`p`.`typev` = '(USD)'),round((`p`.summ * `cur`.`usd`),2),`p`.summ) AS `summ_kgs`, " +
                "p.`data`,u.name as emp, cl.id as cl_id FROM bisnesclass bi LEFT JOIN ( prodbclass p INNER JOIN client c INNER JOIN currency cur " +
                "INNER JOIN client cl INNER JOIN users u) " +
                "ON p.client_id = c.id AND p.kurs = cur.id " +
                "AND p.number_id = bi.id AND p.client_id = cl.id AND p.emp = u.id AND p.remov = '0' WHERE bi.dom_id = '"+staticClass.StaticDomID+"'");

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentColumn.DisplayIndex;

            if ( columnIndex==2)
            {
                viewPeopleinAnalis peopleinAnalis = new viewPeopleinAnalis();


                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null)
                {
                    if (dataRow.Row.ItemArray[9].ToString() != "")
                    {
                        string ClientId = dataRow.Row.ItemArray[9].ToString();
                        peopleinAnalis.ClientID = ClientId;
                        peopleinAnalis.ShowDialog();
                    }
                }
            }
            
        }

        private void textbox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("123");
        }
    }
}
