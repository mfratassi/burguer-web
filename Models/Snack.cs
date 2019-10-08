using System;
using System.ComponentModel.DataAnnotations;

namespace LanchesWeb.Models
{
    public class Snack
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:100, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string Name { get; set; }


        public decimal Price { get; set; }

        [StringLength(maximumLength:100, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string ShortDescription { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string LongDescription { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string MainImage { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string MainThumbnail { get; set; }
        public bool IsStarred { get; set; }
        public bool IsAvailable { get; set; }
        public int SnackCategoryId { get; set; }
        public virtual SnackCategory SnackCategory { get; set; }

        public Snack() { }

    }
}
