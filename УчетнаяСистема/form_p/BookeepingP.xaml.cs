using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        dbConnect dbCon = new dbConnect();
        dbConnect dbCon2 = new dbConnect();
        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            Bookeeping bookeeping = new Bookeeping();
            bookeeping.Flag = 1;
            bookeeping.del += () => RegistData("SELECT * FROM finance WHERE remov='0' and typeO='1'");
            bookeeping.ShowDialog();
        }
        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                myDataGrid.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            RegistData("SELECT * FROM finance WHERE remov='0' and typeO='1'");


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
                    messageO.TableBasa = "finance";
                    messageO.del_ += () => RegistData("SELECT * FROM finance WHERE remov='0' and typeO='1'");
                    messageO.ShowDialog();
                }
            }
        }
    }
}
