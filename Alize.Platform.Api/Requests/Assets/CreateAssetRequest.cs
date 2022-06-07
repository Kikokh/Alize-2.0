namespace Alize.Platform.Api.Requests.Assets
{
    public class CreateAssetRequest
    {
        public Guid ApplicationId { get; set; }

        public Dictionary<string, object> Data { get; set; }

        public string? Namespace { get; set; }
    }
}
