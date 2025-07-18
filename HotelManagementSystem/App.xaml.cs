
using HotelManagementSystem.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace HotelManagementSystem
{
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}
