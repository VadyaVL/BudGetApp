using BudGet.Logic.Services;
using BudGet.Utils;
using System.ComponentModel;
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

        public string NewPassword
        {
            get => this._newPassword;
            set
            {
                this._newPassword = value;
                this.RaisePropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => this._confirmPassword;
            set
            {
                this._confirmPassword = value;
                this.RaisePropertyChanged();
            }
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

        public bool Validate()
        {
            // We don't check CurrentPassword, because it may be empty.
            // Check it in page class.
            return !string.IsNullOrWhiteSpace(this.NewPassword) &&
                   !string.IsNullOrWhiteSpace(this.ConfirmPassword) &&
                   //this.NewPassword.Equals(this.ConfirmPassword);
                    this.NewPassword.Length == this.ConfirmPassword.Length;
        }

        public void Clear()
        {
            this.CurrentPassword = string.Empty;
            this.NewPassword = string.Empty;
            this.ConfirmPassword = string.Empty;
        }

        private void OnSave()
        {
            if (this.CurrentPassword.Equals(this.AccountService.Password) &&
                this.NewPassword.Equals(this.ConfirmPassword))
            {
                this.AccountService.Password = this.NewPassword;
                this.Clear();
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