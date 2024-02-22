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
using System.Windows.Shapes;

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for RequestNewKeycard.xaml
    /// </summary>
    public partial class RequestNewKeycard : Window
    {
        public int Id { get; set; }
        public RequestNewKeycard(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private async void GenerateNew(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            var card =   await c.Keycards.FirstOrDefaultAsync(x => x.Id == Id);
            card.SerialNumber = newRfid.Text;
            var row = await c.KeycardRequests.FirstOrDefaultAsync(k => k.KeycardId == Id);
            c.KeycardRequests.Remove(row);
            await c.SaveChangesAsync();



            this.Close();

        }
    }
}
