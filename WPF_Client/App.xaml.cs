using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Client.Logic;
using WPF_Client.ViewModels;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        public App()
        {

            Services = ConfigureServices();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MinRequirementsViewModel>();
            services.AddSingleton<StudioWindowViewModel>();
            services.AddSingleton<GameWindowViewModel>();

            services.AddTransient<IMinRequirementsLogic, MinRequirementsLogic>();
            services.AddTransient<IMainMenuLogic, MainMenuLogic>();
            services.AddTransient<IGameMenuLogic, GameMenuLogic>();
            services.AddTransient<IStudioWindowLogic, StudioWindowLogic>();

            return services.BuildServiceProvider();
        }
    }
}
