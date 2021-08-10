using carros_xamarin_clean.Core.Domain.Interface;
using carros_xamarin_clean.Core.Entity;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carros_xamarin_clean.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : DBEntity
    {
        private string CollectionName { get { return typeof(T).Name; } }

        private readonly LiteDatabase DB;

        public Repository(IDataBaseAccessPlataform dataBaseAccessPlataform)
        {
            if (DB == null) DB = new LiteDatabase(dataBaseAccessPlataform.GetDataBasePath());
        }

        protected LiteCollection<T> GetCollection()
        {
            return (LiteCollection<T>)DB.GetCollection<T>(CollectionName);
        }

        public bool Delete(T entity)
            => GetCollection().Delete(entity._id);

        public List<T> GetAll()
            => GetCollection().FindAll().ToList();

        public T Get(int id)
            => GetCollection().FindAll().FirstOrDefault(x => x._id == id);

        public bool Exist(T entity)
            => GetCollection().Exists(x => x._id == entity._id);

        public bool AddOrUpdate(T entity)
                => GetCollection().Upsert(entity);

        public int AddOrUpdate(IEnumerable<T> entities)
                => GetCollection().Upsert(entities);
    }
}