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
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    
    public partial class Window1 : Window
    {
        public event Action<string,string> ValueChanged;
        public Window1()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        private void brd_Mov_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
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
            RegistData("SELECT * FROM client");
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textbox_fio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textbox_searsh_KeyDown(object sender, KeyEventArgs e)
        {
            RegistData("SELECT * FROM client WHERE name LIKE '%" + textbox_searsh.Text + "%'");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (FIO.Text != "" && data_r.Text != "" && AN.Text != "" && data_p.Text != "" && vdan.Text != "" && address_p.Text != "" && address.Text != "")
            {
                dbCon.Registr("INSERT INTO client(name,data,tel_nom,AN,data_vdan,vdan_uch,address_pas,address) " +
                  "values(" +
                  "'" + FIO.Text + "'," +
                  "'" + data_r.Text + "'," +
                  "'" + tel_nom.Text + "'," +
                  "'" + AN.Text + "'," +
                  "'" + data_p.Text + "'," +
                  "'" + vdan.Text + "'," +
                  "'" +address_p.Text+"'," +
                  "'" + address.Text + "'" +
                  ")");
                FIO.Text = "";
                data_r.Text = "";
                tel_nom.Text = "";
                AN.Text = "";
                data_p.Text = "";
                vdan.Text = "";
                address_p.Text = "";
                address.Text = "";
                RegistData("SELECT * FROM client");



            }
            else
            {
                MessageBox.Show("Заполниет все неоходимый поле!");
            }
        }
        string id = "0";
        string name = "";
        private void myDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            int index = dataGridView1.CurrentCell.Column.DisplayIndex;
             id = dataRow.Row.ItemArray[0].ToString();
            name = dataRow.Row.ItemArray[1].ToString();
            string data = dataRow.Row.ItemArray[2].ToString();
            string tel = dataRow.Row.ItemArray[3].ToString();
            string AN_data = dataRow.Row.ItemArray[4].ToString();
            string data_v = dataRow.Row.ItemArray[5].ToString();
            string vdan_uch = dataRow.Row.ItemArray[6].ToString();
            string address_pas = dataRow.Row.ItemArray[7].ToString();
            string addr = dataRow.Row.ItemArray[5].ToString();
            FIO.Text = name;
            data_r.Text = data;
            AN.Text = AN_data;
            tel_nom.Text = tel;
            data_p.Text= data_v;
            vdan.Text= vdan_uch;
            address_p.Text = address_pas;
            address.Text = addr;


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (id != "0") { 
           dbCon.Registr("DELETE FROM client WHERE id='"+id+"'");
            RegistData("SELECT * FROM client");
            }
            else
           
                MessageBox.Show("Маалымат тандаңыз");
            
        }

       

        private void select_btn_Click(object sender, RoutedEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
