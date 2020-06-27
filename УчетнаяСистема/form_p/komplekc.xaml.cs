using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;


namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для komplekc.xaml
    /// </summary>
    public partial class komplekc : Page

    {
        dbConnect dbCon = new dbConnect();
        public komplekc()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
                Button button = new Button();
                button.VerticalAlignment = VerticalAlignment.Top;
                button.Style = (Style)this.TryFindResource("menuCom") ;
                button.Name = "button";
                button.Click += new RoutedEventHandler(Button_Click);               

        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            MessageBox.Show(b.Name.ToString());
        }

    }
}
