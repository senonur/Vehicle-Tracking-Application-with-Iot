using IotShipmentProject.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IotShipmentProject.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : CoreEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        int GetCount(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}