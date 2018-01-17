using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BudGet.Utils
{
    // Singleton and bridge
    public class Displayer
    {
        #region Fields

        private static Displayer instance;

        private INotificator notificator;

        #endregion

        #region Props

        public static Displayer Instance
        {
            get => instance ?? (instance = new Displayer());
        }

        #endregion

        #region Constructors

        private Displayer()
        {
            this.notificator = DependencyService.Get<INotificator>();
        }

        #endregion

        #region Methods

        public void ShowError(string message)
        {
            this.notificator.ShowError(message);
        }

        public void ShowSuccessfull(string message)
        {
            this.notificator.ShowSuccessfull(message);
        }

        #endregion
    }
}
