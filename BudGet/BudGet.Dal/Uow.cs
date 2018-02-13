using BudGet.Model.Models;

namespace BudGet.Dal
{
    public class Uow : IUow
    {
        #region Properties

        public const string DatabaseName = "budget.db";

        #endregion

        #region Constructors

        public Uow()
        {
        }

        #endregion

        #region Repositories

        private static IGenericRepository<Category> _categoryRepository;

        public IGenericRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(DatabaseName);
                }

                return _categoryRepository;
            }
        }

        private static IGenericRepository<Note> _noteRepository;

        public IGenericRepository<Note> Notes
        {
            get
            {
                if (_noteRepository == null)
                {
                    _noteRepository = new NoteRepository(DatabaseName);
                }

                return _noteRepository;
            }
        }

        #endregion
    }
}
