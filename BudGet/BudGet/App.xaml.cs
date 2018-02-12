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
            // MainPage would be set inside
        }
        
        public void OpenUser()
        {
            //var masterDetailsMultiple = new MasterDetailPage(); //generic master detail page

            ////we setup the first navigation container with ContactList
            //var menuListPage = FreshPageModelResolver.ResolvePageModel<MasterViewModel>();
            //menuListPage.Title = Resource.TextMenu;
            ////we setup the first navigation container with name MasterPageArea
            ////var masterPageArea = new FreshNavigationContainer(menuListPage, "MasterPageArea");
            ////masterPageArea.Title = Resource.TextMenu;
            ////masterDetailsMultiple.Master = masterPageArea; //set the first navigation container to the Master
            //masterDetailsMultiple.Master = menuListPage; //set the first navigation container to the Master


            ////we setup the second navigation container with the QuoteList 
            //var initPage = FreshPageModelResolver.ResolvePageModel<FindWordViewModel>(); // see MasterViewModel
            //                                                                             //we setup the second navigation container with name DetailPageArea
            //var detailPageArea = new FreshNavigationContainer(initPage, "DetailPageArea");
            //masterDetailsMultiple.Detail = detailPageArea; //set the second navigation container to the Detail

            //App.Current.MainPage = masterDetailsMultiple;
        }
    }
}
