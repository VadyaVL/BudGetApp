using BudGet.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace BudGet.Dal
{
    public class NoteRepository : IGenericRepository<Note>
    {
        public NoteRepository(string filename) : base(filename)
        {
        }

        public override IEnumerable<Note> GetItems()
        {
            return database.Table<Note>().Select(x => x).ToList();
        }

        public override Note GetItem(int id)
        {
            try
            {
                return database.Get<Note>(id);
            }
            catch
            {
                return null;
            }
        }

        public override int DeleteItem(int id)
        {
            return database.Delete<Note>(id);
        }

        public override int SaveItem(Note item)
        {
            var exist = this.GetItem(item.Id) != null;

            if (exist)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
