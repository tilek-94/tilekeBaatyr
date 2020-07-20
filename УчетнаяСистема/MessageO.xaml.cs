using System.Windows;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема
{
    /// <summary>
    /// Interaction logic for MessageO.xaml
    /// </summary>
    public partial class MessageO : Window
    {
        public delegate void MessageDel();
        public event MessageDel del_;
        dbConnect dbCon = new dbConnect();
        public string Id { get; set; }
        public string TableBasa { get; set; }
        public MessageO()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(Id!="" && TableBasa != "")
            dbCon.RemoveData(TableBasa, Id,staticClass.StaticEmplayID);
            del_();
            this.Close();
        }
    }
}
