using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesWeb.Models;

namespace LanchesWeb.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> Starred { get; set; }
    }
}
