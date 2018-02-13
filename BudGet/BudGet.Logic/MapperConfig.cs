using AutoMapper;
using BudGet.Logic.Models;
using BudGet.Model.Models;

namespace BudGet.Logic
{
    public static class MapperConfig
    {
        public static void RegisterMappers(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateCategoryModel, Category>();
            cfg.CreateMap<Category, CategoryModel>();
        }
    }
}
