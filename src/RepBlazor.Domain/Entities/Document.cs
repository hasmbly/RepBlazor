using System.Collections.Generic;
using RepBlazor.Domain.Common;

namespace RepBlazor.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public string DocumentID { get; set; }
        public string Name { get; set; }

        public IList<Worksheet> Worksheets { get; set; }

        public Document()
        {
            Worksheets = new List<Worksheet>();
        }
    }
}