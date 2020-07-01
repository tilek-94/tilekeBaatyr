using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Kurs.xaml
    /// </summary>
    public partial class Kurs : Window
    {
        public Kurs()
        {
            InitializeComponent();
        }
        public delegate void MessageDel(string id,string usd, string eur, string rub);
        public event MessageDel del_;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        string[] kurs = new string[5];
        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {


            
             Display(); 

        }

         void Display()
        {
            var desctop = System.Windows.SystemParameters.WorkArea;
            this.Left = desctop.Right - this.Width;
            this.Top = desctop.Top + 100;

            kurs[1] = "0";
            kurs[2] = "0";
            kurs[3] = "0";
            kurs[4] = "0";
            int i = 0;
            try
            {
                string line = "";
                WebRequest request = WebRequest.Create("https://www.nbkr.kg/XML/daily.xml");
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        line = reader.ReadToEnd();

                    }
                }
                response.Close();


                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(line);
                // получим корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;
                // обход всех узлов в корневом элементе
                i = 0;
                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.InnerText != "1")
                        {
                            i++;
                            kurs[i] = childnode.InnerText;

                        }

                    }

                }
            }
            catch
            {
                Connect.Text="Ошибка соидинение!";
            }

            nusd.Text = kurs[1];
            neur.Text = kurs[2];
            nrub.Text = kurs[4];

        }

        string dollar, euro, rubl;

        private void btnNbkr_Click(object sender, RoutedEventArgs e)
        {
            dollar = kurs[1].Replace(',','.'); 
            euro = kurs[2].Replace(',', '.'); 
            rubl = kurs[4].Replace(',', '.');
            if (dollar == "") dollar = "0";
            if (euro == "") euro = "0";
            if (rubl == "") rubl = "0";
            dbCon.Registr("INSERT INTO currency(usd,eur,rub) " +
                "VALUE('" + dollar + "','" + euro + "','" + rubl + "')");
            string id = dbCon.DisplayReturn("SELECT id FROM currency where usd='" + dollar + "' and eur='" + euro + "' and rub='" + rubl + "'");
            if (del_ != null)
                del_(id, dollar, euro, rubl);
            this.Close();
        }

        dbConnect dbCon = new dbConnect();
        private void btnVal_Click(object sender, RoutedEventArgs e)
        {
             dollar = USD.Text.Replace(',', '.');
             euro = EUR.Text.Replace(',', '.');
             rubl = RUB.Text.Replace(',', '.');
            if (dollar == "") dollar = "0";
            if (euro == "") euro = "0";
            if (rubl == "") rubl = "0";
            dbCon.Registr("INSERT INTO currency(usd,eur,rub) " +
                "VALUE('"+ dollar+ "','"+ euro + "','"+ rubl + "')");
            string id = dbCon.DisplayReturn("SELECT id FROM currency where usd='" + dollar + "' and eur='" + euro + "' and rub='" + rubl + "'");
            if (del_ != null)
                del_(id, dollar, euro, rubl);

            this.Close();
        }
    }
}
