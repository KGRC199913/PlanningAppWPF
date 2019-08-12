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
        public MainWindow()
        {
            InitializeComponent();
            //_presentation = new Presentation(new PlanningBus(new BinaryDao()));
            //IDao dao = new BinaryDao();
            //Hasher hasher = new Hasher();
            //User testUser = new User()
            //{
            //    Username = "nekoshota",
            //    HashedPassword = hasher.ComputeSha256Hash("123456")
            //};
            //dao.AddNewUser(testUser);
            //var plans = dao.LoadPlans(testUser);
            //Plan testPlan = new Plan()
            //{
            //    Detail = "Meow meow",
            //    StartDateTime = new DateTime(2019, 3, 10),
            //    EndDateTime = new DateTime(2019, 10, 12),
            //    PriorityLevel = PlanPriorityLevel.Normal
            //};
            //plans.Add(testPlan);
            //dao.SavePlans(testUser, plans);
        }

    }
}
