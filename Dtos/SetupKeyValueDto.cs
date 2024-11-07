using Recruitment.Enums;

namespace Recruitment.Dtos
{
    public class SetupKeyValueDto
    {
        public decimal ErpKey { get; set; }
        public EventType EventType { get; set; }
        public Document DocumentType { get; set; }
        public string Value { get; set; }
    }
}
