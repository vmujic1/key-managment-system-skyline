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

namespace key_managment_system.Views.Employee
{
    /// <summary>
    /// Interaction logic for PermissionAlert.xaml
    /// </summary>
    public partial class PermissionAlert : Window
    {
        public PermissionAlert(int roomId, int userId)
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
