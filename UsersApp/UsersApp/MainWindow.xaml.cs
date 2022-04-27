using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();

            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            RegButton.BeginAnimation(Button.WidthProperty, btnAnimation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Слишком маленький логин!";
                textBoxLogin.Background = Brushes.DarkRed;
            } else if (pass.Length < 5)
            {
                passBox.ToolTip = "Слишком маленький пароль!";
                passBox.Background = Brushes.DarkRed;
            } else if (pass != pass2)
            {
                passBox2.ToolTip = "Разные пароли";
                passBox2.Background = Brushes.DarkRed;
            } else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "ошибка ";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("good");


                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }

            
        }
        private void Button_window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
