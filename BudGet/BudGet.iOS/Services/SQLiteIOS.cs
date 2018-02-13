using System;
using Xamarin.Forms;
using System.IO;
using BudGet.iOS.Services;
using BudGet.Core;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace BudGet.iOS.Services
{
    public class SQLiteIOS : ISQLite
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");

            return Path.Combine(libraryPath, sqliteFilename);
        }
    }
}