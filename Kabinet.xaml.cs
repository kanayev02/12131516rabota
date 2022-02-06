using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Page
    {
        Пользователи user;
        string path;
        ФотоПользователи Foto;
        public Kabinet(Пользователи Polz)
        {
            InitializeComponent();
            user = Polz;
            UserName.Text = user.Имя;
            UserFam.Text = user.Фамилия;
            if (user.ФотоПользователи != null && user.ФотоПользователи.PhotoBinary != null)
            {
                byte[] BArr = user.ФотоПользователи.PhotoBinary;
                BitmapImage BI = new BitmapImage();
                using (MemoryStream MS = new MemoryStream(BArr))
                {
                    BI.BeginInit();
                    BI.StreamSource = MS;
                    BI.CacheOption = BitmapCacheOption.OnLoad;
                    BI.EndInit();
                }
                UserPhotoImage.Source = BI;
            }
        }

        private void IzmImFam_Click(object sender, RoutedEventArgs e)
        {
            UpdateImFam Win = new UpdateImFam(user);
            Win.ShowDialog();
            FrameClass.mainFrame.Navigate(new Kabinet(user));
        }

        private void IzmLogPar_Click(object sender, RoutedEventArgs e)
        {
            UpdateLogPar Win = new UpdateLogPar(user);
            Win.ShowDialog();
            FrameClass.mainFrame.Navigate(new Kabinet(user));
        }

        private void IzmFoto_Click(object sender, RoutedEventArgs e)
        {
            ФотоПользователи U = BaseClass.Base.ФотоПользователи.FirstOrDefault(x => x.idпользователь == user.idпользователь);
            if (U == null)
            {
                Foto = new ФотоПользователи();
                Foto.idпользователь = user.idпользователь;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                Foto.PhotoBinary = Barray;
                BaseClass.Base.ФотоПользователи.Add(Foto);
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Картинка добавлена");
            }
            else 
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                U.PhotoBinary = Barray;
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Картинка изменена");
            }

            FrameClass.mainFrame.Navigate(new Kabinet(user));
        }

        private void Vihod_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Vhod());
        }
    }
}
