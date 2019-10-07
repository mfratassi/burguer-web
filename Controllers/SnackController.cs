using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesWeb.Repositories;
using LanchesWeb.Models;
using LanchesWeb.ViewModels;

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
    }
}