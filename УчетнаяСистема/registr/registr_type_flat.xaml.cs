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
using System.Windows.Forms;
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
        string porch = "", type = "", room = "";
        string NameFlat = "";

        private void btn_registr_type_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO type_flat(dom_id,porch,room,type,name,kvm)" +
                "values (" +
                "'"+staticClass.StaticDomID+"'," +
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
            s = dbCon.RedInfor("SELECT floor,porch,count_kv FROM dom WHERE id='"+staticClass.StaticDomID+"'");
            for (int i = 1; i <= Convert.ToInt16(s[1]); i++)
            {
                ComboBox_P.Items.Add(i.ToString());

            }
        }

        private void ComboBox_Type_DropDownClosed(object sender, EventArgs e)
        {
            Display();


        }
        
        void InsertVariables()
        {
            porch= ComboBox_P.Text;
            room = ComboBox_flat.Text;
            type = ComboBox_Type.Text;
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                type_flat_listwiew.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT name,kvm FROM type_flat" +
                " WHERE dom_id='"+staticClass.StaticDomID+"' and porch='" + ComboBox_P.Text + "'" +
                " and type='" + ComboBox_Type.Text + "' and room='" + ComboBox_flat.Text + "'");

            TextBlock_kvm.Text ="Всего: "+ dbCon.DisplayReturn("SELECT SUM(kvm) FROM type_flat " +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and porch='" + ComboBox_P.Text + "'" +
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"id: {staticClass.StaticDomID} p:{porch} r:{room} t:{type} n:{NameFlat}");

            if (NameFlat!="") { 

            dbCon.Registr("DELETE FROM type_flat WHERE dom_id='"+staticClass.StaticDomID+"'" +
                "and porch='"+porch+"' and room='"+room+"' and type='"+type+"' and name='"+NameFlat+"'");
                Display();
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Выберите нужные раздель";
                messageM.ShowDialog();
            }
        }
              
        private void type_flat_listwiew_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dataRow = (DataRowView)type_flat_listwiew.SelectedItem;
            if (dataRow != null)
            {
                NameFlat = dataRow.Row.ItemArray[0].ToString();
            }
            InsertVariables();
            //MessageBox.Show(id_1);
        }
    }
}
