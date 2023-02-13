using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Data;
using SalesWebNet6.Models;

namespace SalesWebNet6.Services
{
    public class DepartmentService
    {
        private readonly SalesWebNet6Context _context;

        public DepartmentService(SalesWebNet6Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
