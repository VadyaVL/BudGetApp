using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BudGet.CustomControls
{
    public class DynamicToolbarItem : ToolbarItem, INotifyPropertyChanged
    {
        public static readonly BindableProperty IsEnableProperty = BindableProperty.Create(nameof(IsEnable), typeof(bool), typeof(DynamicToolbarItem), true, BindingMode.TwoWay,
            propertyChanged: (bind, oldVal, newVal) =>
            {
                if(bind is DynamicToolbarItem self)
                {
                    self.OnPropertyChanged(nameof(IsEnable));
                }
            });

        private FileImageSource tmpIcon;

        public FileImageSource IconTransparent { get; set; }
        
        public bool IsEnable
        {
            get => (bool)this.GetValue(IsEnableProperty);
            set => this.SetValue(IsEnableProperty, value);
        }

        public DynamicToolbarItem() : base()
        {

        }

        protected override void OnClicked()
        {
            if (!this.IsEnable)
            {
                return;
            }

            base.OnClicked();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            // Find way to change opacity, not save two image
            if (propertyName.Equals(nameof(this.IsEnable)))
            {
                if (this.IsEnable && this.tmpIcon != null)
                {
                    this.Icon = this.tmpIcon;
                }
                else
                {
                    if (this.tmpIcon == null)
                    {
                        this.tmpIcon = this.Icon;
                    }

                    this.Icon = this.IconTransparent;
                }
            }
        }
    }
}
