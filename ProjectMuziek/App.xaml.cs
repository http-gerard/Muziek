using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjectMuziek.ViewModels;
using ProjectMuziek.Views;

namespace ProjectMuziek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HomeWindow1 window = new HomeWindow1
            {
                DataContext = HomePageViewmodel.Instance
            };
            window.Show();
        }
    }
    }
