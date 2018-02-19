using BudGet.Logic.Services;
using BudGet.Utils;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class SignInViewModel : BasicViewModel
    {
        #region Fields

        private string _password;

        #endregion

        #region Props

        public string Password
        {
            get => this._password;
            set
            {
                this._password = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SignInCommand { get; private set; }

        #endregion

        #region Constructors
        
        public SignInViewModel(IAccountService accountService)
        {
            this.AccountService = accountService;

            this.SignInCommand = new Command(this.OnSignIn);

            this.Password = string.Empty;
        }

        #endregion

        #region Methods

        private void OnSignIn()
        {
            this.AccountService.IsAuthenticated = true;

            if (this.Password.Equals(this.AccountService.Password))
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
                Displayer.Instance.ShowError(Resource.TextInvalidPassword);
            }
        }

        #endregion
    }
}