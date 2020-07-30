using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{

    public partial class Window1 : Window
    {
        Open_File file = new Open_File();           
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

        private void Dysplay()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM client  WHERE remov='0'");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM client  WHERE remov='0'");
        }

        private void textbox_searsh_KeyDown(object sender, KeyEventArgs e)
        {
            RegistData("SELECT * FROM client WHERE remov='0' and name LIKE '%" + textbox_searsh.Text + "%' ");
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
                RegistData("SELECT * FROM client WHERE remov='0'");



            }
            else
            {
                MessageBox.Show("Заполниет все неоходимый поле!");
            }
        }
        string id = "0";
        string name = "";
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
                        
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
                if (ValueChanged!=null) 
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }   
         string id_1 = "";
        int columnIndex = 0;
        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            columnIndex = dataGridView1.CurrentColumn.DisplayIndex;
            if (columnIndex == 9)
            {
                DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
                if (dataRow != null)
                {
                    id_1 = dataRow.Row.ItemArray[0].ToString();
                    MessageO messageO = new MessageO();
                    if (id_1 != "")
                    {
                        messageO.Id = id_1;
                        messageO.TableBasa = "client";
                        messageO.del_ += () => Dysplay();
                        messageO.ShowDialog();
                    }
                }
            }

            DataRowView dataRow2 = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow2 != null)
            {
                id = dataRow2.Row.ItemArray[0].ToString();
                name = dataRow2.Row.ItemArray[1].ToString();
            }
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
                    messageO.TableBasa = "client";
                    messageO.del_ += () => Dysplay();
                    messageO.ShowDialog();
                }
            }
        }

    }
}
