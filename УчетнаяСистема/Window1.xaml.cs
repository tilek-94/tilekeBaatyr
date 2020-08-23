using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using УчетнаяСистема.All_classes;

namespace УчетнаяСистема
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        dbConnect dbCon;
        public event Action<string,string> ValueChanged;
        public Window1()
        {
            InitializeComponent();
           
        }
        int f { get; set; } = 0;
        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            if (LogTextBox.Text!="" && PassTextBox.Password!="" ) { 
            string rol="",password="";

            dbCon = new dbConnect();
            dbCon.eventDysplay += delegate (DataTable db)
            {
                if (db.Rows.Count > 0) { 
                rol = db.Rows[0][0].ToString();
                password= db.Rows[0][1].ToString();
                staticClass.StaticEmplayID= db.Rows[0][2].ToString();
                }
            };
            dbCon.SoursData("SELECT u.rol, u.parol, u.id FROM users u WHERE u.login = '" + LogTextBox.Text + "' ");
                      
            
            
            if (VerifyHashedPassword(password, PassTextBox.Password.ToString()))
            {
                ValueChanged("0", rol);
                f = 1;
                // mainWindow.blur.Radius = 0;
                this.Close();


            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
            }


            }

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

        private void Window_Closed(object sender, EventArgs e)
        {
            if (f != 1)
                Application.Current.Shutdown();

        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            f = 0;
            this.Close();
        }

        private void PassTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (LogTextBox.Text != "" && PassTextBox.Password != "")
                {
                    string rol = "", password = "";

                    dbCon = new dbConnect();
                    dbCon.eventDysplay += delegate (DataTable db)
                    {
                        if (db.Rows.Count>0)
                        {
                            rol = db.Rows[0][0].ToString();
                            password = db.Rows[0][1].ToString();
                            staticClass.StaticEmplayID = db.Rows[0][2].ToString();
                        }
                    };
                    dbCon.SoursData("SELECT u.rol, u.parol, u.id FROM users u WHERE u.login = '" + LogTextBox.Text + "' ");



                    if (VerifyHashedPassword(password, PassTextBox.Password.ToString()))
                    {
                        ValueChanged("0", rol);
                        f = 1;

                        // mainWindow.blur.Radius = 0;
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("Не верный логин или пароль");
                    }


                }

            }
        }
    }
}
