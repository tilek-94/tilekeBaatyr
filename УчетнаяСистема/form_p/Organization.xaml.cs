using System.Data;
using System.Windows;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for Organization.xaml
    /// </summary>
    public partial class Organization : Window
    {
        public Organization()
        {
            InitializeComponent();
        }
        public delegate void MessageDel();
        public delegate void MessageDel2(string s);
        public event MessageDel del;
        public event MessageDel2 del2;
        dbConnect dbCon = new dbConnect();
       
        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if(text1.Text!="" && text8.Text != "") { 
            dbCon.Registr("INSERT INTO organization(name, pname,inn,data_registr,registr_s,addres,tel,direct)" +
                "VALUES('"+text1.Text+"'," +
                "'" + text2.Text + "'," +
                "'" + text3.Text + "'," +
                "'" + text4.Text + "'," +
                "'" + text5.Text + "'," +
                "'" + text6.Text + "'," +
                "'" + text7.Text + "'," +
                "'" + text8.Text + "')");
            del();
            this.Close();
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните необходимые поля!";
                messageM.ShowDialog();
            }
        }

        string id_1 = "", NameO = "";

        private void textbox_searsh_KeyDown(object sender, KeyEventArgs e)
        {
            RegistData("SELECT * FROM organization  WHERE remov='0' AND  " +
                "(name LIKE '%"+ textbox_searsh.Text + "%' OR direct LIKE '%" + textbox_searsh.Text + "%')");
        }

        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM organization WHERE remov='0' ");
        }

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

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    if (del2 != null) {
                        del2(NameO);
                    this.Close();
                    }

                }
            }
        }
    }
}
