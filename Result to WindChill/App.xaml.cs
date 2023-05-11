using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Result_to_WindChill;
using ResultBridge.Core.Core.TestImport;
using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Windchill;

namespace Result_to_WindChill
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => { ConfigureServices(services); }).Build();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<IImportPage, ImportPage>();
            services.AddScoped<ISetResultToWindChillFromGUI, SetResultToWindChillFromGui>();
            services.AddScoped<ITestResultImporter, TestResultImporter>();
            services.AddScoped<ITestResultProvider, TestResultProvider>();
            services.AddScoped<ITestResultReader, TestResultReader>();
            services.AddScoped<IWindchillConnector, WindchillConnector>();
            services.AddScoped<IWindchillConfiguration, WindchillConfiguration>();
            services.AddScoped<IUserCredentials, UserCredentials>();
            services.AddScoped<IWindchillCommandBuilder, WindchillCommandBuilder>();
            services.AddScoped<ILogInToWindChill, LogInToWindChill>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }

        //public static IHost? AppHost { get; set; }

        //public App()
        //{
        //    AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
        //    {
        //        services.AddSingleton<MainWindow>();

        //        services.AddScoped<IImportPage, ImportPage>();
        //        services.AddScoped<ISetResultToWindChillFromGUI, SetResultToWindChillFromGui>();
        //        services.AddScoped<ITestResultImporter, TestResultImporter>();
        //        services.AddScoped<ITestResultProvider, TestResultProvider>();
        //        services.AddScoped<ITestResultReader, TestResultReader>();
        //        services.AddScoped<IWindchillConnector, WindchillConnector>();
        //        services.AddScoped<IWindchillConfiguration, WindchillConfiguration>();
        //        services.AddScoped<IUserCredentials, UserCredentials>();
        //        services.AddScoped<IWindchillCommandBuilder, WindchillCommandBuilder>();
        //        services.AddScoped<ILogInToWindChill, LogInToWindChill>();

        //    }).Build();
        //}

        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    await AppHost!.StartAsync();
        //    var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        //    mainWindow.Show();


        //}

        //protected override async void OnExit(ExitEventArgs e)
        //{
        //    await AppHost!.StopAsync();
        //    base.OnExit(e);

        //}


        //private ServiceProvider serviceProvider;

        //public App()
        //{
        //    ServiceCollection services = new ServiceCollection();
        //    ConfigureServices(services);
        //    services.BuildServiceProvider();
        //}

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddScoped<IImportPage, ImportPage>();
        //    services.AddScoped<ISetResultToWindChillFromGUI, SetResultToWindChillFromGui>();
        //    services.AddScoped<ITestResultImporter, TestResultImporter>();
        //    services.AddScoped<ITestResultProvider, TestResultProvider>();
        //    services.AddScoped<ITestResultReader, TestResultReader>();
        //    services.AddScoped<IWindchillConnector, WindchillConnector>();
        //    services.AddScoped<IWindchillConfiguration, WindchillConfiguration>();
        //    services.AddScoped<IUserCredentials, UserCredentials>();
        //    services.AddScoped<IWindchillCommandBuilder, WindchillCommandBuilder>();
        //    services.AddScoped<ILogInToWindChill, LogInToWindChill>();
        //    services.AddSingleton<MainWindow>();
        //}
        //protected void OnStartup(object sender, StartupEventArgs e)
        //{
        //    //base.OnStartup(e);

        //    var mainWindow = serviceProvider.GetService<MainWindow>();
        //    mainWindow.Show();
        //    //    base.OnStartup(e);

        //    //    // Create a new instance of IServiceCollection
        //    //    var services = new ServiceCollection();

        //    //    // Register your dependencies
        //    //    services.AddScoped<IImportPage, ImportPage>();
        //    //    services.AddScoped<ISetResultToWindChillFromGUI, SetResultToWindChillFromGui>();
        //    //    services.AddScoped<ITestResultImporter, TestResultImporter>();
        //    //    services.AddScoped<ITestResultProvider, TestResultProvider>();
        //    //    services.AddScoped<ITestResultReader, TestResultReader>();
        //    //    services.AddScoped<IWindchillConnector, WindchillConnector>();
        //    //    services.AddScoped<IWindchillConfiguration, WindchillConfiguration>();
        //    //    services.AddScoped<IUserCredentials, UserCredentials>();
        //    //    services.AddScoped<IWindchillCommandBuilder, WindchillCommandBuilder>();
        //    //    services.AddScoped<ILogInToWindChill, LogInToWindChill>();

        //    //    // Build the service provider
        //    //    var serviceProvider = services.BuildServiceProvider();

        //    //// Create a new instance of your main window and pass in the service provider
        //    //var mainWindow = new MainWindow(IImportPage , ILogInToWindChill);

        //    //// Show the main window
        //    //mainWindow.Show();
        //}
    }
}
