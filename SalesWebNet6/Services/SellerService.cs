using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Data;
using SalesWebNet6.Models;
using SalesWebNet6.Services.Exceptions;
using System.Runtime.CompilerServices;

namespace SalesWebNet6.Services
{
    public class SellerService
    {
        private readonly SalesWebNet6Context _context;

        public SellerService(SalesWebNet6Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync (int id)
        {
            return await _context.Seller.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id); 
        }

        public async Task RemoveAsync (int id) 
        {
            var seller = await _context.Seller.FindAsync(id); 
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            if(!await _context.Seller.AnyAsync(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found"); 
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
