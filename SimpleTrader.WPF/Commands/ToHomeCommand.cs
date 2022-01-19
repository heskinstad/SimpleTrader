using SimpleTrader.WPF.State.Navigators;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands {
    public class ToHomeCommand : ICommand {
        private readonly IRenavigator _renavigator;

        public event EventHandler CanExecuteChanged;

        public ToHomeCommand(IRenavigator renavigator) {
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            _renavigator.Renavigate();
        }
    }
}
