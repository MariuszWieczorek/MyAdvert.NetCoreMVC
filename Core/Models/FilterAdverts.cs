using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Models
{
    public class FilterAdverts
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Tylko aktywne")]
        public bool IsActive { get; set; }
    }
}
