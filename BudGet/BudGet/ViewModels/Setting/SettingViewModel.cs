using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class SettingViewModel : BasicViewModel
    {
        #region Fields

        private ObservableCollection<MenuItemViewModel> _collection = new ObservableCollection<MenuItemViewModel>();

        private MenuItemViewModel _selected;

        #endregion

        #region Props

        public ObservableCollection<MenuItemViewModel> Collection => this._collection;

        public MenuItemViewModel Selected
        {
            get => this._selected;
            set
            {
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

        public SettingViewModel()
        {
            this.ItemTapCommand = new Command(this.OnItemTap);

            this.Collection.Add(
                new MenuItemViewModel
                {
                    Icon = ImageSource.FromResource("BudGet.Images.Lock.png"),
                    Title = Resource.TextChangePassword,
                    TargetType = typeof(ChangePasswordViewModel)
                });
        }

        #endregion

        #region Methods

        private async void OnItemTap()
        {
            if (this.Selected != null)
            {
                if (this.Selected.TargetType == typeof(ChangePasswordViewModel))
                {
                    await CoreMethods.PushPageModel<ChangePasswordViewModel>();
                }

                this.Selected = null;
            }
        }

        #endregion
    }
}
