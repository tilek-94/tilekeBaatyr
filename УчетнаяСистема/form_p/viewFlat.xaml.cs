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
    /// Interaction logic for viewFlat.xaml
    /// </summary>
    public partial class viewFlat : Window
    {
        public viewFlat()
        {
            InitializeComponent();
        }
        
        dbConnect dbCon = new dbConnect();
        public string sqlQery { get; set; }
        private void text1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
                 text1.Text = db.Rows[0][2].ToString();
                text2.Text = db.Rows[0][3].ToString();
                text3.Text = db.Rows[0][4].ToString();
            };
            dbCon.SoursData(s);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData(sqlQery);
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
