using System;
using System.Collections.Generic;
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

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для Cars_pag.xaml
    /// </summary>
    public partial class Cars_pag : Page
    {
        public Cars_pag()
        {
            InitializeComponent();
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.ShowDialog();
            
        }
    }
}
