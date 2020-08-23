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

namespace УчетнаяСистема.otchet
{
    /// <summary>
    /// Interaction logic for dataRepord.xaml
    /// </summary>
    public partial class dataRepord : Window
    {
        public dataRepord()
        {
            InitializeComponent();
        }
        string data_n, data_k;
        public delegate void  SendData(string s,string s1);
        public event SendData del_;

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        DateTime now,now2;
        private void kon_k_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            now = kon_k.SelectedDate.Value;
            data_k=now.ToString("yyyy-MM-dd");
        }

        private void kon_n_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            now2 = kon_n.SelectedDate.Value;
            data_n = now2.ToString("yyyy-MM-dd");
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            
            //MessageBox.Show("SELECT * FROM _search_dahod s WHERE s.`data`>'" + data_n + "' AND s.`data`<'" + data_k + "' ");
            del_("SELECT * FROM _search_dahod s WHERE s.`data`>'"+ data_n + "' AND s.`data`<'"+ data_k + "' ",
               "SELECT ROUND( SUM(to_usd),2), ROUND(SUM(Rto_kgs),2) FROM _search_dahod s WHERE s.`data`>'" + data_n + "' AND s.`data`<'" + data_k + "' ");
            this.Close();
        }
    }
}
