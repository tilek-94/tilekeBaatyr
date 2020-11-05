using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.otchet
{
    /// <summary>
    /// Interaction logic for BisnesClass.xaml
    /// </summary>
    public partial class BisnesClass : Window
    {
        public BisnesClass()
        {
            InitializeComponent();
        }
        int i;
        dbConnect dbCon;
        private void kon_n_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
        private void RegistDataP(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                myDataGrid.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void Summa(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                LabelUsd.Content=  db.Rows[0][0].ToString();
                LabelKGS.Content=  db.Rows[0][1].ToString();
            };
            dbCon.SoursData(s);

        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistDataP("SELECT * FROM _otchet_bclass p WHERE MONTH(p.`data`) = MONTH(NOW()) AND YEAR(p.`data`) = YEAR(NOW())");
            Summa("SELECT ROUND( SUM(usd),2), ROUND(SUM(kgs),2) FROM _otchet_bclass p WHERE MONTH(p.`data`) = MONTH(NOW()) AND YEAR(p.`data`) = YEAR(NOW())");
        }

        
    }
}
