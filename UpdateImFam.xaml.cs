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
    /// Логика взаимодействия для UpdateImFam.xaml
    /// </summary>
    public partial class UpdateImFam : Window
    {
        Пользователи user;
        public UpdateImFam(Пользователи Polz)
        {
            InitializeComponent();
            user = Polz;
            Name.Text = user.Имя;
            Fam.Text = user.Фамилия;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Имя = Name.Text;
            user.Фамилия = Fam.Text;
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Изменения сохранены");
            this.Close();
        }
    }
}
