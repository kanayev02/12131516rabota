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
    /// Логика взаимодействия для StudentiIzm.xaml
    /// </summary>
    public partial class StudentiIzm : Page
    {
        Пользователи user;
        Ученики Student = new Ученики();
        bool flag;
        public StudentiIzm(Пользователи Polz)
        {
            InitializeComponent();
            user = Polz;
            flag = true;
            Class.ItemsSource = BaseClass.Base.Классы.ToList();
            Class.SelectedValuePath = "idкласс";
            Class.DisplayMemberPath = "Класс";
        }
        public StudentiIzm(Ученики StudentUpdate, Пользователи Polz)
        {
            InitializeComponent();
            user = Polz;
            Student = StudentUpdate;
            Name.Text = Student.Имя;
            Fam.Text = Student.Фамилия;
            switch(Student.Форма)
            {
                case 1:
                    FormaDnev.IsChecked = true;
                    break;
                case 2:
                    FormaVech.IsChecked = true;
                    break;
            }
            Class.ItemsSource = BaseClass.Base.Классы.ToList();
            Class.SelectedValuePath = "idкласс";
            Class.DisplayMemberPath = "Класс";
            Class.SelectedIndex = (int)Student.Класс - 1;
            Rus.Text = Student.ОценкаРусский.ToString();
            Matem.Text = Student.ОценкаМатематика.ToString();
            Fiz.Text = Student.ОценкаФизика.ToString();
        }

        private void Zapisat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int forma = 0;
                if(FormaDnev.IsChecked == true)
                {
                    forma = 1;
                }
                if (FormaVech.IsChecked == true)
                {
                    forma = 2;
                }
                Student.Имя = Name.Text;
                Student.Фамилия = Fam.Text;
                Student.Класс = Class.SelectedIndex + 1;
                Student.Форма = forma;
                Student.ОценкаМатематика = Convert.ToInt32(Matem.Text);
                Student.ОценкаРусский = Convert.ToInt32(Rus.Text);
                Student.ОценкаФизика = Convert.ToInt32(Fiz.Text);
                if(flag == true)
                {
                    BaseClass.Base.Ученики.Add(Student);
                }
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны");
                FrameClass.mainFrame.Navigate(new Studenti(user));
            }
            catch
            {
                MessageBox.Show("Данные не записаны");
            }
        }
    }
}
