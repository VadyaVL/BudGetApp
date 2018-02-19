using BudGet.Logic.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region Constructors

        public MainViewModel(IAccountService accountService)
        {
            this.AccountService = accountService;
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);

            if (this.AccountService.IsAuthenticated)
            {
                var masterDetailsMultiple = new MasterDetailPage();

                var menuListPage = FreshPageModelResolver.ResolvePageModel<MasterViewModel>();
                menuListPage.Title = "Menu";
                masterDetailsMultiple.Master = menuListPage;

                var initPage = FreshPageModelResolver.ResolvePageModel<DetailViewModel>();
                var detailPageArea = new FreshNavigationContainer(initPage, "DetailPageArea");
                masterDetailsMultiple.Detail = detailPageArea;

                App.Current.MainPage = masterDetailsMultiple;
            }
            else
            {
                App.Current.MainPage = FreshPageModelResolver.ResolvePageModel<SignInViewModel>();
            }

        }

        #endregion
    }
}