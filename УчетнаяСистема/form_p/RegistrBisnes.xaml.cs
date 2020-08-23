using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
           /* this.ComboBoxN.SelectedValuePath = "Key";
            this.ComboBoxN.DisplayMemberPath = "Value";*/
        }

        dbConnect dbCon;
        string id_1="";
        

       


        
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
        

        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   
            Display3();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
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
