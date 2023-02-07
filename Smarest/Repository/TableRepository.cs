using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _context;
        public TableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> Create(TableViewModel table)
        {
            var newTable = new Table
            {
                Id = table.Id,
                Name = table.Name,
            };
            var result = await _context.Tables.AddAsync(newTable);
            if(result == null)
            {
                return new UserManagerResponse
                {
                    Message = "Added Table Fail ...",
                    IsSuccess = false,
                };
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Some Thing Wrong, Please Try Again ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Added Table"
            };
        }

        public async Task<UserManagerResponse> Delete(string id)
        {
            var table = await _context.Tables.SingleOrDefaultAsync(t => t.Id == id);
            var result =  _context.Tables.Remove(table);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Some Thing Wrong, Please Try Again ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Removed Table"
            };
        }

        public async Task<UserManagerResponse> Edit(string id, TableViewModel table)
        {
            var putTable = new Table
            {
                Id = table.Id,
                Name = table.Name
            };
            _context.Entry(putTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                if (GetTable(id) == null)
                {
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = "Table not found ..."
                    };
                }
                else
                {
                    throw;
                }
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Table Edited ..."
            };
        }

        public async Task<Table> GetTable(string id)
        {
            var table = await _context.Tables.SingleOrDefaultAsync(t => t.Id == id);
            return table;
        }

        public async Task<List<Table>> GetTables()
        {
            var tables = await _context.Tables.ToListAsync();
            return tables;
        }
    }
}
