using System.Windows;

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
