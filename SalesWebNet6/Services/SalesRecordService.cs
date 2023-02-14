using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Data;
using SalesWebNet6.Models;
using System.Diagnostics.Metrics;

namespace SalesWebNet6.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebNet6Context _context;

        public SalesRecordService(SalesWebNet6Context context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if(minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value); 
            }
            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value); 
            }

            return await result
                    .Include(x => x.Seller)
                    .Include(x => x.Seller.Department)
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();
        }
    }
}
