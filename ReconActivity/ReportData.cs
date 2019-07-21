namespace ReconActivity
{
    public class ReportData
    {
        public DifferenceType DifferenceType { get; set;}
        public int? LeftLineNumber { get; set;}
        public int? RightLineNumber { get; set;}
        public string Xpath { get; set;}
        public string OldValue { get; set;}
        public string NewValue { get; set;}
    }

    public enum DifferenceType
    {
        AttributeChange,
        AttributeMissing,
        AttributeAdded,
        ElementChange,
        ElementMissing,
        ElementAdded
    }
}
