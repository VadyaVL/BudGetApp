using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BudGet.CustomControls
{
    public class DynamicToolbarItem : ToolbarItem, INotifyPropertyChanged
    {
        private FileImageSource tmpIcon;

        public FileImageSource IconTransparent { get; set; }

        private bool isEnable = true;
        public bool IsEnable
        {
            get => this.isEnable;
            set
            {
                this.isEnable = value;
                this.OnPropertyChanged(nameof(this.IsEnable));
            }
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
