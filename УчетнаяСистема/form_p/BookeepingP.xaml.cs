using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

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
            bookeeping.del += () => RegistDataP("SELECT * FROM prihod WHERE remov='0'");
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


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            RegistData("SELECT * FROM rashod WHERE remov='0'");
            RegistDataP("SELECT * FROM prihod WHERE remov='0'");


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
                    messageO.del_ += () => RegistData("SELECT * FROM rashod WHERE remov='0'");
                    messageO.ShowDialog();
                }
            }
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            Bookeeping bookeeping = new Bookeeping();
            bookeeping.Flag = 2;
            bookeeping.del += () => RegistData("SELECT * FROM rashod WHERE remov='0' ");
            bookeeping.ShowDialog();
        }
    }
}
