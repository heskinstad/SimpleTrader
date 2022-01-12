using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels;
using System.Windows;

namespace SimpleTrader.WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override async void OnStartup(StartupEventArgs e) {
            IDataService<Account> accountService = new AccountDataService(new EntityFramework.SimpleTraderDbContextFactory());
            IStockPriceService stockPriceService = new StockPriceService();
            IBuyStockService buyStockService = new BuyStockService(stockPriceService, accountService);

            Account buyer = await accountService.Get(2);

            await buyStockService.BuyStock(buyer, ".AAPL", 5);

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
