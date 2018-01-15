using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingMenuItem : StackLayout, INotifyPropertyChanged
    {
        #region Bindable Properties

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(SettingMenuItem), null, BindingMode.TwoWay,
            propertyChanged: (bind, oldValue, newValue) =>
            {
                if (bind is SettingMenuItem self && newValue is ImageSource)
                {
                    self.OnPropertyChanged(nameof(self.Image));
                }
            });

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(SettingMenuItem), string.Empty, BindingMode.TwoWay,
            propertyChanged: (bind, oldValue, newValue) =>
            {
                if (bind is SettingMenuItem self && newValue is string)
                {
                    self.OnPropertyChanged(nameof(self.Value));
                }
            });

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SettingMenuItem), string.Empty, BindingMode.TwoWay,
            propertyChanged: (bind, oldValue, newValue) =>
            {
                if (bind is SettingMenuItem self && newValue is string)
                {
                    self.OnPropertyChanged(nameof(self.Title));
                }
            });

        #endregion

        #region Properties

        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion

        #region Constructor

        public SettingMenuItem()
        {
            InitializeComponent();
        }

        #endregion
    }
}