using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.ViewModels
{
    public class NavigationMenuViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int CurrentCategoryId { get; set; }
    }
}
