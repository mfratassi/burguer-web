using System;

namespace LanchesWeb.Models
{
    public class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShorDescription { get; set; }
        public string LongDescription { get; set; }
        public string MainImage { get; set; }
        public string MainThumbnail { get; set; }
        public bool IsStarred { get; set; }
        public bool IsAvailable { get; set; }
        public int SnackCategoryId { get; set; }
        public virtual SnackCategory SnackCategory { get; set; }

        public Snack() { }

    }
}
