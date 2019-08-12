using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public MainWindow()
        {
            InitializeComponent();
            //_presentation = new Presentation(new PlanningBus(new BinaryDao()));
            //IDao dao = new BinaryDao();

            //User testUser = new User()
            //{
            //    Username = "nekoshota",
            //    HashedPassword = hasher.ComputeSha256Hash("123456")
            //};
            //var testUser = new User()
            //{
            //    Username = "Supercat",
            //    HashedPassword = hasher.ComputeSha256Hash("abcdef")
            //};
        }

    }
}
