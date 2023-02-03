namespace PesonService.DAL.Entity
{
    public class UserAccessPointEntity : BaseEntity
    {
        public Guid UserId { get; set; } 
        public UserEntity User { get; set; }

        public Guid AccessPointId { get; set; }
        public AccessPointEntity AccessPoint { get; set; }
    }
}
