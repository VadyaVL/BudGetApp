namespace BudGet.Core
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}