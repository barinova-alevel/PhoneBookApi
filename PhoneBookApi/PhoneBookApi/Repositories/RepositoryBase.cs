using PhoneBookApi.Helper;
using PhoneBookApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PhoneBookApi.Repositories
{

    public abstract class RepositoryBase<TEntity>
            where TEntity : class, IEntity
    {
        public abstract string ServerPath { get; }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var list = new List<TEntity>();

            string mappedPath = HostingEnvironment.MapPath(ServerPath);
            if (!Directory.Exists(mappedPath))
                Directory.CreateDirectory(mappedPath);

            foreach (string file in Directory.EnumerateFiles(mappedPath, "*.xml"))
            {
                TEntity contact = StorageHelper.LoadData<TEntity>(file);
                list.Add(contact);
            }

            return list;
        }

        public virtual TEntity Get(Guid id)
        {
            string mappedPath = HostingEnvironment.MapPath(ServerPath);
            string file = $"{mappedPath}/{id}.xml";

            if (!File.Exists(file))
                return null;

            return StorageHelper.LoadData<TEntity>(file);
        }

        public virtual void Create(TEntity entity)
        {
            string mappedPath = HostingEnvironment.MapPath(ServerPath);
            if (!Directory.Exists(mappedPath))
                Directory.CreateDirectory(mappedPath);

            entity.Id = Guid.NewGuid();
            StorageHelper.SaveData<TEntity>(entity, $"{mappedPath}/{entity.Id}.xml");
        }

        public virtual void Delete(Guid id)
        {
            string mappedPath = HostingEnvironment.MapPath(ServerPath);
            string file = $"{mappedPath}/{id}.xml";

            if (File.Exists(file))
                File.Delete(file);
        }

        public virtual void Edit(TEntity entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
    
    
}