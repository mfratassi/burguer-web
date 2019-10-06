using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    public interface ISnackCategoryRepository
    {
        IEnumerable<SnackCategory> Categories { get; }
    }
}
