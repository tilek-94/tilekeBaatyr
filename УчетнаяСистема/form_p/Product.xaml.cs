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
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        
        public Product()
        {
            InitializeComponent();
        }
        public event Action<string, string> ValueChanged;
        dbConnect dbCon = new dbConnect();
        string[] s;
        double dollar = 0, kurs = 0, som = 0;
        string id = "";
        private void text4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }

        string name;
        private void myDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            int index = dataGridView1.CurrentCell.Column.DisplayIndex;
            id = dataRow.Row.ItemArray[0].ToString();
            name = dataRow.Row.ItemArray[1].ToString();
            string price = dataRow.Row.ItemArray[2].ToString();
            string kurs = dataRow.Row.ItemArray[3].ToString();
            text1.Text = name;
            text2.Text = price;
            text3.Text = kurs;
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void button_vbor_Click(object sender, RoutedEventArgs e)
        {
            if (name != "")
            {
                ValueChanged(id, name);
                this.Close();
            }
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if(text1.Text!="" && text2.Text!="" && text3.Text != "") { 
            dbCon.Registr("INSERT INTO product(name,price,kurs) VALUES('"+text1.Text+"','"+text2.Text+"','"+text3.Text+"')");
            Display();
            }
            else
            {
                MessageBox.Show("Заполните все полии!");
            }
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM product ORDER BY id DESC");

        }
    }
}
