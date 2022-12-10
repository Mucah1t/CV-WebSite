using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVC_CV.Models.Entity;

namespace MVC_CV.Repositories
{
    public class GenericRepositories<T> where T : class, new()
    {
        DbCVEntities db = new DbCVEntities();

        ///To list item by using V variable from Databse
        public  List<T> List()
        {
            return db.Set<T>().ToList();
        }

        ///To be able to Insert 
        public void TAdd(T p) ///this is standing for "Parameter"
        {
            db.Set<T>().Add(p);
            db.SaveChanges(); ///reason we have void in the method, we do not use return!!!
        }

        ///Delete operation 
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        ///Getting data with respect to their ID
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        ///Update operation
        public void TUpdate(T p)
        {       
            db.SaveChanges();
        }
        ///To be able to delete according the desired ID 
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
}