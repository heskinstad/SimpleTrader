using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators {
    public enum ViewType {
        // What is passed in through the ICommand execute method, aka the parameter of the command
        Home,
        Portfolio,
        Buy
    }
    public interface INavigator {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
