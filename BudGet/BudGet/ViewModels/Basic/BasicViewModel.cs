using BadGet.Core.Validation;
using BudGet.Logic.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudGet.ViewModels
{
    public class BasicViewModel : FreshBasePageModel, IValidatableBase
    {
        #region Services

        protected IAccountService AccountService { get; set; }

        protected ICategoryService CategoryService { get; set; }

        protected INoteService NoteService { get; set; }

        #endregion

        #region Validation

        private bool _isValid;

        public bool IsValid
        {
            get => this._isValid;
            set
            {
                this._isValid = value;
                this.RaisePropertyChanged();
            }
        }

        readonly Validator validator;

        public bool IsValidationEnabled
        {
            get => this.validator.IsValidationEnabled;
            set => this.validator.IsValidationEnabled = value;
        }

        public Validator Errors
        {
            get => this.validator;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add => validator.ErrorsChanged += value;
            remove => validator.ErrorsChanged -= value;
        }

        public BasicViewModel()
        {
            this.validator = new Validator(this);
        }

        public ReadOnlyDictionary<string, ReadOnlyCollection<string>> GetAllErrors()
        {
            return this.validator.GetAllErrors();
        }

        public bool Validate()
        {
            return this.validator.ValidateProperties();
        }

        public void SetAllErrors(IDictionary<string, ReadOnlyCollection<string>> entityErrors)
        {
            this.validator.SetAllErrors(entityErrors);
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var result = !object.Equals(storage, value);

            if (result && !string.IsNullOrWhiteSpace(propertyName))
            {
                storage = value;
                this.RaisePropertyChanged(propertyName);

                if (this.validator.IsValidationEnabled)
                {
                    this.validator.ValidateProperty(propertyName);
                }
            }

            //
            this.IsValid = this.Validate();

            return result;
        }

        #endregion
    }
}
