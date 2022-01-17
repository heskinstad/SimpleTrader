using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels {
    public class BuyViewModel : ViewModelBase {
        private ICommand _toHomeCommand;
        public ICommand ToHomeCommand {
            get { return _toHomeCommand; }
            set { _toHomeCommand = value; }
        }
        public BuyViewModel(IRenavigator renavigator) {
            ToHomeCommand = new ToHomeCommand(renavigator);
        }
    }
}
