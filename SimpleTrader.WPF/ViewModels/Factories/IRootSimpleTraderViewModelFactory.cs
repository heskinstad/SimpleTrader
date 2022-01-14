using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories {
    public interface IRootSimpleTraderViewModelFactory {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}