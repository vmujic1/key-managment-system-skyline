using key_managment_system.DBContexts;
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
    /// Interaction logic for Requests.xaml
    /// </summary>
    public partial class Requests : UserControl
    {
        public Requests()
        {
            InitializeComponent();
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {

        }

        private async void ApproveRequest(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            Context c = new Context();
            var req = await c.KeycardRequests.FirstOrDefaultAsync(k => k.Id == Id);
            RequestNewKeycard edit = new RequestNewKeycard(req.KeycardId);
            bool? dialogResult = edit.ShowDialog();
            DataGrid.ItemsSource = await c.KeycardRequests.ToListAsync();g
            await Task.Delay(500);


            
        }
    }
}
