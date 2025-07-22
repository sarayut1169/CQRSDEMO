namespace CQRSDEMO.CQRS.Validation
{
    public interface IValidationMessageProvider
    {
        string GetMessage(string code);
    }


}
