using BudGet.Core;
using BudGet.Logic.Models;
using BudGet.Logic.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class CategoryListViewModel : BasicViewModel
    {
        #region Fields

        private RangeObservableCollection<CategoryModel> _collection = new RangeObservableCollection<CategoryModel>();

        #endregion

        #region Props

        public RangeObservableCollection<CategoryModel> Collection => this._collection;

        #endregion

        #region Commands

        public ICommand CreateCommand { get; private set; }

        #endregion

        #region Constructors

        public CategoryListViewModel(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;

            this.CreateCommand = new Command(this.OnCreate);
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);

            this.Collection.AddRange(this.CategoryService.GetAll());
        }

        private void OnCreate()
        {
            // Open Create Page

            #region TEST

            var newCategory = new CreateCategoryModel
            {
                Name = "Name-" + this.Collection.Count,
                Coefficient = 0
            };

            var id = this.CategoryService.Create(newCategory);

            this.Collection.Insert(0, new CategoryModel
            {
                Id = id,
                Name = newCategory.Name,
                Coefficient = newCategory.Coefficient
            });

            #endregion
        }

        #endregion
    }
}
