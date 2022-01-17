using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators {
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator
        where TViewModel : ViewModelBase {
        /*
         * Not used in this program, but can be used to renavigate the user 
         */

        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelDelegateRenavigator() {
        }

        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel) {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate() {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
