﻿using System;
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
    /// Interaction logic for ManagerDashboard.xaml
    /// </summary>
    public partial class ManagerDashboard : Window
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
