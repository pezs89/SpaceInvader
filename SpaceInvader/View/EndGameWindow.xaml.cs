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
using SpaceInvader.ViewModel;

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        private EndGameViewModel endGameViewModel;
        public EndGameWindow()
        {
            InitializeComponent();

            endGameViewModel = new EndGameViewModel();
        }

        private void OkInput_OnClick(object sender, RoutedEventArgs e)
        {
            if (endGameViewModel.CheckScore(int.Parse(ScoreTextBox.Text)) && !string.IsNullOrEmpty(NameTextBox.Text))
            {
                endGameViewModel.SaveScore(NameTextBox.Text, int.Parse(ScoreTextBox.Text));
            }

            MainWindow parent = new MainWindow();
            parent.Show();
            this.Close();
        }
    }
}
