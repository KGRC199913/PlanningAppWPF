using System;
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
            var hasher = new Hasher();
            var userData = new User()
            {
                Username = IdTextBox.Text,
                HashedPassword = hasher.ComputeSha256Hash(FloatingPasswordBox.Password)
            };
            var presenter = (this.DataContext as IPresentation);
            if (presenter.Login(userData))
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
    }
}
