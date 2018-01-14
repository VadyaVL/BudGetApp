using BudGet.Logic.Services;
using MvvmCross.Platform;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        #region Properties

        private IAccountService AccountService { get; set; }

        #endregion

        #region Constructors

        public LoginPage ()
		{
			InitializeComponent ();

            this.AccountService = Mvx.Resolve<IAccountService>();
        }

        #endregion

        #region Events

        private void OnLogin(object sender, EventArgs args)
        {
            this.AccountService.IsAuthenticated = true;

            // Switch to MainPage
            App.Current.MainPage = new MainPage();
        }

        #endregion
    }
}