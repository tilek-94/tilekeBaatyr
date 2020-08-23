using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for OrganizationP.xaml
    /// </summary>
    public partial class OrganizationP : UserControl
    {
        public OrganizationP()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();

        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM organization WHERE remov='0'");
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
                    messageO.TableBasa = "organization";
                    messageO.del_ += () => RegistData("SELECT * FROM organization WHERE remov='0'");
                    messageO.ShowDialog();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Organization organization = new Organization();
            organization.del += () =>
            {
                RegistData("SELECT * FROM organization WHERE remov='0'");
            };
            organization.ShowDialog();
        }

        private void textSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegistData("SELECT * FROM organization  WHERE remov='0' AND  " +
                "(name LIKE '%" + textSerch.Text + "%' OR direct LIKE '%" + textSerch.Text + "%')");

        }
    }
}
