using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    interface ISnackCategoryRepository
    {
        IEnumerable<SnackCategory> Categories { get; }
    }
}
