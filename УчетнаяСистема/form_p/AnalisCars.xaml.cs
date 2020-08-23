using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for AnalisCars.xaml
    /// </summary>
    public partial class AnalisCars : UserControl
    {
        public AnalisCars()
        {
            InitializeComponent();
        }

        private void registr_btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
            x11.Focus();
        }
        dbConnect dbCon; 
        void Display()
        {
            dbCon = new dbConnect();

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT c.id, NAME, c.marka,c.DATA,c.A1, c.A2,c.pokup,c.B1,c.B2,ROUND( c.B1-c.A1,2) AS roz, " +
                "ROUND(c.B2 - c.A2, 2) AS roz2 " +
                ", c.DATA2, c.nomer, c.condition_c, c.datatim " +
                "FROM _analis_cars c ORDER BY c.id DESC");

        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.flag = true;
            search_Cars2.Height = 335;
            search_Cars2.clDel += () => Display();
            search_Cars2.ShowDialog();
        }

        private void x11_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void x11_KeyUp(object sender, KeyEventArgs e)
        {
            
            string s = x11.Text;
           
           // MessageBox.Show(s);0883374626

        }

        private void x11_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbCon = new dbConnect();

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT c.id, c.NAME, c.marka,c.DATA,c.A1, c.A2,c.pokup,c.B1,c.B2,ROUND( c.B1-c.A1,2) AS roz, " +
                "ROUND(c.B2 - c.A2, 2) AS roz2 " +
                ", c.DATA2, c.nomer, c.condition_c, c.datatim " +
                "FROM _analis_cars c WHERE c.marka LIKE '%"+x11.Text+ "%' " +
                "or c.nomer LIKE '%" + x11.Text + "%' or c.NAME LIKE '%" + x11.Text + "%' ORDER BY c.id DESC");
        }
    }
}
