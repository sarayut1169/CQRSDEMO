namespace CQRSDEMO.CQRS.Bases
{

    public class InformationMessage
    {
        public MessageType Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public enum MessageType
    {
        SystemError = 1,
        Error = 2,
        Warning = 3,
        Success = 4,
        Info = 5
    }
}
