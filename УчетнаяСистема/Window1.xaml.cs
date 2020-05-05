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

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public event Action<string> ValueChanged;
        public Window1()
        {
            InitializeComponent();
        }
        int f { get; set; } = 0;
        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            
            ValueChanged("0");
            f = 1;
            // mainWindow.blur.Radius = 0;
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(f!=1)
            Application.Current.Shutdown();
           
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            f = 0;
            this.Close();
        }
    }
}
