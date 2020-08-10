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

namespace УчетнаяСистема.otchet
{
    /// <summary>
    /// Interaction logic for AnalisDohodPage.xaml
    /// </summary>
    public partial class AnalisDohodPage : UserControl
    {
        public AnalisDohodPage()
        {
            InitializeComponent();
        }
        dbConnect dbCon;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Display();
        }
        void Display()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT * FROM _analis_dohod ");

        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
