using BudGet.Logic;
using BudGet.Pages;
using MvvmCross.Platform.IoC;
using Xamarin.Forms;

namespace BudGet
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            this.Initialize();

            this.MainPage = new MainPage();
            // Use NavigationPage while StartPage
        }

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
