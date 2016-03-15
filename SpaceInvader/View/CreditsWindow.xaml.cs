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

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        public DateTime Now { get { return DateTime.Now; } }

        public CreditsWindow()
        {
            InitializeComponent();

            this.DataContext = Now;
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
