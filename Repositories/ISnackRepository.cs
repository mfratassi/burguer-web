using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }

        IEnumerable<Snack> Starred { get; }
        Snack GetSnackById(int id);

    }
}
