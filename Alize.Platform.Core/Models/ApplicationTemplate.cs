using Alize.Platform.Core.Constants;

namespace Alize.Platform.Core.Models
{
    public class ApplicationTemplate : ApplicationItem
    {
        public IEnumerable<TemplateColumn> Columns { get; set; }

        public override string Type => ApplicationItemTypes.ApplicationTemplate;
    }
}
