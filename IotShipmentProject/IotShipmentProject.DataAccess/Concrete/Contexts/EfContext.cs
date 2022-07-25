using IotShipmentProject.Core.Entity.Concrete;
using IotShipmentProject.DataAccess.Concrete.Mappings;
using IotShipmentProject.Entity.Concrete;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Principal;

namespace IotShipmentProject.DataAccess.Concrete.Contexts
{
    public class EfContext : DbContext
    {
        public EfContext() => Database.Connection.ConnectionString = SetConnectionString("(localdb)\\MSSQLLocalDB", "IotShipmentProjectDB");

        public DbSet<IotCar> IotCars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IotCarMap());
            modelBuilder.Configurations.Add(new DriverMap());
            modelBuilder.Configurations.Add(new ShipmentMap());
            modelBuilder.Configurations.Add(new DeviceMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (DbEntityEntry item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList())
            {
                CoreEntity entity = (CoreEntity)item.Entity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedComputerName = Environment.MachineName;
                        entity.CreatedUserName = WindowsIdentity.GetCurrent().Name;
                        entity.Status = Status.Active;
                    }

                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedDate = DateTime.Now;
                        entity.ModifiedComputerName = Environment.MachineName;
                        entity.ModifiedUserName = WindowsIdentity.GetCurrent().Name;
                        if (entity.Status == Status.Active)
                            entity.Status = Status.Active;
                    }
                }
            }

            return base.SaveChanges();
        }

        private string SetConnectionString(string server, string database, bool trustedConnection = true) => $"Server = {server}; Database = {database}; Trusted_Connection = {trustedConnection}";
    }
}