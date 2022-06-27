using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorkerBee.Navigation;
using WorkerBee.Utilities;
using WorkerBee.ViewModels;
using WorkerBee.Views;

namespace WorkerBee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            BookStore bookStore = new();

            // TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING
            NavigationStore navigationStore = new();

            //navigationStore.CurrentContentViewModel = new
            //    DashboardViewModel(bookStore, navigationStore);

            navigationStore.CurrentContentViewModel = new
                DashboardNoActiveBookViewModel(bookStore, navigationStore);

            MainWindow = new MainView()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
