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
    }
}
