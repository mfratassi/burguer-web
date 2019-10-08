using LanchesWeb.Models;
using LanchesWeb.Repositories;
using LanchesWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult List(string snackCategory)
        {
            string _snackCategory = snackCategory;
            IEnumerable<Snack> snacks;
            string currentSnackCategory = string.Empty;

            if (string.IsNullOrEmpty(snackCategory))
            {
                snacks = _snackRepository.Snacks.OrderBy(s => s.Id);
                currentSnackCategory = "All";
            }
            else
            {
                if (string.Equals("Para Todo Dia", _snackCategory, StringComparison.OrdinalIgnoreCase))
                {
                    snacks = _snackRepository.Snacks
                        .Where(s => s.SnackCategory.Name.Equals("Para Todo Dia"))
                        .OrderBy(s => s.SnackCategory.Name);
                }
                else
                {
                    snacks = _snackRepository.Snacks
                        .Where(s => s.SnackCategory.Name.Equals("Gourmet"))
                        .OrderBy(s => s.SnackCategory.Name);
                }

                currentSnackCategory = _snackCategory;
            }
            
            SnackListViewModel snackListViewModel = new SnackListViewModel
            {
                CurrentCategory = currentSnackCategory,
                Snacks = snacks
            };

            return View(snackListViewModel);
        }

        public IActionResult Details(int snackId)
        {
            Snack snack =_snackRepository.GetSnackById(snackId);
            if (snack == null)
                return View("~/Views/Error/Error.cshtml");
            
            return View(snack);
        }

        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            string _currentCategory = string.Empty;
            IEnumerable<Snack> snacks;

            if (string.IsNullOrEmpty(_searchString))
                snacks = _snackRepository.Snacks.OrderBy(s => s.Id);
            else
                snacks = _snackRepository.Snacks.Where(s => s.Name.ToLower().Contains(_searchString.ToLower()));

            return View("~/Views/Snack/List.cshtml", new SnackListViewModel { Snacks = snacks, CurrentCategory = _currentCategory} );
        }
    }
}