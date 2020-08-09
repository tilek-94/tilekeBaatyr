using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.form_p;
using УчетнаяСистема.registr;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using УчетнаяСистема.All_classes;
using System.Collections.ObjectModel;
using УчетнаяСистема.Model;

namespace УчетнаяСистема.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        private UserControl Analis;
        private UserControl Kompleks_hause;
        private UserControl Peple_pag;
        private UserControl Phous;
        private UserControl Cars_pag;
        private UserControl addBuilding;
        private UserControl BookeepingP;
        private UserControl OrganizationP;
        private UserControl Rashod;
        private UserControl Parking;
        private UserControl AnalisCars;

        private UserControl _currentPage;
        public UserControl CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        private string nameBuild;
        public string NameBuild
        {
            get { return nameBuild; }
            set { nameBuild = value;
                OnPropertyChanged("NameBuild");
            }
        }
        
        private double countT;
        public double CountT
        {
            get { return countT; }
            set
            {
                countT = value;
                OnPropertyChanged("CountT");
            }
        }

        public MainViewModel()
        {
            Analis = new analis();
            Kompleks_hause = new Kompleks_hause();
            Peple_pag = new Peple_pag();
            Phous = new Phous();
            Cars_pag = new Cars_pag();
            addBuilding = new addBuilding();
            BookeepingP = new BookeepingP();
            OrganizationP = new OrganizationP();
            Rashod = new Rashod();
            Parking = new Parking();
            AnalisCars = new AnalisCars();
            CurrentPage = Kompleks_hause;
            NameBuild = staticClass.BuildName;
        }

        public ICommand bMenuAnalis => new RelayCommand((obj) => {
            CurrentPage = Analis;
            NameBuild = staticClass.BuildName;
        });
        public ICommand button_carsA => new RelayCommand((obj) => CurrentPage = AnalisCars);
        public ICommand bMenuPhous => new RelayCommand((obj) => CurrentPage = Phous);
        public ICommand bMenuComHaus => new RelayCommand((obj) => CurrentPage = Kompleks_hause);
        public ICommand bMenuParking => new RelayCommand((obj) => CurrentPage = Parking);
        public ICommand bMenuRashod => new RelayCommand((obj) => CurrentPage = Rashod);
        public ICommand bMenuOrganizationP => new RelayCommand((obj) => CurrentPage = OrganizationP);
        public ICommand bMenuBookeepingP => new RelayCommand((obj) => CurrentPage = BookeepingP);
        public ICommand bMenuCars_pag => new RelayCommand((obj) => CurrentPage = Cars_pag);
        public ICommand bMenuPeple_pag => new RelayCommand((obj) => CurrentPage = Peple_pag);
        
        public ICommand bMenuaddBuilding => new RelayCommand((obj) => CurrentPage = addBuilding);
        public ICommand btnClose => new RelayCommand((obj) => Application.Current.Shutdown());

        public ICommand bMenuProd_pag2 => new RelayCommand((obj) => {
            Prod_pag2 prod_Pag2 = new Prod_pag2();
            prod_Pag2.ShowDialog();
            });
        public ICommand bMenuexchange => new RelayCommand((obj) =>
        {
            exchange Exchange = new exchange();
            Exchange.ShowDialog();
        });

        public ICommand bBisnes => new RelayCommand((obj) =>
        {
            RegistrBisnes registrBisnes = new RegistrBisnes();
            registrBisnes.ShowDialog();
        });

        public ICommand bInsertDolg => new RelayCommand((obj) =>
        {
            Bron_Klient bron_Klient = new Bron_Klient();
            bron_Klient.ShowDialog();
        });
        public ICommand bMenuProdCars => new RelayCommand((obj) =>
        {
            ProdCars prodCars = new ProdCars();
            prodCars.ShowDialog();
        });
         public ICommand bMenueBron_WinDow => new RelayCommand((obj) =>
        {
            Bron_WinDow bron_WinDow = new Bron_WinDow();
            bron_WinDow.ShowDialog();
        });
       public ICommand bMenueRegTypeFlat => new RelayCommand((obj) =>
        {
            registr_type_flat registr_Type_Flat = new registr_type_flat();
            registr_Type_Flat.ShowDialog();
        });
        public ICommand bMenueRegFlat => new RelayCommand((obj) =>
        {
            registr_flat registr_Flat = new registr_flat();
            registr_Flat.ShowDialog();
        });

        public ICommand bMenueRegEm => new RelayCommand((obj) =>
        {
            RegistrEm registrEm = new RegistrEm();
            registrEm.ShowDialog();
        });

       /* private ObservableCollection<Cars> carsList;
        public ObservableCollection<Cars> CarsList
        {
            get { return carsList; }
            set
            {
                carsList = value;
                OnPropertyChanged("CarsList");
            }
        }*/

        /*private void LoadData()
        {
            CarsList = new ObservableCollection<Cars>(Cars.GetAll());
        }*/



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
