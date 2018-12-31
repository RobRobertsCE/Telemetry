namespace iRacing.Common.Models
{
    public interface IValue
    {
        string FieldName { get; }
        object FieldValue { get; }
    }
}