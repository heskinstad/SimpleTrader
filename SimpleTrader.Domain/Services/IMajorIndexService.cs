using SimpleTrader.Domain.Models;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services {
    public interface IMajorIndexService {
        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}
