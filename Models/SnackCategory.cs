using System;
using System.Collections.Generic;

namespace LanchesWeb.Models
{
    public class SnackCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Snack> Snacks{ get; set; }

    }
}
