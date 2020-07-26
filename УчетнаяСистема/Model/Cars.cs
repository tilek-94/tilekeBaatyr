using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace УчетнаяСистема.Model
{
   public class Cars : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double usd;
        public double Usd
        {
            get { return usd; }
            set
            {
                usd = value;
                OnPropertyChanged("Usd");
            }
        }

        private double kgs;
        public double Kgs
        {
            get { return kgs; }
            set
            {
                kgs = value;
                OnPropertyChanged("Kgs");
            }
        }


    }
}
