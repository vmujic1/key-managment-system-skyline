using key_managment_system.DBContexts;
using key_managment_system.Dtos;
using key_managment_system.NewFolder;
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
using System.Windows.Shapes;

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for InfoRoomPage.xaml
    /// </summary>
    public partial class InfoRoomPage : Window
    {
        private InfoRoomPageViewModel viewModel;
        public event EventHandler DataChanged;
        private int roomId;

        public List<UserOfficeDto> Users { get; set; }

        public async void UpdateTitle()
        {
            Context context = new Context();
            var room = await context.Rooms.FirstOrDefaultAsync(r  => r.Id == roomId);
            this.Title = room.Name;
        }
        public InfoRoomPage(int id)
        {
            viewModel = new InfoRoomPageViewModel();
            InitializeComponent();
            Loaded += Load;
            roomId = id;
            UpdateTitle();
            
        }

        private async void Load(object sender, RoutedEventArgs args)
        {
            Users = await viewModel.GetUsersFromDatabase(roomId);
            DataGrid.ItemsSource = Users;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
