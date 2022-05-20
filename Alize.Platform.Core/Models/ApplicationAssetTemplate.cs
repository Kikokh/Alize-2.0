using System.ComponentModel.DataAnnotations.Schema;

namespace Alize.Platform.Core.Models
{
    public class ApplicationAssetTemplate
    {
        public IEnumerable<TemplateColumn> Columns { get; set; }

        public IEnumerable<TemplateField> Fields { get; set; }
    }
}