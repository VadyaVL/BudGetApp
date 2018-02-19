using BudGet.Core;
using BudGet.Logic.Models;

namespace BudGet.ViewModels
{
    public class DetailViewModel : BasicViewModel
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

        public DetailViewModel()
        {
            this.Collection.Add(new CategoryModel { Name = "InCome" });
            this.Collection.Add(new CategoryModel { Name = "OutCome" });
        }

        #endregion

        #region Methods

        #endregion
    }
}