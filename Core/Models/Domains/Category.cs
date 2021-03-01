using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Adverts = new Collection<Advert>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Advert> Adverts;

    }
}
