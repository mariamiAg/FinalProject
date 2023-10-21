using FinalProject.DataAccess;
using FinalProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProject.Repositories.Repository
{
    public class BaseRepository <T> : IBaseRepository <T> where T : class
    {
        private readonly WebTry2Context context;
        private DbSet<T> entities;
        private string errorMessage = string.Empty;
        public BaseRepository(WebTry2Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        //მოაქ ყოლიფერი რაც შეყვანილია webTry2Context ში

        public IEnumerable<T> GetAll() => entities.AsEnumerable();

        // by id
        public T Get(int id)
        {
            return entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("error");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Something is wrong. Try again");

            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Something is wrong. try again");

            entities.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => context.Set<T>().Where(expression).AsNoTracking();

    }
}
