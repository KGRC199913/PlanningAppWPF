using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using PlanningApp.Annotations;

namespace PlanningApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPresentation _presentation = null;
        
        private readonly Hasher hasher = new Hasher();

        private double lastWidth;
        private double lastHeight;

        public MainWindow()
        {
            InitializeComponent();
            //_presentation = new Presentation(new PlanningBus(new BinaryDao()));
            //IDao dao = new BinaryDao();

            //User testUser = new User()
            //{
            //    Username = "nekoshota1",
            //    HashedPassword = hasher.ComputeSha256Hash("123456")
            //};

            //dao.CheckUserExist(testUser);
            //dao.AddNewUser(testUser);
            //var testUser = new User()
            //{
            //    Username = "Supercat",
            //    HashedPassword = hasher.ComputeSha256Hash("abcdef")
            //};

            _presentation = new Presentation(new PlanningBus(new BinaryDao()));
            SwapToLoginScreen();
        }

        public void SwapToMainScreen()
        {
            this.SizeToContent = SizeToContent.Manual;
            this.ResizeMode = ResizeMode.CanResize;
            this.Width = lastWidth;
            this.Height = lastHeight;
            this.MinHeight = 317.0;
            this.MinWidth = 607.0;
            this.WindowStyle = WindowStyle.ThreeDBorderWindow;
            var mainScreen = new MainScreenUserControl(this.SwapToLoginScreen) {DataContext = _presentation};
            MainViewContentControl.Content = mainScreen;
        }

        public void SwapToLoginScreen()
        {
            var loginScreen = new LoginScreenUserControl(this.SwapToMainScreen) {DataContext = _presentation};
            lastWidth = this.Width;
            lastHeight = this.Height;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStyle = WindowStyle.None;
            //Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            //Application.Current.Shutdown();
            MainViewContentControl.Content = loginScreen;
        }
    }
}
