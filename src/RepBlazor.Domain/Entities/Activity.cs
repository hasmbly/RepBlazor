using RepBlazor.Domain.Common;

namespace RepBlazor.Domain.Entities
{
    public class Activity : AuditableEntity
    {
        public string ActivityID { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string WorksheetID { get; set; }

        public Worksheet Worksheet { get; set; }
    }
}