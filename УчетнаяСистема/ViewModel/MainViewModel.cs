using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using УчетнаяСистема.form_p;
using УчетнаяСистема.registr;
using System.Windows;

namespace УчетнаяСистема.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        private Page Analis;
        private Page Peple_pag;
        private Page Prod_pag2;
        private Page Cars_pag;
        private Page addBuilding;
        private Page BookeepingP;
        private Page OrganizationP;
        private Page Rashod;
       
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
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
            Peple_pag = new Peple_pag();
            Prod_pag2 = new Prod_pag2();
            Cars_pag = new Cars_pag();
            addBuilding = new addBuilding();
            BookeepingP = new BookeepingP();
            OrganizationP = new OrganizationP();
            Rashod = new Rashod();
            CurrentPage = Analis;
        }


        public ICommand bMenuRashod => new RelayCommand((obj) => CurrentPage = Rashod);
        public ICommand bMenuOrganizationP => new RelayCommand((obj) => CurrentPage = OrganizationP);
        public ICommand bMenuBookeepingP => new RelayCommand((obj) => CurrentPage = BookeepingP);
        public ICommand bMenuCars_pag => new RelayCommand((obj) => CurrentPage = Cars_pag);
        public ICommand bMenuPeple_pag => new RelayCommand((obj) => CurrentPage = Peple_pag);
        public ICommand bMenuAnalis => new RelayCommand((obj) => CurrentPage = Analis);
        public ICommand bMenuProd_pag2 => new RelayCommand((obj) => CurrentPage = Prod_pag2);
        public ICommand bMenuaddBuilding => new RelayCommand((obj) => CurrentPage = addBuilding);
        public ICommand btnClose => new RelayCommand((obj) => Application.Current.Shutdown());

        public ICommand bMenuexchange => new RelayCommand((obj) =>
        {
            exchange Exchange = new exchange();
            Exchange.ShowDialog();
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



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
