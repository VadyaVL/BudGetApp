using BudGet.Dal;

namespace BudGet.Logic.Services
{
    public class NoteService : BasicService, INoteService
    {
        public NoteService(IUow unit) : base(unit)
        {

        }
    }
}
