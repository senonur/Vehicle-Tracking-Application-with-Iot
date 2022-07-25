﻿using IotShipmentProject.Core.DataAccess.Concrete;
using IotShipmentProject.DataAccess.Abstract;
using IotShipmentProject.DataAccess.Concrete.Contexts;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.DataAccess.Concrete.DataAccessLayers
{
    public class ShipmentDal : EntityRepository<Shipment, EfContext>, IShipmentDal
    {
    }
}