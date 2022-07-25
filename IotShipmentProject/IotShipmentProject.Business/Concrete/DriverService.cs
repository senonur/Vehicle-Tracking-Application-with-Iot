using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Business.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.Business.Concrete
{
    public class DriverService : CoreService<Driver, IDriverDal>, IDriverService
    {
        public DriverService(IDriverDal driverDal) : base(driverDal)
        {
        }
    }
}