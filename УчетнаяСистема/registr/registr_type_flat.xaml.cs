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
        private void ComboBox1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)ComboBox_flat.SelectedItem;
            string str1 = cbi.Content.ToString();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT name,kvm from properties_flat" +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type_f='" + ComboBox_kv.Text + "' and room='" + str1 + "'");

        }
        private void btn_registr_type_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO properties_flat(name,kvm,dom_id,porch,type_f,room)" +
                "values (" +
                "'" + textBox1.Text + "'," +
                "'" + textBox2.Text + "'," +
                "'6'," +
                "'" + ComboBox_P.Text + "'," +
                "'" + ComboBox_kv.Text + "'," +
                "'" + ComboBox_flat.Text + "')");
            dbCon.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT name,kvm from properties_flat" +
                " WHERE dom_id='6' and porch='" + ComboBox_P.Text + "'" +
                " and type_f='" + ComboBox_kv.Text + "' and room='" + ComboBox_flat.Text + "'");
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void text1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /*if (textBox2.Text == ".")
            {
                MessageBox.Show("dfd");
            }
                else
            e.Handled = !(Char.IsDigit(e.Text, 0));*/
        }

    }
}
