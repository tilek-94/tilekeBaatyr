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
using form_p = УчетнаяСистема.form_p;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для exchange.xaml
    /// </summary>
    public partial class exchange : Window
    {
        public exchange()
        {
            InitializeComponent();
        }

        int client_id = 0;
        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void view_client_btn_Click(object sender, RoutedEventArgs e)
        {
            form_p.Window1 window1 = new form_p.Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                text1.Text = y;

            });
            window1.ShowDialog();
        }

        private void view_product_btn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new form_p.Product();
            product.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = Convert.ToInt32(x);
                text2.Text = y;

            });
            product.ShowDialog();
        }
    }
}
