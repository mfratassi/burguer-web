using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LanchesWeb.Models
{
    public class Order
    {
        //[BindNever]
        public int OrderId { get; set; }

        public List<OrderItem> OrderItems{ get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [Display(Name ="Sir Name")]
        [StringLength(maximumLength:50, MinimumLength = 3,ErrorMessage ="{0} must be at least {2} and maximum {1}")]
        public string SirName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Complement")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string AddressComplement { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Postal Code")]
        [StringLength(maximumLength: 11, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Province")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string Province { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "City")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} must be at least {2} and maximum {1}")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Phone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Email Address")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        public decimal Total { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
    }
}
