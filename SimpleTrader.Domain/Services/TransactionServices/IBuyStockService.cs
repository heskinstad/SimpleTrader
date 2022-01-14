using SimpleTrader.Domain.Models;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionServices {
    public interface IBuyStockService {
        Task<Account> BuyStock(Account buyer, string stock, int shares);
    }
}
