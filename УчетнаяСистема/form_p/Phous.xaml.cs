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
    /// Interaction logic for Phous.xaml
    /// </summary>
    public partial class Phous : UserControl
    {
        public Phous()
        {
            InitializeComponent();
        }
        dbConnect dbCon; 
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            ProdPhous prodPhous = new ProdPhous();
            prodPhous.del_ += () => Display();
            prodPhous.ShowDialog();
        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }
        void Display()
        {
            dbCon = new dbConnect();

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT * FROM display WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
