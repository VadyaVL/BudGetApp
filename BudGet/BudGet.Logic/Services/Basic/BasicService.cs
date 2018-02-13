using BudGet.Dal;

namespace BudGet.Logic.Services
{
    public abstract class BasicService
    {
        protected IUow Unit { get; set; }

        public BasicService(IUow unit)
        {
            this.Unit = unit;
        }
    }
}
