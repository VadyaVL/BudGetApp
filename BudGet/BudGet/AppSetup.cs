using BudGet.Logic;
using FreshMvvm;
using FreshTinyIoC;

namespace BudGet
{
    public class AppSetup
    {
        private static AppSetup _instance;

        public static AppSetup Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AppSetup();
                }

                return _instance;
            }
        }

        private bool _isIoCInit, _isPageModelMapperInit;

        private AppSetup()
        {

        }

        public void Initializate()
        {
            if (!this._isIoCInit)
            {
                this.RegisterDependencies(FreshTinyIoCContainer.Current);
                IoCConfiguration.RegisterDependencies(FreshTinyIoCContainer.Current);

                this._isIoCInit = true;
            }

            if (!this._isPageModelMapperInit)
            {
                FreshPageModelResolver.PageModelMapper = new NavigationMapper();

                this._isPageModelMapperInit = true;
            }
        }

        private void RegisterDependencies(FreshTinyIoCContainer container)
        {
            
        }
    }
}
