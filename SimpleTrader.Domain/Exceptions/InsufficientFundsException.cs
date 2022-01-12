using System;

namespace SimpleTrader.Domain.Exceptions {
    public class InsufficientFundsException : Exception {
        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }

        public InsufficientFundsException(double accountBalalance, double requiredBalance) {
            AccountBalance = AccountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundsException(double accountBalalance, double requiredBalance, string message) : base(message) {
            AccountBalance = AccountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundsException(double accountBalalance, double requiredBalance, string message, Exception innerException) : base(message, innerException) {
            AccountBalance = AccountBalance;
            RequiredBalance = requiredBalance;
        }
    }
}
