using System.Data.Entity.ModelConfiguration;

namespace IotShipmentProject.Core.Entity.Concrete
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Status).IsOptional();
            Property(x => x.CreatedDate).IsOptional();
            Property(x => x.CreatedUserName).IsOptional();
            Property(x => x.CreatedComputerName).IsOptional();
            Property(x => x.ModifiedDate).IsOptional();
            Property(x => x.ModifiedUserName).IsOptional();
            Property(x => x.ModifiedComputerName).IsOptional();
        }
    }
}