using System.Data;
using System.Windows;
using System.Windows.Controls;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for analis.xaml
    /// </summary>
    public partial class analis : Page
    {
        public analis()
        {
            InitializeComponent();
        }
        dbConnect dbCon = new dbConnect();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Display();
        }
        void Display()
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.DataContext = db;
            };
            dbCon.SoursData("SELECT f.number_f, f.floor, " +
                "(SELECT SUM(kvm)  FROM type_flat WHERE dom_id = '6' " +
                "and porch = f.porch and type = f.type_flat and room = f.room) as kvm, " +
                "z.contract, c.name,ca.marka, z.kurs,z.price_kvm, z.price_kvm*z.kurs som, " +
                "z.price_kvm* kvm as us, ROUND((z.price_kvm * z.kurs) * kvm, 2) as kg " +
                "FROM flat f left join((zakaz z join client c) join cars ca )  " +
                "on z.number_f = f.number_f and z.cars_id = ca.id and z.klient_id = c.id; ");

        }
    }
}
