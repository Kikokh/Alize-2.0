namespace Alize.Platform.Api.Responses.Assets
{
    public class AssetsPageResponse
    {
        public int Total { get; set; }

        public IEnumerable<AssetResponse> Assets { get; set; }
    }
}
