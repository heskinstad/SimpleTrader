using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators {
    public class Navigator : ObservableObject, INavigator {

        // The current ViewModel and corresponding displayed View displayed inside the ContentControl
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel {
            get {
                return _currentViewModel;
            }
            set {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
