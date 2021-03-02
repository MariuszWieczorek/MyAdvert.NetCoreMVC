﻿using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        Category GetCategory(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

    }
}
