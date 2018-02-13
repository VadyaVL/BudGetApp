using BudGet.Model.Models;

namespace BudGet.Dal
{
    public interface IUow
    {
        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Note> Notes { get; }
    }
}