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
            window1.ValueChanged += new Action<string,string>((x,name) =>//подписываемся на событие
            {
                blur.Radius = Convert.ToInt32(x);
                if (name != "admin") { 
                Vod_Dannyx.Visibility = Visibility.Collapsed;
               // Vod_Dannyx_Grig.Visibility = Visibility.Collapsed;
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
       

        private void lock_button_Click(object sender, RoutedEventArgs e)
        {
            OpenWindows();
        }

    }
    

}
