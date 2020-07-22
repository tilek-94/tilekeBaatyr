using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegistrEm.xaml
    /// </summary>
    public partial class RegistrEm : Window
    {
        public RegistrEm()
        {
            InitializeComponent();
            this.ComboBox_n.SelectedValuePath = "Key";
            this.ComboBox_n.DisplayMemberPath = "Value";
        }
        dbConnect dbCon = new dbConnect();
        private void Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textbox_searsh_KeyDown(object sender, KeyEventArgs e)
        {

            //  HashPassword("tilek");
        }

        private void RegistData(string s)
        {
            dbCon.eventDysplay += delegate (DataTable db)
            {
                dataGridView1.ItemsSource = db.DefaultView;
            };
            dbCon.SoursData(s);

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        string id_1 = "";
        private void x1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGridView1.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                MessageO messageO = new MessageO();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "users";
                    messageO.del_ += () => RegistData("SELECT * FROM users WHERE remov='0' ");
                    messageO.ShowDialog();
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text != "" && textPassword.Password != "" && ComboBox_n.Text != "" && text4.Text != "") {
                if (textPassword.Password.ToString()== textPassword2.Password.ToString()) { 
                dbCon.Registr("INSERT INTO users(login,parol,rol,name,data_r,tel_nom,addres,an,data_p,vdan, address_p) VALUES(" +
                     "'" + text1.Text + "'," +
                     "'" + HashPassword(textPassword.Password.ToString()) + "'," +
                     "'" + value + "'," +
                     "'" + text4.Text + "'," +
                     "'" + text5.Text + "'," +
                     "'" + text6.Text + "'," +
                     "'" + text7.Text + "'," +
                     "'" + text8.Text + "'," +
                     "'" + text9.Text + "'," +
                     "'" + text10.Text + "'," +
                     "'" + text11.Text + "')");
                RegistData("SELECT * FROM users WHERE remov='0' ");
                text1.Text = "";
                ComboBox_n.Text = "";
                textPassword.Password = "";
                textPassword2.Password = "";
                text4.Text = "";
                text5.Text = "";
                text6.Text = "";
                text7.Text = "";
                text8.Text = "";
                text9.Text = "";
                text10.Text = "";
                text11.Text = "";
                }
                else
                {
                    MessageM messageM = new MessageM();
                    messageM.Mees = "Пароли не совпадают!";
                    messageM.ShowDialog();
                }
            }
            else
            {
                MessageM messageM = new MessageM();
                messageM.Mees = "Заполните все полии!";
                messageM.ShowDialog();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,a-z A-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        void AddNumber()
        {
            ComboBox_n.Items.Clear();
            dbCon.connection.Open();
            string sql = "SELECT name, name_p FROM roles";
            MySqlCommand command = new MySqlCommand(sql, dbCon.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ComboBox_n.Items.Add(new KeyValuePair<string, string>(reader[0].ToString(), reader[1].ToString()));
            }
            dbCon.connection.Close();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(VerifyHashedPassword("AJrrOtwOE+ZkubjJaYAd2TfI1HJSaxrhczfG+fX1pJAGzT7olrGOCIIXdEZSb/Ifag==", "113").ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistData("SELECT * FROM users WHERE remov='0' ");
            AddNumber();
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }
        string value = "";
        private void text3_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void ComboBox_P_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox_n.SelectedValue != null)
            value = ComboBox_n.SelectedValue.ToString();


            MessageBox.Show(value);
        }
    }
}
