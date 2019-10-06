using System.Collections.Generic;
using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    public class SnackCategoryRepository : ISnackCategoryRepository
    {

        private readonly LanchesWebContext _context;
        public SnackCategoryRepository(LanchesWebContext context)
        {
            _context = context;
        }

        public IEnumerable<SnackCategory> Categories => _context.SnackCategories;
    }
}
