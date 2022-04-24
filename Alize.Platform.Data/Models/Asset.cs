namespace Alize.Platform.Data.Models
{
    public class Asset
    {
        public string Id { get; set; }

        public dynamic Content { get; set; }

        public Application Application { get; set; }

        public Guid ApplicationId { get; set; }
    }
}
