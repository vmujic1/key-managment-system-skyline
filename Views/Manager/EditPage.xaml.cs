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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private int id;

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void txtKeycardId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}