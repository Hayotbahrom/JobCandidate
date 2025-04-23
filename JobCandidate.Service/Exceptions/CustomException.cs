namespace JobCandidate.Service.Exceptions
{
    public class CustomException : Exception
    {
        public int statusCode;
        public CustomException(int code, string message) : base(message)
        {
            statusCode = code;
        }
    }
}
