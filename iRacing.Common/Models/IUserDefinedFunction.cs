namespace iRacing.Common.Models
{
    public interface IUserDefinedFunction : IFunction
    {
        string fileName { get; set; }
    }
}
