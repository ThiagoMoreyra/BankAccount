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

        public void Add(Owner owner)
        {
            _context.Owners.Add(owner);
        }        

        public async Task<IEnumerable<Owner>> GetAll()
        {
            return await _context.Owners.AsNoTracking().ToListAsync();
        }

        public async Task<Owner> GetById(Guid id)
        {
            return await _context.Owners.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
