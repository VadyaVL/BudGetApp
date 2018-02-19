using BudGet.Core;
using BudGet.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudGet.ViewModels
{
    public class UserViewModel : BasicViewModel
    {
        #region Fields

        private RangeObservableCollection<CategoryModel> _collection = new RangeObservableCollection<CategoryModel>();

        #endregion

        #region Props

        public RangeObservableCollection<CategoryModel> Collection => this._collection;

        #endregion

        #region Commands

        #endregion

        #region Constructors

        public UserViewModel()
        {
            this.Collection.Add(new CategoryModel { Name = "InCome" });
            this.Collection.Add(new CategoryModel { Name = "OutCome" });
        }

        #endregion

        #region Methods

        #endregion
    }
}