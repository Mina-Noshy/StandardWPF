using Microsoft.Extensions.DependencyInjection;
using MyWpfApp.data;
using MyWpfApp.services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider serviceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            serviceProvider = serviceCollection.BuildServiceProvider();


            var mainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<dapperHelper>();
            services.AddScoped<iUserServices, userServices>();


            services.AddTransient<MainWindow>();
        }
    }
}
