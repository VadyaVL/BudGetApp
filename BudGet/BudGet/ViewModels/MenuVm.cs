using System;
using Xamarin.Forms;

namespace BudGet.ViewModels
{
    /*
     * Menu item for left side menu.
     */
    public class MenuVm
    {
        public string Title { get; set; }

        public ImageSource Icon { get; set; }

        public Type TargetType { get; set; }
    }
}
