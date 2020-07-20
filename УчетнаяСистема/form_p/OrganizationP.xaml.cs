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
    /// Interaction logic for OrganizationP.xaml
    /// </summary>
    public partial class OrganizationP : UserControl
    {
        public OrganizationP()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();

        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM organization");
        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Organization organization = new Organization();
            organization.ShowDialog();
        }
    }
}
