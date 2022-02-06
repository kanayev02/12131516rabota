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
    /// Логика взаимодействия для Polzovateli.xaml
    /// </summary>
    public partial class Polzovateli : Page
    {
        Пользователи user;
        public Polzovateli(Пользователи Polz)
        {
            InitializeComponent();
            Stud.ItemsSource = BaseClass.Base.Пользователи.ToList();
            user = Polz;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Admin(user));
        }
    }
}
