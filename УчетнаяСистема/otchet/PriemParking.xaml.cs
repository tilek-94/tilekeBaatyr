﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема.otchet
{
    /// <summary>
    /// Interaction logic for PriemParking.xaml
    /// </summary>
    public partial class PriemParking : Window
    {
        public PriemParking()
        {
            InitializeComponent();
            this.ComboBox_n.SelectedValuePath = "Key";
            this.ComboBox_n.DisplayMemberPath = "Value";
        }
        public delegate void DelegateM();
        public event DelegateM del;
        dbConnect dbCon = new dbConnect();
        public double KGS = 0, USD = 0;
        public string d1 = "0", d2 = "0", m1 = "0", m2 = "0", y1 = "0", y2 = "0";
        ChartRapyment chartRapyment = new ChartRapyment();
        string client_id = "0";
        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            form_p.Window1 window1 = new form_p.Window1();
            window1.ValueChanged += new Action<string, string>((x, y) =>
            {
                client_id = x;
                AddNumber(client_id);
                text1.Text = y;

            });
            window1.ShowDialog();

        }
        void AddNumber(string IdClient)
        {
            ComboBox_n.Items.Clear();
            dbCon.connection.Open();
            string sql = "SELECT id, number_f FROM prod_parking z WHERE z.klient_id='" + IdClient + "' AND z.dom_id='" + staticClass.StaticDomID + "'";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ComboBox_n.Items.Add(new KeyValuePair<string, string>(reader[0].ToString(), reader[1].ToString()));
            }
            dbCon.connection.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_Sersh_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void BasaQuery(string ZakazId)
        {
            dbCon.connection.Open();
            string sql = "SELECT * FROM _graf_parking WHERE id='" + ZakazId + "'";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sumUsd = reader[5].ToString();

                string sumKgs = reader[6].ToString();

                d1 = reader[10].ToString();
                m1 = reader[11].ToString();
                y1 = reader[12].ToString();
                d2 = reader[13].ToString();
                m2 = reader[14].ToString();
                y2 = reader[15].ToString();

                USD = Convert.ToDouble(sumUsd) / Convert.ToDouble(reader[9].ToString());
                KGS = Convert.ToDouble(sumKgs) / Convert.ToDouble(reader[9].ToString());

            }
            dbCon.connection.Close();
            string SqlQry = "SELECT SUM(summa), SUM(usd),DATE_FORMAT(data_month, '%m-%Y') " +
                "FROM repayment_parking WHERE client_id='" + client_id + "' AND dom_id='" + staticClass.StaticDomID + "' AND number_f='" + ComboBox_n.Text + "' GROUP by DATE_FORMAT(data_month, '%yyyy %m')";
            
            chartRapyment.Display(SqlQry, Math.Round(KGS, 2), Math.Round(USD, 2), myDataGrid, d1, m1, y1, d2, m2, y2);

        }


        private void registr_btn_Click(object sender, RoutedEventArgs e)
        {
            if (staticClass.StaticDomID!="" && ComboBox_n.Text!="" && client_id.ToString()!=""
                && textBox1.Text!="" && textBox3.Text!="" && data1.DisplayDate.ToString("yyyy-MM-dd")!="") { 
            dbCon.Registr("INSERT INTO repayment_parking(" +
                "dom_id," +
                "number_f," +
                "client_id," +
                "usd," +
                "summa," +
                "data_month," +
                "emp)VALUES(" +
                "'" + staticClass.StaticDomID + "'," +
                "'" + ComboBox_n.Text + "'," +
                "'" + client_id.ToString() + "'," +
                "'" + textBox1.Text.ToString().Replace(',', '.') + "'," +
                "'" + textBox3.Text.ToString().Replace(',', '.') + "'," +
                "'" + data1.DisplayDate.ToString("yyyy-MM-dd") + "'," +
                "'"+staticClass.StaticEmplayID+"')");
            data1.Text = "";
            text1.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            BasaQuery(value);

            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните все полии!";
                messageM.Owner = this;
                messageM.ShowDialog();
            }
        }
        string value = "0";
        private void ComboBox_P_DropDownClosed(object sender, EventArgs e)
        {
            // ComboBoxItem typeItem = (ComboBoxItem)ComboBox_n.SelectedValue;
            if (ComboBox_n.SelectedValue != null)
            {
                value = ComboBox_n.SelectedValue.ToString();
                BasaQuery(value);
            }
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            del();
            this.Close();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
