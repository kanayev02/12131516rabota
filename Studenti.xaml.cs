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
    /// Логика взаимодействия для Studenti.xaml
    /// </summary>
    public partial class Studenti : Page
    {
        Пользователи user;
        List<Ученики> StudentStart = BaseClass.Base.Ученики.ToList();
        PageChange pc = new PageChange();
        public Studenti(Пользователи Polz)
        {
            InitializeComponent();
            Stud.ItemsSource = BaseClass.Base.Ученики.ToList();
            user = Polz;
            List<Классы> Class = BaseClass.Base.Классы.ToList();
            FiltClass.Items.Add("Все");
            for (int i = 0; i < Class.Count(); i++)
            {
                FiltClass.Items.Add(Class[i].Класс);
            }
            FiltClass.SelectedIndex = 0;
            DataContext = pc;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Admin(user));
        }

        private void Udalit_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Ученики Delete = BaseClass.Base.Ученики.FirstOrDefault(y => y.idученик == ind);
            BaseClass.Base.Ученики.Remove(Delete);
            BaseClass.Base.SaveChanges();
            FrameClass.mainFrame.Navigate(new Studenti(user));
            MessageBox.Show("Запись удалена");
        }

        private void Redaktirovat_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Ученики StudentUpdate = BaseClass.Base.Ученики.FirstOrDefault(y => y.idученик == ind);
            FrameClass.mainFrame.Navigate(new StudentiIzm(StudentUpdate, user));
        }

        private void Dobav_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new StudentiIzm(user));
        }
        List<Ученики> StudentFilter;
        private void Filter()
        {
            int index = FiltClass.SelectedIndex;
            if(index != 0)
            {
                StudentFilter = StudentStart.Where(x => x.Класс == index).ToList();
            }
            else
            {
                StudentFilter = StudentStart;
            }
            if(FiltFormaDnev.IsChecked == true)
            {
                StudentFilter = StudentStart.Where(x => x.Форма == 1).ToList();
            }
            if (FiltFormaVech.IsChecked == true)
            {
                StudentFilter = StudentStart.Where(x => x.Форма == 2).ToList();
            }
            Stud.ItemsSource = StudentFilter;
        }

        private void Vozr_Click(object sender, RoutedEventArgs e)
        {
            switch(Sort.SelectedIndex)
            {
                case 0:
                    StudentFilter.Sort((x, y) => x.ОценкаРусский.CompareTo(y.ОценкаРусский));
                    break;
                case 1:
                    StudentFilter.Sort((x, y) => x.ОценкаМатематика.CompareTo(y.ОценкаМатематика));
                    break;
                case 2:
                    StudentFilter.Sort((x, y) => x.ОценкаФизика.CompareTo(y.ОценкаФизика));
                    break;
            }
            Stud.Items.Refresh();
        }

        private void Ubv_Click(object sender, RoutedEventArgs e)
        {
            switch (Sort.SelectedIndex)
            {
                case 0:
                    StudentFilter.Sort((x, y) => x.ОценкаРусский.CompareTo(y.ОценкаРусский));
                    break;
                case 1:
                    StudentFilter.Sort((x, y) => x.ОценкаМатематика.CompareTo(y.ОценкаМатематика));
                    break;
                case 2:
                    StudentFilter.Sort((x, y) => x.ОценкаФизика.CompareTo(y.ОценкаФизика));
                    break;
            }
            StudentFilter.Reverse();
            Stud.Items.Refresh();
        }

        private void FiltClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void FiltFormaDnev_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void FiltFormaDnev_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void FiltFormaVech_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void FiltFormaVech_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text);
            }
            catch
            {
                pc.CountPage = StudentFilter.Count;
            }
            pc.Countlist = StudentFilter.Count;
            Stud.ItemsSource = StudentFilter.Skip(0).Take(pc.CountPage).ToList();
        }
        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            switch (tb.Uid)
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            Stud.ItemsSource = StudentFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }
    }
}
