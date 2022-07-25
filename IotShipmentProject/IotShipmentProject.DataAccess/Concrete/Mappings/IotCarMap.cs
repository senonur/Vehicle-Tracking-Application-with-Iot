using IotShipmentProject.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace IotShipmentProject.DataAccess.Concrete.Mappings
{
    public class IotCarMap : EntityTypeConfiguration<IotCar>
    {
        public IotCarMap()
        {
            ToTable("IotCars");

            Property(i => i.Brand).IsRequired();
            Property(i => i.Model).IsRequired();
            Property(i => i.PlateNumber).IsRequired();
            Property(i => i.VehicleType).IsRequired();
        }
    }
}