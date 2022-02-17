using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationContext applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return applicationContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {

                await applicationContext.AddAsync(entity);
                await applicationContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                applicationContext.Update(entity);
                await applicationContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                applicationContext.Remove(entity);
                await applicationContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }
        }
    }
}
