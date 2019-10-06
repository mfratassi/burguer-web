using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesWeb.Repositories;
using LanchesWeb.Models;

namespace LanchesWeb.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository; 
        private readonly ISnackCategoryRepository _snackCategoryRepository; 

        public SnackController(ISnackRepository snackRepository, ISnackCategoryRepository snackCategoryRepository)
        {
            _snackRepository = snackRepository;
            _snackCategoryRepository = snackCategoryRepository;
        }

        public IActionResult List()
        {
            IEnumerable<Snack> snacks = _snackRepository.Snacks;
            return View(snacks);
        }
    }
}