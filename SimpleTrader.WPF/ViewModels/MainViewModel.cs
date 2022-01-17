using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels {
    public class MainViewModel : ViewModelBase {
        private readonly ISimpleTraderViewModelFactory _viewModelFactory;

        public INavigator Navigator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, ISimpleTraderViewModelFactory viewModelFactory) {

            Navigator = navigator;
            _viewModelFactory = viewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);

            // Displays the HomeView when the application starts
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
