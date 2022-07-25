using IotShipmentProject.Core.Business.Abstract;
using IotShipmentProject.Core.DataAccess.Abstract;
using IotShipmentProject.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IotShipmentProject.Core.Business.Concrete
{
    public class CoreService<TEntity, TDal> : ICoreService<TEntity, TDal>
        where TEntity : CoreEntity, new()
        where TDal : IEntityRepository<TEntity>
    {
        private readonly TDal _dal;

        public CoreService(TDal dal) => _dal = dal;

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) => filter == null ? _dal.GetList() : _dal.GetList(filter);

        public TEntity Get(Expression<Func<TEntity, bool>> filter) => _dal.Get(filter);

        public TEntity GetById(int id) => _dal.Get(entity => entity.Id == id);

        public int GetCount(Expression<Func<TEntity, bool>> filter = null) => filter == null ? _dal.GetCount() : _dal.GetCount(filter);

        public TEntity Add(TEntity entity) => _dal.Add(entity);
        
        public TEntity Update(TEntity entity) => _dal.Update(entity);

        public void Delete(TEntity entity) => _dal.Delete(entity);
    }
}