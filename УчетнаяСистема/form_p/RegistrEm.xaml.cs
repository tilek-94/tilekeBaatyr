using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
    /// Interaction logic for RegistrEm.xaml
    /// </summary>
    public partial class RegistrEm : Window
    {
        public RegistrEm()
        {
            InitializeComponent();
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void x1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dbCon.Registr("INSERT INTO users(login,parol,rol,name,data_r,tel_nom,addres,an,data_p,vdan, address_p) VALUES(" +
                 "'" + text1.Text + "'," +
                 "'" + HashPassword(text2.Text) + "'," +
                 "'" + text3.Text + "'," +
                 "'" + text4.Text + "'," +
                 "'" + text5.Text + "'," +
                 "'" + text6.Text + "'," +
                 "'" + text7.Text + "'," +
                 "'" + text8.Text + "'," +
                 "'" + text9.Text + "'," +
                 "'" + text10.Text + "'," +
                 "'" + text11.Text + "')");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
          MessageBox.Show(  VerifyHashedPassword("AJrrOtwOE+ZkubjJaYAd2TfI1HJSaxrhczfG+fX1pJAGzT7olrGOCIIXdEZSb/Ifag==", "113").ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
    }
}
