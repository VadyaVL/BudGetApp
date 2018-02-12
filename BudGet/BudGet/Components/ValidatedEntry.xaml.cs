using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ValidatedEntry : StackLayout
	{
        #region Bindable Properties

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ValidatedEntry), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(nameof(Errors), typeof(ICollection<string>), typeof(ValidatedEntry), null, propertyChanged: HandleErrorsPropertyChanged);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ValidatedEntry), string.Empty, propertyChanged: HandlePlaceholderPropertyChanged);

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(ValidatedEntry), Keyboard.Default, propertyChanged: HandleKeyboardPropertyChanged);

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(ValidatedEntry), false, propertyChanged: HandleIsPasswordPropertyChanged);

        #endregion

        #region Properties

        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        public ICollection<string> Errors
        {
            get => (ICollection<string>)this.GetValue(ErrorsProperty);
            set => this.SetValue(ErrorsProperty, value);
        }

        public string Placeholder
        {
            get => (string)this.GetValue(PlaceholderProperty);
            set => this.SetValue(PlaceholderProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)this.GetValue(KeyboardProperty);
            set => this.SetValue(KeyboardProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)this.GetValue(IsPasswordProperty);
            set => this.SetValue(IsPasswordProperty, value);
        }

        #endregion

        #region Constructors

        public ValidatedEntry()
		{
			InitializeComponent ();
        }

        #endregion

        #region Methods

        private static void HandleErrorsPropertyChanged(object bind, object oldValue, object newValue)
        {
            if(bind is ValidatedEntry self)
            {
                self.OnPropertyChanged(nameof(Errors));
            }
        }

        private static void HandlePlaceholderPropertyChanged(object bind, object oldValue, object newValue)
        {
            if (bind is ValidatedEntry self)
            {
                self.OnPropertyChanged(nameof(Placeholder));
            }
        }

        private static void HandleKeyboardPropertyChanged(object bind, object oldValue, object newValue)
        {
            if (bind is ValidatedEntry self)
            {
                self.OnPropertyChanged(nameof(Keyboard));
            }
        }

        private static void HandleIsPasswordPropertyChanged(object bind, object oldValue, object newValue)
        {
            if (bind is ValidatedEntry self)
            {
                self.OnPropertyChanged(nameof(IsPassword));
            }
        }

        #endregion
    }
}