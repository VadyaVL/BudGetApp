using BudGet.Logic.Models;
using System.Collections.Generic;

namespace BudGet.Logic.Services
{
    public interface ICategoryService
    {
        int Create(CreateCategoryModel model);

        ICollection<CategoryModel> GetAll();
    }
}
