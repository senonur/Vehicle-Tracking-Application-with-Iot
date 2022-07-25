using IotShipmentProject.Core.DataAccess.Abstract;
using IotShipmentProject.Core.Entity.Concrete;

namespace IotShipmentProject.Core.Business.Abstract
{
    public interface ICoreService<TEntity, TDal> : IService<TEntity>
        where TEntity : CoreEntity, new()
        where TDal : IEntityRepository<TEntity>
    {
    }
}