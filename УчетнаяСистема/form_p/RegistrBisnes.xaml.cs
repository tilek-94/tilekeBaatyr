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
using System.Windows.Shapes;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.form_p
{
    /// <summary>
    /// Interaction logic for RegistrBisnes.xaml
    /// </summary>
    public partial class RegistrBisnes : Window
    {
        public RegistrBisnes()
        {
            InitializeComponent();
            this.ComboBoxN.SelectedValuePath = "Key";
            this.ComboBoxN.DisplayMemberPath = "Value";
        }

        dbConnect dbCon;
        string id_1="";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
             DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "phous";
                    messageO.del_ += () => Display();
                    messageO.ShowDialog();
                }
            }
        }

        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (value != 0 && text2.Text != "" & text3.Text != "")
            {
                dbCon.Registr("insert into typephous(phous_id,name,m2) values('" + value + "','" + text2.Text + "','" + text3.Text.Replace(',', '.') + "')");
            }
            else
            {
                MessageBox.Show("Выберите пентхоус");
            }
        }

       private void Display()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGrid1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM phous" +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
            AddDataCom();

        }

        private void Display2()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGrid2.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM typephous" +
                " WHERE phous_id='" + value + "' and remov='0'");
           

        }
        private void Display3()
        {
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGrid3.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData("SELECT * FROM bisnesclass" +
                " WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");


        }
        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text != "") { 
            dbCon = new dbConnect();
            dbCon.Registr("INSERT INTO phous(name,dom_id) VALUES('"+ text1.Text + "','"+staticClass.StaticDomID+"')");
                Display();
                text1.Text = "";
            }
        }

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDataCom()
        {
            ComboBoxN.Items.Clear();
            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                for(int i=0;i<db.Rows.Count;i++)
            ComboBoxN.Items.Add(new KeyValuePair<string, string>(db.Rows[i][0].ToString(), db.Rows[i][1].ToString()));
            };
            dbCon.SoursData("SELECT * FROM phous" +
               " WHERE dom_id='" + staticClass.StaticDomID + "' and remov='0'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   Display();
            Display3();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }
        int value=0;
        private void ComboBoxN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dbCon = new dbConnect();
            if (ComboBoxN.SelectedValue != null)
                value = Convert.ToInt16( ComboBoxN.SelectedValue);
            
            Display2();

        }

        private void x2_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid2.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "typephous";
                    messageO.del_ += () => Display2();
                    messageO.ShowDialog();
                }
            }
        }

        private void bRegistr_Click(object sender, RoutedEventArgs e)
        {
            dbCon = new dbConnect();
            if(text11.Text !="" && text12.Text != "") { 
            dbCon.Registr("INSERT INTO bisnesclass(name,m2,info,dom_id) " +
                "VALUES('"+text11.Text+"','"+text12.Text+"','"+text13.Text+"','"+staticClass.StaticDomID+"')");
                Display3();
                text11.Text = "";
                text12.Text = "";
                text13.Text = "";
            }
        }

        private void x3_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid3.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "bisnesclass";
                    messageO.del_ += () => Display3();
                    messageO.ShowDialog();
                }
            }
        }
    }
}
