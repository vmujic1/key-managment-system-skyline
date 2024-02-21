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
        public Visualisation()
        {
            InitializeComponent();
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

    }
}
