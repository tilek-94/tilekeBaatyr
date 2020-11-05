using System;
using System.Windows;
using System.Windows.Input;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.form_p;
using УчетнаяСистема.registr;

namespace УчетнаяСистема
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }
        public delegate void OpenForm();
       

        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            
            /*Kompleks_hause kompleks = new Kompleks_hause();
            kompleks.ShowDialog();*/
            OpenWindows();
           
                        
        }

        

        private void OpenWindows()
        {
            Window1 window1 = new Window1();
            window1.ValueChanged += new Action<string, string>((x, name) =>//подписываемся на событие
            {
                blur.Radius = Convert.ToInt32(x);
                if (name == "admin")
                {
                    M1.Visibility = Visibility.Visible;
                    btn1.Visibility = Visibility.Visible;
                    btm08.Visibility = Visibility.Visible;
                }

                if (name == "manager")
                {
                    M1.Visibility = Visibility.Collapsed;
                    btn1.Visibility = Visibility.Collapsed;
                    btm08.Visibility = Visibility.Collapsed;

                }

                if (name == "accountant")
                {
                    M1.Visibility = Visibility.Collapsed;

                }
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
       
        private void DiabledPanel()
        {
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;
            btn9.IsEnabled = false;
            btn10.IsEnabled = false;
            btn11.IsEnabled = false;
           
        }

        private void lock_button_Click(object sender, RoutedEventArgs e)
        {
            OpenWindows();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState!=WindowState.Normal)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void button_people_Click(object sender, RoutedEventArgs e)
        {
            registr_type_flat registr_Type_Flat = new registr_type_flat();
            registr_Type_Flat.Owner = this;
            registr_Type_Flat.ShowDialog();
        }

        private void grafBtn_Click(object sender, RoutedEventArgs e)
        {
            registr_flat registr_Flat = new registr_flat();
            registr_Flat.Owner = this;
            registr_Flat.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegistrEm registrEm = new RegistrEm();
            registrEm.Owner = this;
            registrEm.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RegistrBisnes registrBisnes = new RegistrBisnes();
            registrBisnes.Owner = this;
            registrBisnes.ShowDialog();
        }

        private void obmen_btnV_Click(object sender, RoutedEventArgs e)
        {
            exchange Exchange = new exchange();
            Exchange.Owner = this;
            Exchange.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ProdCars prodCars = new ProdCars();
            prodCars.Owner = this;
            prodCars.ShowDialog();
        }

        private void bron_btnV_Click(object sender, RoutedEventArgs e)
        {
            Bron_WinDow bron_WinDow = new Bron_WinDow();
            bron_WinDow.Owner = this;
            bron_WinDow.ShowDialog();
        }
    }
    

}
