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
using System.Windows.Shapes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для exchange.xaml
    /// </summary>
    public partial class exchange : Window
    {
        public exchange()
        {
            InitializeComponent();
        }

        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
