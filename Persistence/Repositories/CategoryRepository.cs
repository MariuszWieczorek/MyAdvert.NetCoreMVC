using MyAdvert.Core.Models.Domains;
using MyAdvert.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Persistence.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories
                .Single(x => x.Id == id);
            return category;
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = _context.Categories.Single(x => x.Id == id);
            _context.Categories.Remove(categoryToDelete);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(x => x.Name).ToList();
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _context.Categories.Single(x => x.Id == category.Id);
            categoryToUpdate.Name = category.Name;
        }
    }
}
