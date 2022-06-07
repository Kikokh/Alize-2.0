namespace Alize.Platform.Api.Responses.Assets
{
    public class AssetHistoryResponse
    {
        public string TransactionId { get; set; }

        public Dictionary<string, object> Metadata { get; set; }
    }
}
