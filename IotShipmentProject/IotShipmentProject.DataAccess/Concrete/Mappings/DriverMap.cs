using IotShipmentProject.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace IotShipmentProject.DataAccess.Concrete.Mappings
{
    public class DriverMap : EntityTypeConfiguration<Driver>
    {
        public DriverMap()
        {
            ToTable("Drivers");

            Property(d => d.Name).IsRequired();
            Property(d => d.SurName).IsRequired();
            Property(d => d.IdentityNumber).IsRequired();
            Property(d => d.DrivingLicenceNumber).IsRequired();
            Property(d => d.DrivingLicenceType).IsRequired();
        }
    }
}