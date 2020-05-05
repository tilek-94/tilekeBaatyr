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
using System.Collections.ObjectModel;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для view_year.xaml
    /// </summary>
    public partial class view_year : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public view_year()
        {
            InitializeComponent();
            employees.Add(new Employee { ID = 1, year=2019, Name = "февраль",  Type = EmployeeType.Normal, BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "Март", IsMale = true, Type = EmployeeType.Normal, BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "апрель", IsMale = true, Type = EmployeeType.Normal, BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "май", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "Июнь", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "Июль", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "Август", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), BirthDate = new DateTime(1980, 1, 1) });
            employees.Add(new Employee { ID = 1, year=2019, Name = "Сентябрь", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), });
           
            employees.Add(new Employee { ID = 3, year = 2020, Name = " ", IsMale = false, Type = EmployeeType.Supervisor, SiteID = new Uri("http://localhost/4872")  });
            employees.Add(new Employee { ID = 4, year = 2020, Name = "Michael", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322") });
            employees.Add(new Employee { ID = 5, year = 2018, Name = "Martin", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4432"), BirthDate = new DateTime(1989, 2, 1) });
            employees.Add(new Employee { ID = 6, year = 2018, Name = "Lucy", IsMale = false, Type = EmployeeType.Supervisor, SiteID = new Uri("http://localhost/4872"), BirthDate = new DateTime(1967, 3, 1) });
            employees.Add(new Employee { ID = 7, year = 2018, Name = "Brian", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4322"), BirthDate = new DateTime(1942, 1, 1) });
            employees.Add(new Employee { ID = 8, year = 2017, Name = "Santa", IsMale = true, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4432"), BirthDate = new DateTime(1976, 2, 1) });
            employees.Add(new Employee { ID = 9, year = 2017, Name = "Ruby", IsMale = false, Type = EmployeeType.Normal, SiteID = new Uri("http://localhost/4872"), BirthDate = new DateTime(1990, 3, 1) });

            ListCollectionView collectionView = new ListCollectionView(employees);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("year"));
            myDataGrid.ItemsSource = collectionView;
        }

        private void myDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Employee employee = myDataGrid.SelectedItem as Employee;
            MessageBox.Show("ID"+employee.ID);
        }
    }
}
