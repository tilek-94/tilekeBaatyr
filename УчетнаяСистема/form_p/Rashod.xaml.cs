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
    /// Interaction logic for Rashod.xaml
    /// </summary>
    public partial class Rashod : Page
    {
        public Rashod()
        {
            InitializeComponent();
        }
        dbConnect dbCon2 = new dbConnect();
        
        private void RegistData2(string s)
        {
            dbCon2.eventDysplay += delegate (DataTable db)
            {
                myDataGrid2.ItemsSource = db.DefaultView;
            };
            dbCon2.SoursData(s);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            RegistData2("SELECT * FROM finance WHERE remov='0' and typeO='2'");
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            Bookeeping bookeeping = new Bookeeping();
            bookeeping.Flag = 2;
            bookeeping.del += () => RegistData2("SELECT * FROM finance WHERE remov='0' and typeO='2'");
            bookeeping.ShowDialog();
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
                    messageO.TableBasa = "finance";
                    messageO.del_ += () => RegistData2("SELECT * FROM finance WHERE remov='0' and typeO='2'");
                    messageO.ShowDialog();
                }
            }
        }
    }
}
