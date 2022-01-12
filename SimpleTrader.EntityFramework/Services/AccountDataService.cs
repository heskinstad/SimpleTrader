using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services {
    public class AccountDataService : IDataService<Account>{
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(SimpleTraderDbContextFactory contextFactory) {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }
        
        public async Task<Account> Create(Account entity) {
            return await _nonQueryDataService.Create(entity);                                                                                                                                                                                              
        }

        public async Task<bool> Delete(int id) {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext()) {
                Account entity = await context.Set<Account>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Account>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Account> Get(int id) {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext()) {
                Account entity = await context.Accounts.Include(a => a.AssetTransactions).FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll() {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext()) {
                IEnumerable<Account> entities = await context.Set<Account>().ToListAsync();
                return entities;
            }
        }

        public async Task<Account> Update(int id, Account entity) {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext()) {
                return await _nonQueryDataService.Update(id, entity);
            }
        }
    }
}
