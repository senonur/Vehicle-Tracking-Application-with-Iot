using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IotShipmentProject.Core.Business.Abstract
{
    public interface IService<TEntity>
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        TEntity Add(TEntity item);
        TEntity Update(TEntity item);
        void Delete(TEntity item);
    }
}