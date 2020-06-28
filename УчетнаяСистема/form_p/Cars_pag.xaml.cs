﻿using System;
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
    /// Логика взаимодействия для Cars_pag.xaml
    /// </summary>
    public partial class Cars_pag : Page
    {
        public Cars_pag()
        {
            InitializeComponent();
        }

        
        dbConnect dbCon = new dbConnect();
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.ShowDialog();
        }

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
            dbCon.SoursData("SELECT id,marka,data,nomer,condition_c," +
                "prih_summ, kurs, prih_summ * kurs as summ_som," +
                "(SELECT name FROM client WHERE id = client_id) as client" +
                ",datatim FROM cars");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search_cars2 search_Cars2 = new Search_cars2();
            search_Cars2.flag = true;
            search_Cars2.ShowDialog();
        }
    }
}
