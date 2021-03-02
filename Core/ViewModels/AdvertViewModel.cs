using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.ViewModels
{
    public class AdvertViewModel
    {
        public IEnumerable<Advert> Adverts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public FilterAdverts FilterAdverts { get; set; }

    }
}
