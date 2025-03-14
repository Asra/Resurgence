using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.MirDatabase;

namespace Server.Services
{
    // Generic base service that works on a collection of T objects.
    public abstract class CacheService<T> where T : class, DatabaseEntity, new()
    {
        // In-memory cache for objects of type T.
        protected List<T> _cache = new List<T>();

        // Derived classes must supply a way to get the correct DbSet from the context.
        protected abstract DbSet<T> GetDbSet(GameDbContext context);

        // Loads all objects from the database into the in-memory cache.
        public virtual void Load()
        {
            using (var context = new GameDbContext())
            {
                _cache = GetDbSet(context).ToList();
            }
        }

        // Returns the cached list.
        public virtual List<T> GetAll() => _cache;

        // Creates a new item.
        public virtual void Create(T item)
        {
            using (var context = new GameDbContext())
            {
                GetDbSet(context).Add(item);
                context.SaveChanges();
            }
            _cache.Add(item);
        }

        // Updates an existing item.
        public virtual void Update(T item)
        {
            using (var context = new GameDbContext())
            {
                // Attach the item if needed and mark it as modified.
                GetDbSet(context).Update(item);
                context.SaveChanges();
            }

            // Update the cache if needed.
            var index = _cache.FindIndex(x => x.Equals(item));
            if (index >= 0)
            {
                _cache[index] = item;
            }
        }

        // Deletes an item.
        public virtual void Delete(T item)
        {
            using (var context = new GameDbContext())
            {
                GetDbSet(context).Remove(item);
                context.SaveChanges();
            }
            _cache.Remove(item);
        }

        // Saves all items from the cache back to the database.
        // (This might be useful if modifying the objects in memory and want to persist all changes at once.)
        public virtual void SaveAll()
        {
            using (var context = new GameDbContext())
            {
                foreach (var item in _cache)
                {
                    // Attempt to find the item in the database based on its key.
                    var existingItem = GetDbSet(context).Find(item.Id);

                    if (existingItem == null)
                    {
                        // If the item isn't found (or its key is 0, indicating it's new),
                        // add it to the context to insert it.
                        GetDbSet(context).Add(item);
                    }
                    else
                    {
                        // If found, update the existing record.
                        // This copies all current values from item to the database entity.
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
                context.SaveChanges();
            }
        }
    }

    public interface DatabaseEntity
    {
        int Id { get; set; }
    }
}