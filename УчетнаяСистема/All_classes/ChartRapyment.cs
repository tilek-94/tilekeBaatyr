using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace УчетнаяСистема.All_classes
{
    class ChartRapyment
    {
        dbConnect dbCon;
        public void Display(string sql,double Som, double Dol , DataGrid dataGrid, string d1, string m1, string y1, string d2, string m2, string y2)
        {
            string[] month = new string[100];
            string[] summ = new string[100];
            string[] USD = new string[100];
            int i = 0;
             dbCon = new dbConnect();
            dbCon.connection.Open();
            
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                summ[i] = reader[0].ToString();
                USD[i] = reader[1].ToString();
                month[i] = reader[2].ToString();
                
                i++;
            }
            dbCon.connection.Close();
            string data = "";
            int j = 0, count = 0;
            var start = new DateTime(Convert.ToInt32(y1), Convert.ToInt32(m1), Convert.ToInt32(d1));
            var end = new DateTime(Convert.ToInt32(y2), Convert.ToInt32(m2), Convert.ToInt32(d2));
            
            List<MyTable> result = new List<MyTable>(3);
            DateTimeFormatInfo d = DateTimeFormatInfo.CurrentInfo;
            foreach (var range in EnumerateRanges(start, end, months: 1))
            {
                count++;
                j = 0;
                data = range.Start.ToString("MM") + "-" + range.Start.ToString("yyyy");
                j = Array.IndexOf(month, data);
                  
                if (j >= 0)
                {
                    result.Add(new MyTable(count, range.Start.ToString("yyyy"), range.Start.ToString("MMMM", CultureInfo.CurrentCulture), summ[j]+" $", USD[j]+ " Сом", Som.ToString() + " Сом",Dol.ToString() + " $"));
                }
                else
                {
                    result.Add(new MyTable(count, range.Start.ToString("yyyy"), range.Start.ToString("MMMM", CultureInfo.CurrentCulture), "0", "0", Som.ToString() + " Сом", Dol.ToString() + " $"));
                }
            }

            dataGrid.ItemsSource = result;
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (cvTasks != null && cvTasks.CanGroup == true)
            {
                cvTasks.GroupDescriptions.Clear();
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("Year_c"));

            }


        }
        IEnumerable<(DateTime Start, DateTime End)>

                EnumerateRanges(DateTime startDate, DateTime endDate, int months = 0)
        {
            DateTime start = startDate;
            DateTime next = start.AddMonths(months);
            while (next < endDate)
            {
                yield return (start, next.AddSeconds(-1));
                start = next;
                next = start.AddMonths(months);
            }
            yield return (start, endDate);
        }

    }
    class MyTable
    {
        public MyTable(int Id, string Year_c, string Month_c, string Summak, string Dollark, string Summa, string Dollar)
        {
            this.Id = Id;
            this.Year_c = Year_c;
            this.Month_c = Month_c;
            this.Summak = Summak;
            this.Dollark = Dollark;
            this.Summa = Summa;
            this.Dollar = Dollar;
        }
        public int Id { get; set; }
        public string Year_c { get; set; }
        public string Month_c { get; set; }
        public string Summa { get; set; }
        public string Dollar { get; set; }
        public string Summak { get; set; }
        public string Dollark { get; set; }
    }
}
