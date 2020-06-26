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
    /// Interaction logic for viewPeopleinAnalis.xaml
    /// </summary>
    public partial class viewPeopleinAnalis : Window
    {
        public viewPeopleinAnalis()
        {
            InitializeComponent();
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
