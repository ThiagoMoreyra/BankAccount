using BankAccount.Data.Context;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Owners;
using BankAccount.Domain.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly BankAccountContext _context;
        
        public OwnerRepository(BankAccountContext context)
        {
            _context = context;            
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<bool> Add(Owner owner)
        {
            try
            {
                _context.Owners.Add(owner);
                return  _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }        

        public async Task<IEnumerable<Owner>> GetAll()
        {
            return await _context.Owners.AsNoTracking().ToListAsync();
        }

        public async Task<Owner> GetById(Guid id)
        {
            return await _context.Owners.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(Owner owner)
        {
            _context.Update(owner);
            return _context.SaveChanges() > 0;
        }        
    }
}
