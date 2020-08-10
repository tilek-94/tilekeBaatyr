using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.otchet;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for RepFlatPage.xaml
    /// </summary>
    public partial class RepFlatPage : UserControl
    {
        public RepFlatPage()
        {
            InitializeComponent();
        }
        dbConnect dbCon;
        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            Bron_Klient bron_Klient = new Bron_Klient();

            bron_Klient.del += () => RegistData("SELECT * FROM _repayment_flat " +
                 "WHERE dom_id= '" + staticClass.StaticDomID + "' ORDER BY id DESC");
            bron_Klient.ShowDialog();
        }

        private void RegistData(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM _repayment_flat " +
                "WHERE dom_id= '" + staticClass.StaticDomID + "' ORDER BY id DESC");
        }

        string id_1 = "";
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
                    messageO.TableBasa = "repayment_parking";
                    messageO.del_ += () => RegistData("SELECT * FROM _repayment_flat " +
                "WHERE dom_id= '" + staticClass.StaticDomID + "' ORDER BY id DESC");
                    messageO.ShowDialog();
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegistData("SELECT * FROM _repayment_flat " +
                "WHERE dom_id= '" + staticClass.StaticDomID + "' and client LIKE  '%" + SearchText.Text+ "%'");
        }
    }
}