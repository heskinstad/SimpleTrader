using SimpleTrader.WPF.State.Navigators;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories {
    public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModel;
        private readonly BuyViewModel _buyViewModel;

        public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
            ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModel,
            BuyViewModel buyViewModel) {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModel = portfolioViewModel;
            _buyViewModel = buyViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType) {
            switch (viewType) {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModel.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModel; // This is reusing the same instanse of the viewmodel, aka not creating a new one every time
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
