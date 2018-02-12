using FreshMvvm;
using System;

namespace BudGet
{
    public class NavigationMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName.Replace("ViewModels", "Pages").Replace("ViewModel", "Page");
        }
    }
}
