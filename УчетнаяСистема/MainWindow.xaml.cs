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
using УчетнаяСистема.registr;

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
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        public delegate void OpenForm();
       // public event OpenForm openform;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/addBuilding.xaml", UriKind.RelativeOrAbsolute));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
           /* registr_flat registr_Flat = new registr_flat();
            registr_Flat.ShowDialog();*/
           pag.Navigate(new System.Uri("form_p/analis.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            //Menu.Visibility= Visibility.Hidden;
            pag.Navigate(new System.Uri("form_p/addBuilding.xaml", UriKind.RelativeOrAbsolute));
            pag.Navigate(new System.Uri("form_p/komplekc.xaml", UriKind.RelativeOrAbsolute));
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
            this.Close();
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


        private void grafBtn_Click(object sender, RoutedEventArgs e)
        {
            pag.Navigate(new System.Uri("form_p/Prod_pag2.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void bron_btn_Click(object sender, RoutedEventArgs e)
        {
            Bron_WinDow bron_WinDow = new Bron_WinDow();
            bron_WinDow.ShowDialog();
        }

        private void obmen_btn_Click(object sender, RoutedEventArgs e)
        {
            exchange ex = new exchange();
            ex.ShowDialog();
        }

        private void prod_btn_Click(object sender, RoutedEventArgs e)
        {
            registr_flat registr_Flat = new registr_flat();
            registr_Flat.ShowDialog();
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
