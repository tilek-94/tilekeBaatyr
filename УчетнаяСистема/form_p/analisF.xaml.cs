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
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for analisF.xaml
    /// </summary>
    public partial class analisF : Page
    {
        public analisF()
        {
            InitializeComponent();
        }
           dbConnect dbCon = new dbConnect();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("select `zakaz`.`id` ,`dom`.`name` ,`client`.`name`  as 'name_cl'," +
                "`cars`.`marka` ,`cars`.`prih_summ` ,`zakaz`.`number_f` ,`zakaz`.`contract`," +
                " `zakaz`.`kvm`  ,`zakaz`.`price_kvm` ,`zakaz`.`kurs` ," +
                "(`zakaz`.`price_kvm` * `zakaz`.`kvm`) as som ," +
                "round(((`zakaz`.`price_kvm` * `zakaz`.`kvm`) * `zakaz`.`kurs`),2) as" +
                " summa  from (((`zakaz` join `dom`) join `client`) join `cars` " +
                "on(((`dom`.`id` = `zakaz`.`dom_id`) and (`zakaz`.`klient_id` = `client`.`id`) " +
                "and (`zakaz`.`cars_id` = `cars`.`id`))))");
        }
    }
}
