using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Business.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.DataAccess.Concrete.DataAccessLayers;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace IotShipmentProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IIotCarService, IotCarService>();
            container.RegisterType<IDriverService, DriverService>();
            container.RegisterType<IShipmentService, ShipmentService>();
            container.RegisterType<IDeviceService, DeviceService>();

            container.RegisterType<IIotCarDal, IotCarDal>();
            container.RegisterType<IDriverDal, DriverDal>();
            container.RegisterType<IShipmentDal, ShipmentDal>();
            container.RegisterType<IDeviceDal, DeviceDal>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}