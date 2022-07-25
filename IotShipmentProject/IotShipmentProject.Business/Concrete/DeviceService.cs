using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Business.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.Business.Concrete
{
    public class DeviceService : CoreService<Device, IDeviceDal>, IDeviceService
    {
        public DeviceService(IDeviceDal deviceDal) : base(deviceDal)
        {
        }
    }
}