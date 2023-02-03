namespace PesonService.DAL.Entity
{
    public class AccessPointEntity : BaseEntity
    {
        public string ControllerName { get; set; } = string.Empty;

        public ICollection<UserAccessPointEntity> UserAccessPoints { get; set; }
    }
}
