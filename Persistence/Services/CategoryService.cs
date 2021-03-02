using MyAdvert.Core;
using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Persistence.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.Category.AddCategory(category);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int id, string userId)
        {
            _unitOfWork.Category.DeleteCategory(id);
            _unitOfWork.Complete();
        }

        public IEnumerable<Category> GetCategories(string userId)
        {
            return _unitOfWork.Category.GetCategories();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.Category.UpdateCategory(category);
            _unitOfWork.Complete();
        }

        public Category GetCategory(int id, string userId)
        {
            return _unitOfWork.Category.GetCategory(id);
        }
    }
}
