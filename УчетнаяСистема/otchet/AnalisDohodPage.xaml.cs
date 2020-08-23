using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.otchet
{
    /// <summary>
    /// Interaction logic for AnalisDohodPage.xaml
    /// </summary>
    public partial class AnalisDohodPage : UserControl
    {
        public AnalisDohodPage()
        {
            InitializeComponent();
        }
        dbConnect dbCon;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Display("SELECT * FROM _analis_dohod ");
            Summa("SELECT ROUND( SUM(to_usd),2), ROUND(SUM(Rto_kgs),2) FROM _analis_dohod ");
        }
        void Display(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData(s);
            
        }

        void Summa(string s)
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                lablelUsd.Content = db.Rows[0][0].ToString()+" $";
                lablelKgs.Content = db.Rows[0][1].ToString() + " Сом";
            };
            dbCon.SoursData(s);

        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {
            dataRepord dataRepord = new dataRepord();
            dataRepord.del_ += (x,x1 )=> {
                Display(x);
                Summa(x1);
                };
            dataRepord.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Display("SELECT * FROM _analis_dohod WHERE client like '%"+ texbox_serch.Text + "%' ");
            Summa("SELECT ROUND( SUM(to_usd),2), ROUND(SUM(Rto_kgs),2) FROM _analis_dohod WHERE client like '%" + texbox_serch.Text + "%' ");
        }
    }
}
