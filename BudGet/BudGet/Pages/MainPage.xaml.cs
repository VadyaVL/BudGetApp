using BudGet.Logic.Services;
using BudGet.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace BudGet.Pages
{
	public partial class MainPage : MasterDetailPage, INotifyPropertyChanged
    {
        #region Properties
        
        private IAccountService AccountService { get; set; }
        
        private ObservableCollection<MenuVm> collectionMenu = new ObservableCollection<MenuVm>();

        public ObservableCollection<MenuVm> CollectionMenu { get => this.collectionMenu; }

        private MenuVm selected;

        public MenuVm Selected
        {
            get => this.selected;
            set
            {
                this.selected = value;
                this.OnPropertyChanged(nameof(this.Selected));
            }
        }

        #endregion

        public MainPage()
		{
			InitializeComponent();

            this.AccountService = Mvx.Resolve<IAccountService>();

            this.CreateHamburgerMenu();
        }

        #region Methods

        private void CreateHamburgerMenu()
        {
            var pageWelcome = new MenuVm() { Title = "Welcome", Icon = ImageSource.FromResource("BudGet.Images.Menu.Welcome.png"), TargetType = typeof(WelcomePage) };
            var pageSetting = new MenuVm() { Title = "Setting", Icon = ImageSource.FromResource("BudGet.Images.Menu.Setting.png"), TargetType = typeof(SettingPage) };
            var pageDeveloper = new MenuVm() { Title = "Developer", Icon = ImageSource.FromResource("BudGet.Images.Menu.Developer.png"), TargetType = typeof(DeveloperPage) };
            var optionExit = new MenuVm() { Title = "Exit", Icon = ImageSource.FromResource("BudGet.Images.Menu.Logout.png"), TargetType = null };

            this.CollectionMenu.Add(pageWelcome);
            this.CollectionMenu.Add(pageSetting);
            this.CollectionMenu.Add(pageDeveloper);
            this.CollectionMenu.Add(optionExit);

            this.Selected = pageWelcome;

            this.Detail = new NavigationPage((Page)Activator.CreateInstance(this.Selected.TargetType));
        }

        #endregion

        #region Events

        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if(sender is ListView listView && e.SelectedItem is MenuVm menu)
            {
                if(menu.TargetType == null)
                {
                    // Show exit dialog
                    var isExit = await DisplayAlert(Resource.TitleExit, Resource.TextExitQuestion, Resource.TextYes, Resource.TextNo);

                    if (isExit)
                    {
                        this.AccountService.IsAuthenticated = false;
                        App.Current.MainPage = new LoginPage();
                    }
                }
                else
                {
                    this.Detail = new NavigationPage((Page)Activator.CreateInstance(menu.TargetType));
                    this.IsPresented = false;
                }

                listView.SelectedItem = null;
            }
        }

        #endregion
    }
}
