using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows;

namespace SimpleTrader.WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override async void OnStartup(StartupEventArgs e) {

            IServiceProvider serviceProvider = CreateServiceProvider();

            /*Account buyer = await accountService.Get(2);

            await buyStockService.BuyStock(buyer, ".AAPL", 5);*/

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider() {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
            services.AddSingleton<BuyViewModel>();
            services.AddSingleton<PortfolioViewModel>();


            // Create one HomeViewModel instanse for the entire program
            services.AddSingleton<HomeViewModel>(services => new HomeViewModel(
                MajorIndexListingViewModel.LoadMajorIndexViewModel(
                    services.GetRequiredService<IMajorIndexService>())));

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services => {
                return () => services.GetRequiredService<HomeViewModel>();
            });
            //

            // Create a new HomeViewModel instanse every time the HomeViewModel is loaded
            /*services.AddSingleton<CreateViewModel<HomeViewModel>>(services => {
                return () => new HomeViewModel(
                    MajorIndexListingViewModel.LoadMajorIndexViewModel(
                        services.GetRequiredService<IMajorIndexService>()));
            });*/
            //


            // How to set up navigation from a button inside the ContentControl that changes the ContentControl viewmodel
            services.AddSingleton <ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<CreateViewModel<BuyViewModel>>(services => {
                return () => new BuyViewModel(
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });
            //

            services.AddSingleton<CreateViewModel<PortfolioViewModel>> (services => {
                return () => services.GetRequiredService<PortfolioViewModel>();
            });

            /*services.AddSingleton<CreateViewModel<BuyViewModel>>(services => {
                return () => services.GetRequiredService<BuyViewModel>();
            });*/

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<BuyViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
