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
    /// Interaction logic for HighScoresWindow.xaml
    /// </summary>
    public partial class HighScoresWindow : Window
    {
        private HighScoreViewModel highScoreVM;
        public HighScoresWindow()
        {
            InitializeComponent();

            highScoreVM = new HighScoreViewModel();
            this.DataContext = highScoreVM;
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
