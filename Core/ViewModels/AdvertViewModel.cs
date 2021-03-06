﻿using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.ViewModels
{
    public class AdvertViewModel
    {
        public string Heading { get; set; }
        public Advert Advert { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
