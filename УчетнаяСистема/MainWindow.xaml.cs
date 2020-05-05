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
using УчетнаяСистема.form_p;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Os_Grid.Children.Add(new Page1());
            //if (pag.Content != null)
            //    pag.Content = null;
            //else
            //pag.Content = new Page1();
            pag.Navigate(new System.Uri("form_p/addBuilding.xaml", UriKind.RelativeOrAbsolute));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/Prod_pag2.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/addBuilding.xaml", UriKind.RelativeOrAbsolute));
            OpenWindows();
        }

        private void OpenWindows()
        {
            Window1 window1 = new Window1();
            window1.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                blur.Radius = Convert.ToInt32(x);

            });

            if (blur.Radius == 15)
                blur.Radius = 0;
            else
            {

                window1.Owner = this;
                blur.Radius = 15;
                window1.ShowDialog();
            }
        }
        private void Button_Clic(object sender, RoutedEventArgs e)
        {

        }

        private void button_people_Click(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/Peple_pag.xaml", UriKind.RelativeOrAbsolute));
        }

        private void button_cars_Click(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/Cars_pag.xaml", UriKind.RelativeOrAbsolute));
        }

        private void lock_button_Click(object sender, RoutedEventArgs e)
        {
            OpenWindows();
        }
    }
    public class Phone
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }

    public class Prod
    {
        public int id { get; set; }
        public string kv { get; set; }
        public string etaj { get; set; }
        public string mkv { get; set; }
        public string dog { get; set; }
        public string fio { get; set; }
        public string date { get; set; }
    }
}
