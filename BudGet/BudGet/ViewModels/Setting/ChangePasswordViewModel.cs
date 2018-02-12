using BudGet.Logic.Services;
using BudGet.Utils;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class ChangePasswordViewModel : BasicViewModel
    {
        #region Fields

        private bool _isCurrentPasswordSet;

        private string _currentPassword, _newPassword, _confirmPassword;

        #endregion

        #region Props

        public bool IsCurrentPasswordSet
        {
            get => this._isCurrentPasswordSet;
            set
            {
                this._isCurrentPasswordSet = value;
                this.RaisePropertyChanged();
            }
        }

        public string CurrentPassword
        {
            get => this._currentPassword;
            set
            {
                this._currentPassword = value;
                this.RaisePropertyChanged();
            }
        }

        [Required]
        [RegularExpression(@"\w{4,}", ErrorMessage = "Password: more than 3 letters/numbers required")]
        public string NewPassword
        {
            get => this._newPassword;
            set => this.SetProperty(ref this._newPassword, value);
        }

        [Required]
        [RegularExpression(@"\w{4,}", ErrorMessage = "Password: more than 3 letters/numbers required")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword
        {
            get => this._confirmPassword;
            set => this.SetProperty(ref this._confirmPassword, value);
        }

        #endregion

        #region Command

        public ICommand SaveCommand { get; private set; }

        #endregion

        #region Constructors

        public ChangePasswordViewModel(IAccountService accountService)
        {
            this.AccountService = accountService;

            this.SaveCommand = new Command(this.OnSave);

            this.IsCurrentPasswordSet = !string.IsNullOrEmpty(this.AccountService.Password);
        }

        #endregion

        #region Methods
        
        private void OnSave()
        {
            if (this.Validate() && this.AccountService.Password.Equals(this.CurrentPassword))
            {
                this.AccountService.Password = this.NewPassword;

                this.CurrentPassword = string.Empty;
                this.NewPassword = string.Empty;
                this.ConfirmPassword = string.Empty;

                this.IsCurrentPasswordSet = true;

                Displayer.Instance.ShowSuccessfull(Resource.TextChangePasswordSuccessfull);
            }
            else
            {
                Displayer.Instance.ShowError(Resource.TextChangePasswordError);
            }
        }

        // Set it to every entry
        //private void EntryPropertyChanged(object sender, PropertyChangedEventArgs args)
        //{
        //    if (this.toolBarItemSave != null && args.PropertyName.Equals("Text"))
        //    {
        //        this.toolBarItemSave.IsEnable = this.editPassword.Validate() &&
        //            (string.IsNullOrWhiteSpace(this.AccountService.Password) ||
        //            !string.IsNullOrWhiteSpace(this.editPassword.CurrentPassword));
        //    }
        //}

        #endregion
    }
}