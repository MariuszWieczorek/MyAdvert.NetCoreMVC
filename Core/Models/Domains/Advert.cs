using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Models.Domains
{
    public class Advert
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole tytuł jest wymagane.")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "Pole opis jest wymagane.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Wyświetlane Od")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Wyświetlane Do")]
        public DateTime? StopDate { get; set; }
        [Display(Name = "Aktywne")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane.")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
