using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels {
    public class MainViewModel : ViewModelBase {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator) {

            Navigator = navigator;

            // Displays the HomeView when the application starts
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
