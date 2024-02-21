using key_managment_system.NewFolder;
using key_managment_system.ViewModels;
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
    /// Interaction logic for OfficeAccess.xaml
    /// </summary>
    public partial class OfficeAccess : UserControl
    {
        private OfficeAccessViewModel viewModel;
        public event EventHandler DataChanged;


        public List<OfficeAccessDTO> Offices { get; set; }
        public OfficeAccess()
        {
            viewModel = new OfficeAccessViewModel();
            InitializeComponent();
            Loaded += Load;
        }

        private async void Load(object sender, RoutedEventArgs args)
        {
            Offices = await viewModel.GetOfficesFromDatabase();
            DataGrid.ItemsSource = Offices;
        }


        public async void UpdateOffice(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            EditOfficeAccess edit = new EditOfficeAccess(Id);
            bool? dialogResult = edit.ShowDialog();

            await Task.Delay(500);


            Offices = await viewModel.GetOfficesFromDatabase();
            DataGrid.ItemsSource = Offices;


        }
    }
}
