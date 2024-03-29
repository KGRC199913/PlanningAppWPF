﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanningApp
{
    /// <summary>
    /// Interaction logic for LoginScreenUserControl.xaml
    /// </summary>
    public partial class LoginScreenUserControl : UserControl
    {
        private Action _loginSuccessAction;
        public LoginScreenUserControl(Action swapAction)
        {
            InitializeComponent();
            _loginSuccessAction = swapAction;
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("ID cannot be empty");
                return;
            }

            if (FloatingPasswordBox.Password.Equals(string.Empty))
            {
                MessageBox.Show("Password cannot be empty");
                return;
            }

            var hasher = new Hasher();
            var userData = new User()
            {
                Username = IdTextBox.Text,
                HashedPassword = hasher.ComputeSha256Hash(FloatingPasswordBox.Password)
            };
            var presenter = (this.DataContext as IPresentation);
            if (presenter?.Login(userData) == true)
            {
                _loginSuccessAction?.Invoke();
            }
            else
            {
                MessageBox.Show("Wrong Username/Password");
            }

        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("ID cannot be empty");
                return;
            }

            if (FloatingPasswordBox.Password.Equals(string.Empty))
            {
                MessageBox.Show("Password cannot be empty");
                return;
            }
            var hasher = new Hasher();
            var userData = new User()
            {
                Username = IdTextBox.Text,
                HashedPassword = hasher.ComputeSha256Hash(FloatingPasswordBox.Password)
            };
            var presenter = (this.DataContext as IPresentation);
            if (presenter.Signup(userData) == true)
            {
                MessageBox.Show("Sign up successfully, please login using your newly create account.", "Notification", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("The Id is already exist", "Notification", MessageBoxButton.OK);
            }
        }
    }
}
