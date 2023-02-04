using Smarest.Model;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> GetTables();
        Task<Table> GetTable(string Id);
        Task<UserManagerResponse> Create(Table table);
        Task<UserManagerResponse> Delete(string id);
        Task<UserManagerResponse> Edit(string id, Table table);
    }
}
