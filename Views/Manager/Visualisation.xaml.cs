﻿using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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

        
        public bool? Permission {  get; set; }


        public async void CheckUserPermission(int roomId, int userId)
        {
             Context context = new Context();
                   Permission = await context.Users
                .Join(context.Keycards, u => u.KeycardId, k => k.Id, (u, k) => new { User = u, Keycard = k })
                .Where(uk => uk.User.Id == userId)
                .Join(context.Rooms, uk => 1, r => 1, (uk, r) => new { uk.User, uk.Keycard, Room = r })
                .Where(ukr => ukr.Room.Id == roomId)
                .Select(ukr => ukr.Keycard.AccessLevel >= ukr.Room.AccessLevel)
                .FirstOrDefaultAsync();

        }


        public async void AddRecord(string keycardId, int roomId)
        {
            Context context = new Context();
            context.Records.Add(new Record
            {
                SerialNumber = keycardId,
                TimeStamp = DateTime.Now,
                RoomId = roomId
            });

            await context.SaveChangesAsync();
        }

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
                
                    Of1Btn.Visibility = Visibility.Visible;
               
                    Of2Btn.Visibility = Visibility.Visible;
                
                    ToBtn.Visibility = Visibility.Visible;
                
                    StaBtn.Visibility = Visibility.Visible;
               
                    Qr2Btn.Visibility = Visibility.Visible;
               
                    Qr1Btn.Visibility = Visibility.Visible;
                
                    Cr2Btn.Visibility = Visibility.Visible;
               
                    Cr1Btn.Visibility = Visibility.Visible;
               
                
                return;
            }
            else if (UserManager.Instance.CurrentRoomId == 12)
            {
                
                    Qr3Btn.Visibility = Visibility.Visible;
               
                    StrBtn.Visibility = Visibility.Visible;
               
                    WsBtn.Visibility = Visibility.Visible;
               
                
                return;
            }
        }

        public void SendNotification(int roomId, int userId) { }

        public Visualisation()
        {

            
            InitializeComponent();

            
            UpdateDoors();

            if (UserManager.Instance.CurrentRoomId == 0)
            {
                UserManager.Instance.CurrentRoomId = 6;
                UpdateUserDatabase();
            }


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

        public async void StrBtnDown(object sender, RoutedEventArgs e)
        {
            if(UserManager.Instance.CurrentRoomId == 9)
            {
                CheckUserPermission(12, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(12, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 12);
                    UserManager.Instance.CurrentRoomId = 12;
                }
            }
            else
            {
                CheckUserPermission(9, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(9, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 9);
                    UserManager.Instance.CurrentRoomId = 9;
                }
            }
            
            UpdateDoors();
            
        }

        public async void Qr3BtnDown(object sender, RoutedEventArgs e)
        {

            if (UserManager.Instance.CurrentRoomId == 5)
            {
                CheckUserPermission(12, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(12, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 12);
                    UserManager.Instance.CurrentRoomId = 12;
                }
            }
            else
            {
                CheckUserPermission(5, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(5, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 5);
                    UserManager.Instance.CurrentRoomId = 5;
                }
            }
            
            UpdateDoors();
            
        }

        public async void Qr2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 4)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(4, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(4, UserManager.Instance.UserId);
                }
                else
                {
                    
                    AddRecord(UserManager.Instance.SerialNumber, 4);
                    UserManager.Instance.CurrentRoomId = 4;
                    
                }
            }
            
            UpdateDoors();
        }

        public async void Qr1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 3)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(3, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(3, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 3);
                    UserManager.Instance.CurrentRoomId = 3;
                }
            }
           
            UpdateDoors();
        }

        public async void Cr2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 2)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(2, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(2, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 2);
                    UserManager.Instance.CurrentRoomId = 2;
                }
            }
            
            UpdateDoors();
        }
        public async void Cr1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 1)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(1, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(1, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 1);
                    UserManager.Instance.CurrentRoomId = 1;
                }
            }
            
            UpdateDoors();
        }

        public async void StaBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 6)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(6, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(6, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 6);

                    UserManager.Instance.CurrentRoomId = 6;
                }
            }
            
            UpdateDoors();
        }

        private async void Of1BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 7)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(7, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(7, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 7);
                    UserManager.Instance.CurrentRoomId = 7;
                }
            }
            
            UpdateDoors();


        }
        private async void Of2BtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 8)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(8, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(8, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 8);
                    UserManager.Instance.CurrentRoomId = 8;
                }
            }
            
            UpdateDoors();

            
           


        }

        public async void ToBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 10)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(10, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(10, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 10);
                    UserManager.Instance.CurrentRoomId = 10;
                }
            }
            
            UpdateDoors();
        }

        public async void WsBtnDown(object sender, RoutedEventArgs e)
        {
            if (UserManager.Instance.CurrentRoomId == 12)
            {
                CheckUserPermission(11, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(11, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 11);
                    UserManager.Instance.CurrentRoomId = 11;
                }
            }
            else
            {
                CheckUserPermission(12, UserManager.Instance.UserId);
                await Task.Delay(300);
                if ((bool)!Permission)
                {
                    MessageBox.Show("Permission is not allowed!");
                    SendNotification(12, UserManager.Instance.UserId);
                }
                else
                {
                    AddRecord(UserManager.Instance.SerialNumber, 12);
                    UserManager.Instance.CurrentRoomId = 12;
                }
            }
            
            
            UpdateDoors();
        }

        
    }
}
