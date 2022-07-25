using IotShipmentProject.Core.Entity.Abstract;
using System;

namespace IotShipmentProject.Core.Entity.Concrete
{
    public class CoreEntity : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedUserName { get; set; }
        public Status Status { get; set; }
    }

    public enum Status { Active = 1, Passive = 2 }
}