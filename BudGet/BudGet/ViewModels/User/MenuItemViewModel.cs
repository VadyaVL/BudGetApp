using System;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    public class MenuItemViewModel : BasicViewModel
    {
        public string Title { get; set; }

        public ImageSource Icon { get; set; }

        public Type TargetType { get; set; }

        public bool IsSelected
        {
            get;
            set;
        }
    }
}
