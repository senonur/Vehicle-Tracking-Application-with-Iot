using IotShipmentProject.Core.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.DataAccess.Abstract
{
    public interface IDeviceDal : IEntityRepository<Device>
    {
    }
}