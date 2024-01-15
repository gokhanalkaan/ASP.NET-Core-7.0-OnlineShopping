using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new ApplicationDbContext();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var context = new ApplicationDbContext();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {

            using var context = new ApplicationDbContext();
             context.Set<T>().Add(t);
          
             context.SaveChanges(); // Hata burada oluşabilir

          

        }

        public void Update(T t)
        {
            using var context = new ApplicationDbContext();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }

        T IGenericDal<T>.Find(Expression<Func<T, bool>> func)
        {
            using var context = new ApplicationDbContext();
            return context.Set<T>().Where(func).Single();
        }

        List<T> IGenericDal<T>.FindAll(Expression<Func<T, bool>> func)
        {
            using var context = new ApplicationDbContext();
            return context.Set<T>().Where(func).ToList();
        }
    }
}
