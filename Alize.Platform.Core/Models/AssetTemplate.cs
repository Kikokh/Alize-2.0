using Alize.Platform.Core.Constants;

namespace Alize.Platform.Core.Models
{
    public class AssetTemplate : ApplicationItem
    {
        public IEnumerable<TemplateColumn>? Columns { get; set; }

        public IEnumerable<TemplateField>? Fields { get; set; }

        public IEnumerable<TemplateStep>? Steps { get; set; }

        public bool? HasVideo { get; set; }

        public override string Type => ApplicationItemTypes.AssetTemplate;
    }
}