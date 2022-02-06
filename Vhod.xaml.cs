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

namespace _91011rabota
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Page
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int HashKod = Parol.Password.GetHashCode();
                Пользователи Polz = BaseClass.Base.Пользователи.FirstOrDefault(x => x.Логин == Login.Text && x.Пароль == HashKod);
                if (Polz != null)
                {
                    if (Polz.Роль == 2)
                    {
                        MessageBox.Show("Добро пожаловать администратор", "Авторизация");
                        FrameClass.mainFrame.Navigate(new Admin(Polz));
                    }
                    else
                    {
                        MessageBox.Show("Здравствуйте пользователь", "Авторизация");
                        FrameClass.mainFrame.Navigate(new SecretPage());
                    }
                }
            }
            catch
            {
                MessageBox.Show("ошибка ввода", "Авторизация");

            }
        }
    }
}
