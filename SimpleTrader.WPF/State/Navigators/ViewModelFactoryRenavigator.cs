using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF.State.Navigators {
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator
        where TViewModel : ViewModelBase {
        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryRenavigator(INavigator navigator, ISimpleTraderViewModelFactory<TViewModel> viewModelFactory) {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate() {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
