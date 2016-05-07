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
using System.Windows.Threading;

namespace SpaceInvader.View
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        OptionsViewModel optionsVM;
        DispatcherTimer timer;

        public OptionsWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 3);

            optionsVM = new OptionsViewModel();
            this.DataContext = optionsVM;
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ApplyNewInput_Click(object sender, RoutedEventArgs e)
        {
            if (optionsVM.IsChanged)
            {
                optionsVM.OptModel.optionsXmlDataProvider.setOptions(optionsVM.OptModel);
                timer.Start();
                StatusLabel.Content = "Settings has been updated!";

                optionsVM.IsChanged = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            StatusLabel.Content = "";
            timer.Stop();
        }

        private void UpTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                UpTextBox.Text = optionsVM.OptModel.MoveUp;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    UpTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }

        private void DownTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                DownTextBox.Text = optionsVM.OptModel.MoveDown;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    DownTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }

        private void LeftTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                LeftTextBox.Text = optionsVM.OptModel.MoveLeft;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    LeftTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }

        private void RightTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                RightTextBox.Text = optionsVM.OptModel.MoveRight;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    RightTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }

        private void ShootTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                ShootTextBox.Text = optionsVM.OptModel.Shoot;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    ShootTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }

        private void PauseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
            {
                StatusLabel.Content = "Key has been already assigned!";
                timer.Start();
                PauseTextBox.Text = optionsVM.OptModel.Pause;
            }
            else
            {
                if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                {
                    PauseTextBox.Text = optionsVM.SpecKeys(e.Key);
                }
            }
        }
    }
}
