namespace PersonService.Common.Security
{
    public enum AccessPoint
    {
        PersonController = 1,
        SecurityController = 2,
        UserController = 3
    }

    public static class AccessPointDictionary
    {
        private static Dictionary<AccessPoint, Guid> _accessPointDictionary = new Dictionary<AccessPoint, Guid>(new[]
        {
            new KeyValuePair<AccessPoint, Guid>(AccessPoint.PersonController, Guid.Parse("01E31986-E9E4-4507-9A52-02AA4FFA2079")),
            new KeyValuePair<AccessPoint, Guid>(AccessPoint.SecurityController, Guid.Parse("C8280D0C-FBBA-4167-BAF8-3250FCC14AA6")),
            new KeyValuePair<AccessPoint, Guid>(AccessPoint.UserController, Guid.Parse("9EFB089E-B4D8-4A15-9000-485ACBC7848C"))
        });

        public static Guid GetAccesPointId(AccessPoint accessPoint)
        {
            return _accessPointDictionary[accessPoint];
        }
    }
}
