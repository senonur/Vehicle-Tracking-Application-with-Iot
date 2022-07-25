using IotShipmentProject.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace IotShipmentProject.DataAccess.Concrete.Mappings
{
    public class ShipmentMap : EntityTypeConfiguration<Shipment>
    {
        public ShipmentMap()
        {
            ToTable("Shipments");

            Property(c => c.ShipmentNumber).IsRequired();
            Property(c => c.Product).IsRequired();
        }
    }
}