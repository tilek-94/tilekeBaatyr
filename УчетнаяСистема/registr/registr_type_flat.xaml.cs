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

namespace УчетнаяСистема.registr
{
    /// <summary>
    /// Логика взаимодействия для registr_type_flat.xaml
    /// </summary>
    public partial class registr_type_flat : Window
    {
        public registr_type_flat()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        string[] s; 
        
        private void btn_registr_type_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO type_flat(dom_id,porch,room,type,name,kvm)" +
                "values (" +
                "'6'," +
                "'" + ComboBox_P.Text + "'," +
                "" + ComboBox_flat.Text + "," +
                "'" + ComboBox_Type.Text + "'," +
                "'" + textBox1.Text + "' ," +
                "'" + textBox2.Text + "')");
            Display();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='6'");
            for (int i = 1; i <= Convert.ToInt16(s[1]); i++)
            {
                ComboBox_P.Items.Add(i.ToString());

            }
        }

        private void ComboBox_Type_DropDownClosed(object sender, EventArgs e)
        {
            Display();


        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT name,kvm FROM type_flat" +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_Type.Text + "' and room='" + ComboBox_flat.Text + "'");

            TextBlock_kvm.Text ="Всего: "+ dbCon.DisplayReturn("SELECT SUM(kvm) FROM type_flat " +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_Type.Text + "' and room='" + ComboBox_flat.Text + "'")+" кв. м.";

        }

        private void ComboBox_flat_DropDownClosed(object sender, EventArgs e)
        {
            Display();
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
