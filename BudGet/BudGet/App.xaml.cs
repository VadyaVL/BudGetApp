using BudGet.ViewModels;
using FreshMvvm;
using Xamarin.Forms;

namespace BudGet
{
	public partial class App : Application
    {
        public App ()
		{
			InitializeComponent();

            AppSetup.Instance.Initializate();

            var page = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
        }
    }
}
