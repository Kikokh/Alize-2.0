namespace Alize.Platform.Core.Models
{
    public class AssetsPage
    {
        public int Total { get; set; }

        public IEnumerable<Asset> Assets { get; set; }
    }
}
