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
using System.Windows.Shapes;

namespace _91011rabota
{
    /// <summary>
    /// Логика взаимодействия для UpdateLogPar.xaml
    /// </summary>
    public partial class UpdateLogPar : Window
    {
        Пользователи user;
        public UpdateLogPar(Пользователи Polz)
        {
            InitializeComponent();
            user = Polz;
            Login.Text = user.Логин;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Логин = Login.Text;
            int par = Par.Password.GetHashCode();
            user.Пароль = par;
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Изменения сохранены");
            this.Close();
        }
    }
}
