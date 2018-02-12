using BudGet.Logic.Services;
using FreshMvvm;

namespace BudGet.ViewModels
{
    public class BasicViewModel : FreshBasePageModel
    {
        #region Services

        protected IAccountService AccountService { get; set; }

        #endregion

    }
}
