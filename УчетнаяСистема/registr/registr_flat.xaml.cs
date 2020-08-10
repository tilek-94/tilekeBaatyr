using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.registr
{
    /// <summary>
    /// Логика взаимодействия для registr_flat.xaml
    /// </summary>
    public partial class registr_flat : Window
    {
        public DataSet ProjectTable { get; set; }
        public registr_flat()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        dbConnect dbCon2 = new dbConnect();
        string[] s;

        private void RegistData()
        {
            
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView2.ItemsSource = db.DefaultView;
               
            };
            dbCon.SoursData("select id, number_f ,floor , porch ,type_flat  from flat WHERE remov='0'and dom_id='"+staticClass.StaticDomID+"' ");

        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='" + staticClass.StaticDomID + "'");
         
            for (int i = 1; i <= Convert.ToInt16(s[0]); i++)
            {
                ComboBox_E.Items.Add(i.ToString());
                
            }

            for (int i = 1; i <= Convert.ToInt16(s[1]); i++)
            {
                ComboBox_P.Items.Add(i.ToString());

            }
            
            DelegATE(Convert.ToInt16(s[2]));
            RegistData();


        }
        private void DelegATE(int f)
        {
            ComboBox_kv.Items.Clear();
            dbCon.eventDysplay2 += delegate (string[] a)
            {
                
                for (int  i = 1; i <= f; i++)
                {
                    if (Array.IndexOf(a, i.ToString()) < 0)
                        ComboBox_kv.Items.Add(i.ToString());
                }
            };
            dbCon.Display("SELECT number_f FROM flat WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            
                if (staticClass.StaticDomID!="0" && ComboBox_E.Text!="" && ComboBox_P.Text!="" && ComboBox_flat.Text!="" && ComboBox_t.Text!="" && ComboBox_kv.Text!="") { 
                dbCon.Registr("INSERT INTO flat(dom_id,floor,porch,room,type_flat,number_f) " +
                  "values('" + staticClass.StaticDomID + "','" + ComboBox_E.Text + "','" + ComboBox_P.Text + "','" + ComboBox_flat.Text + "','" +ComboBox_t.Text + "','" + ComboBox_kv.Text + "')");

                RegistData();

                DelegATE(Convert.ToInt16(s[3]));
                }


            

        }


        private void btn_open_reg_typ_Click(object sender, RoutedEventArgs e)
        {
            registr_type_flat registr_Type_Flat = new registr_type_flat();
            registr_Type_Flat.ShowDialog();
        }

        private void ComboBox_t_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dbConnect dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT name,kvm from properties_flat" +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "'" +
                " and type_f='" + ComboBox_t.SelectedItem.ToString() + "' and room='" + ComboBox_flat.Text + "'");
        }

      

        private void ComboBox_P_DropDownClosed(object sender, EventArgs e)
        {

            ComboBox_flat.Items.Clear();
            dbConnect dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for (int i = 0; i <db.Rows.Count; i++)
                {
                    ComboBox_flat.Items.Add(db.Rows[i][0].ToString());

                }


            };
           dbCon.SoursData("SELECT room FROM type_flat WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "' GROUP BY room");

        }

        private void ComboBoxk_kom_DropDownClosed(object sender, EventArgs e)
        {

            ComboBox_t.Items.Clear();
            dbConnect dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for (int i = 0; i < db.Rows.Count; i++)
                {
                    ComboBox_t.Items.Add(db.Rows[i][0].ToString());

                }


            };

            dbCon.SoursData(" SELECT type FROM type_flat WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "' and room='" + ComboBox_flat.Text + "' GROUP BY type;");

        }

        private void ComboBox_t_DropDownClosed(object sender, EventArgs e)
        {
            Display();
        }

        void Display()
        {
            dbCon2.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon2.SoursData("SELECT name,kvm FROM type_flat" +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_t.Text + "' and room='" + ComboBox_flat.Text + "'");

            TextBlock_kvm.Text = "Всего: " + dbCon2.DisplayReturn("SELECT SUM(kvm) FROM type_flat " +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_t.Text + "' and room='" + ComboBox_flat.Text + "'") + " кв. м.";

        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {
            columnIndex = dataGridView2.CurrentColumn.DisplayIndex;
            if (columnIndex == 5)
            {
                DataRowView dataRow = (DataRowView)dataGridView2.SelectedItem;
                if (dataRow != null)
                {
                    id_1 = dataRow.Row.ItemArray[0].ToString();
                    MessageO messageO = new MessageO();
                    if (id_1 != "")
                    {
                        messageO.Id = id_1;
                        messageO.TableBasa = "flat";
                        messageO.del_ += () => RegistData();
                        messageO.ShowDialog();
                    }
                }
            }
        }
        int columnIndex=0;
        string id_1;
        

        

        private void type_flat_listwiew_KeyUp(object sender, KeyEventArgs e)
        {
            DataRowView dataRow = (DataRowView)type_flat_listwiew.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
            }
        }

        private void butCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView2.ItemsSource = db.DefaultView;

            };
            dbCon.SoursData("select id, number_f ,floor , porch ,type_flat  from flat " +
                "WHERE number_f LIKE'%"+ SearshData.Text+ "%' && remov='0'and dom_id='" + staticClass.StaticDomID + "' ");

        }
    }
    
}
