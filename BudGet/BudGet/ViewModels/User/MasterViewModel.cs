using BudGet.Logic.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class MasterViewModel : BasicViewModel
    {
        #region Fields

        private ObservableCollection<MenuViewModel> _collectionMenu = new ObservableCollection<MenuViewModel>();

        private MenuViewModel _selected;

        #endregion

        #region Props

        public ObservableCollection<MenuViewModel> CollectionMenu => this._collectionMenu;

        public MenuViewModel Selected
        {
            get => this._selected;
            set
            {
                if (value == null)
                {
                    return;
                }

                if (this._selected != null)
                {
                    this._selected.IsSelected = false;
                }

                this._selected = value;

                if (this._selected != null)
                {
                    this._selected.IsSelected = true;
                }

                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ItemTapCommand { get; private set; }

        #endregion

        #region Constructors

        public MasterViewModel(IAccountService accountService)
        {
            this.AccountService = accountService;

            this.ItemTapCommand = new Command(this.OnItemTap);

            this.CreateHamburgerMenu();
        }

        #endregion

        #region Methods

        private void CreateHamburgerMenu()
        {
            var pageCategory = new MenuViewModel() { Title = "Categories", Icon = ImageSource.FromResource("BudGet.Images.Menu.Categories.png"), TargetType = typeof(CategoryListViewModel) };
            var pageSetting = new MenuViewModel() { Title = "Setting", Icon = ImageSource.FromResource("BudGet.Images.Menu.Setting.png"), TargetType = typeof(SettingViewModel) };
            var pageDeveloper = new MenuViewModel() { Title = "Developer", Icon = ImageSource.FromResource("BudGet.Images.Menu.Developer.png"), TargetType = typeof(DeveloperViewModel) };
            var optionExit = new MenuViewModel() { Title = "Exit", Icon = ImageSource.FromResource("BudGet.Images.Menu.Logout.png"), TargetType = typeof(SignInViewModel) };

            this.CollectionMenu.Add(pageCategory);
            this.CollectionMenu.Add(pageSetting);
            this.CollectionMenu.Add(pageDeveloper);
            this.CollectionMenu.Add(optionExit);

            this.Selected = pageSetting;
        }

        private void OnItemTap()
        {
            // Show dialog to exit

            if (this.Selected.TargetType == typeof(SignInViewModel))
            {
                App.Current.MainPage = FreshPageModelResolver.ResolvePageModel<SignInViewModel>();

                return;
            }
            else if (App.Current.MainPage is MasterDetailPage masterDetail)
            {
                var initPage = FreshPageModelResolver.ResolvePageModel(this.Selected.TargetType, null);
                var detailPageArea = new FreshNavigationContainer(initPage, "DetailPageArea");
                masterDetail.Detail = detailPageArea;
                masterDetail.IsPresented = false;
            }
        }

        #endregion
    }
}
