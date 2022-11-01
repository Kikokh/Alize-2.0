namespace Alize.Platform.Api.Requests.Assets
{
    public class CreateAssetMetadataRequest
    {
        public Guid AssetId { get; set; }

        public IDictionary<string, dynamic> Data { get; set; }
    }
}
