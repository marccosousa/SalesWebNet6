using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Data;
using SalesWebNet6.Models;

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
    }
}
