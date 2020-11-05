using System;
using System.Data;
using System.Windows;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для exchange.xaml
    /// </summary>
    public partial class exchange : Window
    {
        public exchange()
        {
            InitializeComponent();
        }
        dbConnect dbCon; 
                
        int client_id = 0, product_id;
     

        private void view_client_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == true)
            {
                form_p.Window1 window1 = new form_p.Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                text1.Text = y;

            });
            window1.ShowDialog();

           

                
            }
            else
            {
                Organization organization = new Organization();
                organization.del2 += s => text1.Text = s;
                organization.Show();
                }
        }

        private void view_product_btn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new form_p.Product();
            product.ValueChanged += new Action<string, string>((x, y) =>
            {
                product_id = Convert.ToInt32(x);
                text2.Text = y;

            });
            product.ShowDialog();
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.Text!="" ) { 
            dbCon.Registr("INSERT INTO exchange(client_id,product_id,number_f,emp,dom_id)" +
                "VALUES('" + text1.Text + "'," +
                "'" + text2.Text + "'," +
                "'" + ComboBox1.Text + "'," +
                "'" + staticClass.StaticEmplayID + "'," +
                "'" + staticClass.StaticDomID + "')");
                DelegATE();
                Display();
                ComboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Выберите квартиру!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*string[] s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='" + staticClass.StaticDomID + "'");
           */ DelegATE();
            Display();
        }

        private void DelegATE()
        {
            dbCon = new dbConnect();
            ComboBox1.Items.Clear();
            dbCon.eventDysplay += delegate (DataTable db)
            {
               // MessageBox.Show(db.Rows[0][0].ToString());
                  for(int i=0; i < db.Rows.Count;i++) 
                ComboBox1.Items.Add(db.Rows[i][0].ToString());
                
            };

            dbCon.SoursData("SELECT f.number_f FROM flat f WHERE f.number_f " +
                "NOT IN(SELECT e.number_f FROM exchange e WHERE e.remov = '0' " +
                "AND e.dom_id = '"+staticClass.StaticDomID+"') AND f.number_f " + 
                "NOT IN(SELECT z.number_f FROM zakaz z WHERE z.remov = '0' " +
                "AND z.dom_id = '" + staticClass.StaticDomID + "') AND f.number_f " +
                "NOT IN(SELECT b.number_f FROM bron b WHERE b.remov = '0' AND b.dom_id = '" + staticClass.StaticDomID + "') " +
                "AND f.dom_id = '" + staticClass.StaticDomID + "' AND f.remov = '0' ORDER BY number_f ");

        }
        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    messageO.TableBasa = "exchange";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT e.id, e.number_f,e.client_id as name,e.product_id AS tovar, e.`data`, u.name as emp " +
                "FROM exchange e   JOIN  users u ON e.emp = u.id " +
                "WHERE e.remov = '0'  AND e.dom_id = '" + staticClass.StaticDomID + "' AND e.number_f LIKE '%"+ searchText .Text+ "%'");
        }

        void Display()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT e.id, e.number_f,e.client_id as name,e.product_id AS tovar, e.`data`, u.name as emp " +
                "FROM exchange e   JOIN  users u ON e.emp = u.id " +
                "WHERE e.remov = '0'  AND e.dom_id = '"+staticClass.StaticDomID+"'");

        }



    }
}
