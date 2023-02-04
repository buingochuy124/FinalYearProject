using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository
{
    public class TableRepository : ITableRepository
    {
        public Task<UserManagerResponse> Create(Table table)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> Edit(string id, Table table)
        {
            throw new System.NotImplementedException();
        }

        public Task<Table> GetTable(string Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Table>> GetTables()
        {
            throw new System.NotImplementedException();
        }
    }
}
