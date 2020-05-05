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
    /// Логика взаимодействия для Prod_pag2.xaml
    /// </summary>
    public partial class Prod_pag2 : Page
    {
        public Prod_pag2()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_year view_Year = new view_year();
            view_Year.ShowDialog();
        }
    }
}
