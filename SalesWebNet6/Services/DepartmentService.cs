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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
