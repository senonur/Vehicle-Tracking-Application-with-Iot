using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Business.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.Business.Concrete
{
    public class ShipmentService : CoreService<Shipment, IShipmentDal>, IShipmentService
    {
        public ShipmentService(IShipmentDal shipmentDal) : base(shipmentDal)
        {
        }
    }
}