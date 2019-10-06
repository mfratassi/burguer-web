using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LanchesWeb.Models;
using System.Linq;

namespace LanchesWeb.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly LanchesWebContext _context; 

        public SnackRepository(LanchesWebContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c=> c.SnackCategory);

        public IEnumerable<Snack> Starred => _context.Snacks.Where(s => s.IsStarred).Include(s => s.SnackCategory);

        public Snack GetSnackById(int id)
        {
            return _context.Snacks.FirstOrDefault(s => s.Id == id);
        }
    }
}
