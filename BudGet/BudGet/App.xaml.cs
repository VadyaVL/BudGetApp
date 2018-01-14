using BudGet.Logic;
using BudGet.Logic.Services;
using BudGet.Pages;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms;

namespace BudGet
{
	public partial class App : Application
    {
        #region Properties

        private IAccountService AccountService { get; set; }

        #endregion

        #region Constructors

        public App ()
		{
			InitializeComponent();
            this.Initialize();

            this.AccountService = Mvx.Resolve<IAccountService>();

            if (this.AccountService.IsAuthenticated)
            {
                this.MainPage = new MainPage();
            }
            else
            {
                // Use NavigationPage while LoginPage
                this.MainPage = new LoginPage();
            }
        }

        #endregion

        #region Lifecycle methods

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        #endregion

        #region Methods

        public void Initialize()
        {
            // Init MvvmCross
            MvxSimpleIoCContainer.Initialize();
            MvvmConfiguration.Initialize();
        }

        #endregion
    }
}
