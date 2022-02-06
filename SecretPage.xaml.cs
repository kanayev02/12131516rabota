using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SecretPage.xaml
    /// </summary>
    public partial class SecretPage : Page
    {
        List<Class> Student = new List<Class>();
        public SecretPage()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Students.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Sarr = sr.ReadLine().Split(';');
                    Student.Add(new Class() { Name = Sarr[0], Fam = Sarr[1], Clas = Sarr[2], Forma = Sarr[3], Russk = Sarr[4], Matem = Sarr[5], Fizika = Sarr[6] });
                }
            }
            Stud.ItemsSource = Student;
        }

        private void Naiti_Click(object sender, RoutedEventArgs e)
        {
            List<Class> Poisk = new List<Class>();
            for (int i = 0; i < Student.Count; i++)
            {
                if (Poi.Text == Student[i].Fam)
                {
                    Class poi = new Class { Name = Student[i].Name, Fam = Student[i].Fam, Clas = Student[i].Clas, Forma = Student[i].Forma, Russk = Student[i].Russk, Matem = Student[i].Matem, Fizika = Student[i].Fizika };
                    Poisk.Add(poi);
                }
            }
            Stud.ItemsSource = Poisk;
        }
    }
}
