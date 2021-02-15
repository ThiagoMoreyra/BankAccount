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
            _context.Owners.Add(owner);
            return await _context.SaveChangesAsync() > 0;
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
            return await _context.SaveChangesAsync() > 0;
        }        
    }
}
