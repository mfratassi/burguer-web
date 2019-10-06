using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanchesWeb.Models
{
    public class SnackCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string Name { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string Description { get; set; }
        public List<Snack> Snacks{ get; set; }

    }
}
