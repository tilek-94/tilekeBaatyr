using System.Windows;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
        }
        public delegate void MessageDel();
        public event MessageDel del_;
        dbConnect dbCon = new dbConnect();
        public string Id { get; set; }
        public string TableBasa { get; set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            del_();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
