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
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Page
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            int ipol = Pol.SelectedIndex + 1;
            int HashKod = Parol.Password.GetHashCode();
            Пользователи Polz = new Пользователи() { Имя = Name.Text, Фамилия = Famil.Text, Логин = Login.Text, Пароль = HashKod, Пол = ipol, Роль = 1 };
            BaseClass.Base.Пользователи.Add(Polz);
            BaseClass.Base.SaveChanges();
            MessageBox.Show("пользователь зарегистрирован", "Регистрация");
        }
    }
}
