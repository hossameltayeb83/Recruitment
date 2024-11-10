namespace Recruitment.Common
{
    public abstract class SetupKeyValue
    {
        public decimal Id { get; set; }
        public string? ValueAr { get; set; }
        public string? ValueEn {  get; set; }
        public bool HasParent { get; set; }
    }
}
