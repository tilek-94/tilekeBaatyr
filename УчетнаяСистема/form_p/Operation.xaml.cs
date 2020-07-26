using System.Data;
using System.Windows;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for Operation.xaml
    /// </summary>
    public partial class Operation : Window
    {

        public Operation()
        {
            InitializeComponent();
        }
        public delegate void MessageDel(string s);
        public event MessageDel del;
        dbConnect dbCon = new dbConnect();
        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text!="") { 
            dbCon.Registr("INSERT INTO operation (name) VALUE('"+text1.Text+"')");
            RegistData("SELECT * FROM operation WHERE remov='0'");
            }
        }

        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        string id_1 = "",NameO="";
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
                    messageO.TableBasa = "operation";
                    messageO.del_ += () => RegistData("SELECT * FROM operation WHERE remov='0'");
                    messageO.ShowDialog();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM operation WHERE remov='0'");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                NameO = dataRow.Row.ItemArray[1].ToString();
                if (id_1 != "")
                {
                    del(NameO);
                    this.Close();

                }
            }
        }
    }
}
