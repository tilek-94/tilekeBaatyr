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
    /// Логика взаимодействия для komplekc.xaml
    /// </summary>
    public partial class komplekc : Page
    {
        public komplekc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<10;i++)
            WrapPanel1.Children.Add(border1);
        }
    }
}
