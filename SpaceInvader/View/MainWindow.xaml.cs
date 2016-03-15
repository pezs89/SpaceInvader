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
using SpaceInvader.View;

namespace SpaceInvader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow childWindow = new OptionsWindow();

            childWindow.Height = this.Height;
            childWindow.Width = this.Height;

            childWindow.ShowDialog();
        }

        private void BtnHighScores_Click(object sender, RoutedEventArgs e)
        {
            HighScoresWindow childWindow = new HighScoresWindow();

            childWindow.Height = this.Height;
            childWindow.Width = this.Width;

            childWindow.ShowDialog();
        }

        private void BtnCredits_Click(object sender, RoutedEventArgs e)
        {
            CreditsWindow childWindow = new CreditsWindow();

            childWindow.Width = this.Width;
            childWindow.Height = this.Height;

            childWindow.ShowDialog();
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes) this.Close();
        }
    }
}
