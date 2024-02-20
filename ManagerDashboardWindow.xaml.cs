using key_managment_system.ViewModel;
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

namespace key_managment_system
{
    /// <summary>
    /// Interaction logic for ManagerDashboardWindow.xaml
    /// </summary>
    public partial class ManagerDashboardWindow : Window
    {
        public ManagerDashboardWindow()
        {
            InitializeComponent();

            this.DataContext = new ManagerVM();
        }

        
    }
}
