using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;
using УчетнаяСистема.Model;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for ViewCarsinAnalise.xaml
    /// </summary>
    public partial class ViewCarsinAnalise : Window
    {
        public ViewCarsinAnalise()
        {
            InitializeComponent();
        }

        dbConnect dbCon = new dbConnect();

        public string SqlQury = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }

        void Display()
        {
            string s = "";
            int i = 0;
            //MessageBox.Show(SqlQury);
            List<Cars> cars = JsonConvert.DeserializeObject<List<Cars>>(SqlQury);
            foreach (Cars c in cars)
            {
                if (cars.Count == 1)
                    s = $" and c.id={c.Id}";
                else
                {
                    i++;
                    if (i == 1)
                        s += $" and c.id={c.Id}";
                    else
                        s += $" or c.id={c.Id}";
                }
                //MessageBox.Show(s);
            }

            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT c.id,c.marka,c.data,c.nomer,c.condition_c," +
                "IF(c.type_v = '(KGS)', ROUND(c.prih_summ / cur.usd, 2), c.prih_summ) AS to_usd," +
                "IF(c.type_v = '(USD)', ROUND(c.prih_summ * cur.usd, 2), c.prih_summ) AS Rto_kgs," +
                "(SELECT name FROM client WHERE id = c.client_id) as client, " +
                "datatim FROM cars c INNER JOIN currency cur ON c.kurs = cur.id WHERE c.remov=0 " + s);

        }


        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
