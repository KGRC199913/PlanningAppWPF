using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace PlanningApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static NotifyIcon _notifyIcon;
        private bool _isExit;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            _notifyIcon.Visible = true;

            CreateContextMenu();
            ShowMainWindow();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open..").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Hide to system tray icon?", "Notice", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.Yes:
                        e.Cancel = true;
                        MainWindow.Hide();
                        break;
                    case MessageBoxResult.No:
                        _notifyIcon.Dispose();
                        _notifyIcon = null;
                        break;
                }
                
            }
        }

        public static void ShowNotification(int timeout, string title, string message, string typeIcon)
        {
            switch (typeIcon)
            {
                case "None":
                    _notifyIcon?.ShowBalloonTip(timeout, title, message, ToolTipIcon.None);
                    break;
                case "Info":
                    _notifyIcon?.ShowBalloonTip(timeout, title, message, ToolTipIcon.Info);
                    break;
                case "Error":
                    _notifyIcon?.ShowBalloonTip(timeout, title, message, ToolTipIcon.Error);
                    break;
                case "Warning":
                    _notifyIcon?.ShowBalloonTip(timeout, title, message, ToolTipIcon.Warning);
                    break;
            }
        }
    }
}
