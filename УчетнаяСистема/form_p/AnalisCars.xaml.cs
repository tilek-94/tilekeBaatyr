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

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for AnalisCars.xaml
    /// </summary>
    public partial class AnalisCars : UserControl
    {
        public AnalisCars()
        {
            InitializeComponent();
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
            x11.Focus();
        }
        dbConnect dbCon; 
        void Display()
        {
            dbCon = new dbConnect();

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT id, NAME, marka,DATA,A1, A2,B1,B2,B1-A1 AS roz, B2-A2 AS roz2  FROM analis_cars");

        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            //MessageBox.Show($"{Convert.ToInt32("34A73A22", 16)}");
        }

        private void x11_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void x11_KeyUp(object sender, KeyEventArgs e)
        {
            
            string s = x11.Text;
           
           // MessageBox.Show(s);0883374626

        }
    }
}
