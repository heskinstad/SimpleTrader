using SimpleTrader.WPF.State.Navigators;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories {
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<PortfolioViewModel> _createPortfolioViewModel;
        private readonly CreateViewModel<BuyViewModel> _createBuyViewModel;

        public SimpleTraderViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<PortfolioViewModel> createPortfolioViewModel,
            CreateViewModel<BuyViewModel> createBuyViewModel) {
            _createHomeViewModel = createHomeViewModel;
            _createPortfolioViewModel = createPortfolioViewModel;
            _createBuyViewModel = createBuyViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType) {
            switch (viewType) {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Portfolio:
                    return _createPortfolioViewModel();
                case ViewType.Buy:
                    return _createBuyViewModel(); // This is reusing the same instanse of the viewmodel, aka not creating a new one every time
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
