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

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for DifficultySelection.xaml
    /// </summary>
    public partial class DifficultySelection : Window
    {
        public DifficultySelection()
        {
            InitializeComponent();
        }

        private void EasyGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow childWindow = new GameWindow();
            childWindow.Height = this.Height;
            childWindow.Width = this.Width;
            childWindow.enemySpaceShipSpeed = 8;
            this.Close();
            childWindow.Show();
        }

        private void MediumGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow childWindow = new GameWindow();
            childWindow.Height = this.Height;
            childWindow.Width = this.Width;
            childWindow.enemySpaceShipSpeed = 11;
            this.Close();
            childWindow.Show();
        }

        private void HardGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow childWindow = new GameWindow();
            childWindow.Height = this.Height;
            childWindow.Width = this.Width;
            childWindow.enemySpaceShipSpeed = 14;
            this.Close();
            childWindow.Show();
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
