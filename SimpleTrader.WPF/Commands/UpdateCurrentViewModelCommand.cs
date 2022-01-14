using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands {
    public class UpdateCurrentViewModelCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelAbstractFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleTraderViewModelAbstractFactory viewModelFactory) {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            if (parameter is ViewType) {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
