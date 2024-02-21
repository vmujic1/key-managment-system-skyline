using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
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

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for Visualisation.xaml
    /// </summary>
    public partial class Visualisation : UserControl
    {

        
        

        public async void UpdateUserDatabase()
        {
            Context context = new Context();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == UserManager.Instance.UserId);
            user.CurrentRoomId = UserManager.Instance.CurrentRoomId;
            await context.SaveChangesAsync();
        }

        public void UpdateRoomColor()
        {
            o1.Fill = Brushes.LightGray;
            o2.Fill = Brushes.LightGray;
            o3.Fill = Brushes.LightGray;
            o4.Fill = Brushes.LightGray;
            o5.Fill = Brushes.LightGray;
            o6.Fill = Brushes.LightGray;
            o7.Fill = Brushes.LightGray;
            o8.Fill = Brushes.LightGray;
            o9.Fill = Brushes.LightGray;
            o10.Fill = Brushes.LightGray;
            o11.Fill = Brushes.LightGray;
            o12.Fill = Brushes.LightGray;

            if (UserManager.Instance.CurrentRoomId == 1)
            {
                o1.Fill = Brushes.Navy;
            }
            else if(UserManager.Instance.CurrentRoomId == 2)
            {
                o2.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 3)
            {
                o3.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 4)
            {
                o4.Fill = Brushes.Navy;

            }
            else if (UserManager.Instance.CurrentRoomId == 5)
            {
                o5.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 6)
            {
                o6.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 7)
            {
                o7.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 8)
            {
                o8.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 9)
            {
                o9.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 10)
            {
                o10.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 11)
            {
                o11.Fill = Brushes.Navy;
            }
            else if (UserManager.Instance.CurrentRoomId == 12)
            {
                o12.Fill = Brushes.Navy;
            }
        }
        public async void UpdateDoors()
        {
            UpdateUserDatabase();
            UpdateRoomColor();

            await Task.Delay(500);
            
            Qr1Btn.Visibility = Visibility.Hidden;
            Qr2Btn.Visibility = Visibility.Hidden;
            Qr3Btn.Visibility = Visibility.Hidden;
            Cr1Btn.Visibility = Visibility.Hidden;
            Cr2Btn.Visibility = Visibility.Hidden;
            Of1Btn.Visibility = Visibility.Hidden;
            Of2Btn.Visibility = Visibility.Hidden;
            StaBtn.Visibility = Visibility.Hidden;
            StrBtn.Visibility = Visibility.Hidden;
            ToBtn.Visibility = Visibility.Hidden;
            WsBtn.Visibility = Visibility.Hidden;
            
            if (UserManager.Instance.CurrentRoomId == 1)
            {
                Cr1Btn.Visibility= Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 2)
            {
                Cr2Btn.Visibility= Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 3)
            {
                Qr1Btn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 4)
            {
                Qr2Btn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 5)
            {
                Qr3Btn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 6)
            {
                StaBtn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 7)
            {
                Of1Btn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 8)
            {
                Of2Btn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 9)
            {
                StrBtn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 10)
            {
                ToBtn.Visibility = Visibility.Visible;
                return;
            }
            else if(UserManager.Instance.CurrentRoomId == 11)
            {
                WsBtn.Visibility = Visibility.Visible;
                ToBtn.Visibility = Visibility.Visible;
                Of2Btn.Visibility = Visibility.Visible;
                Of1Btn.Visibility = Visibility.Visible;
                StaBtn.Visibility = Visibility.Visible;
                Qr2Btn.Visibility = Visibility.Visible;
                Qr1Btn.Visibility = Visibility.Visible;
                Cr1Btn.Visibility = Visibility.Visible;
                Cr2Btn.Visibility = Visibility.Visible;
                return;
            }
            else if (UserManager.Instance.CurrentRoomId == 12)
            {
                Qr3Btn.Visibility= Visibility.Visible;
                StrBtn.Visibility= Visibility.Visible;
                WsBtn.Visibility = Visibility.Visible;
                return;
            }
        }

        public Visualisation()
        {
            
            
            
            InitializeComponent();
            UpdateDoors();



        }

        private void strDown(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(1);
            page.Show();
        }

        private void Qr3Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(5);
            page.Show();
        }

        private void Qr2Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(4);
            page.Show();
        }

        private void Qr1Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(3);
            page.Show();
        }

        private void Cr2Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(2);
            page.Show();
        }
        private void Cr1Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(1);
            page.Show();
        }

        private void StaDown(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(6);
            page.Show();
        }

        private void Of1Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(7);
            page.Show();
        }
        private void Of2Down(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(8);
            page.Show();
        }

        private void ToDown(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(10);
            page.Show();
        }
        private void OsDown(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(11);
            page.Show();
        }

        private void WsDown(object sender, RoutedEventArgs e)
        {
            InfoRoomPage page = new InfoRoomPage(12);
            page.Show();
        }

        public void StrBtnDown(object sender, RoutedEventArgs e)
        {
            if(UserManager.Instance.CurrentRoomId == 9)
            {
                UserManager.Instance.CurrentRoomId = 12;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 9;
            }
            
            UpdateDoors();
            
        }

        public void Qr3BtnDown(object sender, RoutedEventArgs e)
        {

            if (UserManager.Instance.CurrentRoomId == 5)
            {
                UserManager.Instance.CurrentRoomId = 12;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 5;
            }
            
            UpdateDoors();
            
        }

        public void Qr2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 4)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 4;
            }
            
            UpdateDoors();
        }

        public void Qr1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 3)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 3;
            }
           
            UpdateDoors();
        }

        public void Cr2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 2)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 2;
            }
            
            UpdateDoors();
        }
        public void Cr1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 1)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 1;
            }
            
            UpdateDoors();
        }

        public void StaBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 6)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 6;
            }
            
            UpdateDoors();
        }

        private void Of1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 7)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 7;
            }
            
            UpdateDoors();


        }
        private void Of2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 8)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 8;
            }
            
            UpdateDoors();

            
        }

        public void ToBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 10)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 10;
            }
            
            UpdateDoors();
        }

        public void WsBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 12)
            {
                UserManager.Instance.CurrentRoomId = 11;
            }
            else
            {
                UserManager.Instance.CurrentRoomId = 12;
            }
            
            
            UpdateDoors();
        }

        
    }
}
