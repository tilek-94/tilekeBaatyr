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
    /// Interaction logic for MessageM.xaml
    /// </summary>
    public partial class MessageM : Window
    {
        public MessageM()
        {
            InitializeComponent();
        }
        public string Mees { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessTextBox.Text = Mees;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
