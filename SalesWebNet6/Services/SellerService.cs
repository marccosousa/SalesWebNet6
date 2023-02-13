using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Data;
using SalesWebNet6.Models;
using SalesWebNet6.Services.Exceptions;

namespace SalesWebNet6.Services
{
    public class SellerService
    {
        private readonly SalesWebNet6Context _context;

        public SellerService(SalesWebNet6Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById (int id)
        {
            return _context.Seller.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id); 
        }

        public void Remove (int id) 
        {
            var seller = _context.Seller.Find(id); 
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if(!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found"); 
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
