using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Business.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.Business.Concrete
{
    public class IotCarService : CoreService<IotCar, IIotCarDal>, IIotCarService
    {
        public IotCarService(IIotCarDal iotCarDal) : base(iotCarDal)
        {
        }
    }
}