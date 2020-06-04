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
using System.IO.Packaging;

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

        private void RegistData(string s)
        {
            
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView2.ItemsSource = db.DefaultView;
               // dataGridView2.Columns[0].Width=-1;
                
            };
            dbCon.SoursData(s);

        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            //MessageBox.Show("1");

            for (int i = 1; i <= Convert.ToInt16(s[0]); i++)
            {
                ComboBox_E.Items.Add(i.ToString());
                
            }

            for (int i = 1; i <= Convert.ToInt16(s[1]); i++)
            {
                ComboBox_P.Items.Add(i.ToString());

            }
            
            DelegATE(Convert.ToInt16(s[2]));
            RegistData("select id, number_f as 'Номер квартира',floor as 'Этаж', porch as 'Подъезд',type_flat as 'Тип картира' from flat");


        }
        private void DelegATE(int f)
        {
            ComboBox_kv.Items.Clear();
            dbCon.eventDysplay2 += delegate (string[] a)
            {
                
                for (int i = 0; i < f; i++)
                {
                    if (Array.IndexOf(a, i.ToString()) < 0)
                        ComboBox_kv.Items.Add(i.ToString());
                }
            };
            dbCon.Display("SELECT number_f FROM flat");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            if (true)
            {

                dbCon.Registr("INSERT INTO flat(dom_id,floor,porch,room,type_flat,number_f,sena_kvm,kurs) " +
                  "values('6','" + ComboBox_E.Text + "','" + ComboBox_P.Text + "','" + ComboBox_flat.Text + "','" +ComboBox_t.Text + "','" + ComboBox_kv.Text + "','" + textBox_sena.Text + "','"+ textBox1_valyta.Text + "')");
                
                RegistData("select * from flat");
                
                DelegATE(Convert.ToInt16(s[3]));


            }
            else
            {
               // MessageBox.Show("ds");   
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
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type_f='" + ComboBox_t.SelectedItem.ToString() + "' and room='" + ComboBox_flat.Text + "'");
        }

      

        private void ComboBox_P_DropDownClosed(object sender, EventArgs e)
        {

            ComboBox_flat.Items.Clear();
            dbConnect dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for (int i = 0; i < db.Rows.Count; i++)
                {
                    ComboBox_flat.Items.Add(db.Rows[i][0].ToString());

                }


            };
           // MessageBox.Show(ComboBox_P.Text);
            dbCon.SoursData("SELECT room FROM type_flat WHERE dom_id='6' and porch='" + ComboBox_P.Text + "' GROUP BY room");

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

            dbCon.SoursData(" SELECT type FROM type_flat WHERE dom_id='6' and porch='" + ComboBox_P.Text + "' and room='" + ComboBox_flat.Text + "' GROUP BY type;");

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
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_t.Text + "' and room='" + ComboBox_flat.Text + "'");

            TextBlock_kvm.Text = "Всего: " + dbCon2.DisplayReturn("SELECT SUM(kvm) FROM type_flat " +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_t.Text + "' and room='" + ComboBox_flat.Text + "'") + " кв. м.";

        }

        private void textBox1_valyta_KeyUp(object sender, KeyEventArgs e)
        {
            double summa= Convert.ToDouble(textBox_sena.Text) * Convert.ToDouble(textBox1_valyta.Text);
            textBox1_summa.Text = summa.ToString();
        }
    }
    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}
