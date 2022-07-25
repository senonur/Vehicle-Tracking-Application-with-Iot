using IotShipmentProject.Core.Business.Abstract;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.Business.Abstract
{
    public interface IIotCarService : ICoreService<IotCar, IIotCarDal>
    {
    }
}