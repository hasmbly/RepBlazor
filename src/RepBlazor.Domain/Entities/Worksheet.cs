using System.Collections.Generic;
using RepBlazor.Domain.Common;

namespace RepBlazor.Domain.Entities
{
    public class Worksheet : AuditableEntity
    {
        public string WorksheetID { get; set; }
        public string Name { get; set; }
        public string DocumentID { get; set; }

        public Document Document { get; set; }

        public IList<Activity> Activities { get; private set; }

        public Worksheet()
        {
            Activities = new List<Activity>();
        }
    }
}
