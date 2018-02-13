using BudGet.Core;
using BudGet.Droid.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace BudGet.Droid.Services
{
    public class SQLiteAndroid : ISQLite
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(documentsPath, sqliteFilename);
        }
    }
}