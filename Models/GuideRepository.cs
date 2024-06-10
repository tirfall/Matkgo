using System;
using SQLite;

namespace Matkgo.Models
{
    public class GuideRepository
    {
        SQLiteConnection database;
        public GuideRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<HikingGuide>();
        }
        public IEnumerable<HikingGuide> GetItems() { return database.Table<HikingGuide>().ToList(); }
        public HikingGuide GetItem(int id) { return database.Get<HikingGuide>(id); }
        public int DeleteItem(int id) { return database.Delete<HikingGuide>(id);  }
        public int SaveItem(HikingGuide item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            return database.Insert(item);
        }
    }
}
