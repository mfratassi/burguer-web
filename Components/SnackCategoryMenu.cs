using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesWeb.Repositories;
using LanchesWeb.Models;

namespace LanchesWeb.Components
{
    public class SnackCategoryMenu : ViewComponent
    {
        private readonly ISnackCategoryRepository _snackCategoryRepository;
        public SnackCategoryMenu(ISnackCategoryRepository snackCategoryRepository)
        {
            _snackCategoryRepository = snackCategoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<SnackCategory> snackCategories =
                _snackCategoryRepository.Categories
                .OrderBy(sc => sc.Name);

            return View(snackCategories); 

        }
    }
}
