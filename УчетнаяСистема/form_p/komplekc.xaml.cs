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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Логика взаимодействия для komplekc.xaml
    /// </summary>
    public partial class komplekc : Page
    {
        public komplekc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                case "button1" :
                    staticClass.idDom = btn1;
                   
                    break;
                case "button3":
                    staticClass.idDom = btn2;
                    break;
                case "button4":
                    staticClass.idDom = btn3;
                    break;
                case "button5":
                    staticClass.idDom = btn4;
                    break;
                case "button6":
                    staticClass.idDom = btn5;
                    break;

            }
            MainWindow mainWindow = new MainWindow();
            // mainWindow.pag.Navigate(new System.Uri("form_p/addBuilding.xaml", UriKind.RelativeOrAbsolute));

           /*
            mainWindow.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                blur.Radius = Convert.ToInt32(x);

            });*/

            // MessageBox.Show(button.Name);
            this.Visibility = Visibility.Hidden;
           
           
           
            //pag.Navigate(new System.Uri("form_p/komplekc.xaml", UriKind.RelativeOrAbsolute));

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
           /* for (int i=0;i<10;i++)
            WrapPanel1.Children.Add();*/
        }

        string btn1 = "", btn2 = "", btn3 = "", btn4 = "", btn5 = "";
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            button1.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button4.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
            button6.Visibility = Visibility.Hidden;
            button7.Visibility = Visibility.Hidden;
            button8.Visibility = Visibility.Hidden;
            button9.Visibility = Visibility.Hidden;
            button10.Visibility = Visibility.Hidden;
            button11.Visibility = Visibility.Hidden;
            button12.Visibility = Visibility.Hidden;
            button13.Visibility = Visibility.Hidden;

            dbConnect dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for (int i = 0; i < db.Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            button1.Visibility = Visibility.Visible;
                           btn1 = db.Rows[i][0].ToString();
                            textBlock1.Text = db.Rows[i][1].ToString();
                            break;
                        case 1:
                            button3.Visibility = Visibility.Visible;
                            btn2 = db.Rows[i][0].ToString();
                            textBlock3.Text = db.Rows[i][1].ToString();
                            break;
                        case 2:
                            button4.Visibility = Visibility.Visible;
                            btn3 = db.Rows[i][0].ToString();
                            textBlock4.Text = db.Rows[i][1].ToString();
                            break;
                        case 3:
                            button4.Visibility = Visibility.Visible;
                            textBlock4.Text = db.Rows[i][1].ToString();
                            break;
                        case 4:
                            btn4 = db.Rows[i][0].ToString();
                            button5.Visibility = Visibility.Visible;
                            textBlock5.Text = db.Rows[i][1].ToString();
                            break;
                        case 5:
                            btn5 = db.Rows[i][0].ToString();
                            button6.Visibility = Visibility.Visible;
                            textBlock6.Text = db.Rows[i][1].ToString();
                            break;
                        default:
                           
                            break;

                    }
                   // ComboBox_flat.Items.Add(db.Rows[i][0].ToString());

                }


            };
            
            dbCon.SoursData("SELECT * FROM dom");

        }
    }
}
