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

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : Window
    {
        public HomeUserControl()
        {
            InitializeComponent();
        }
        private void listView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                this.myProductGrid.Visibility = Visibility.Visible;
            }
        }
    }
}
