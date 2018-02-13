using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BudGet.Dal;
using BudGet.Logic.Models;
using BudGet.Model.Models;

namespace BudGet.Logic.Services
{
    public class CategoryService : BasicService, ICategoryService
    {
        public CategoryService(IUow unit) : base(unit)
        {

        }

        public int Create(CreateCategoryModel model)
        {
            var newCategory = Mapper.Map<Category>(model);

            return this.Unit.Categories.SaveItem(newCategory);
        }

        public ICollection<CategoryModel> GetAll()
        {
            return this.Unit.Categories.GetItems().Select(i => Mapper.Map<CategoryModel>(i)).ToList();
        }
    }
}