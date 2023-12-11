namespace Application.Exceptions.Authorize
{
    public class UnAuthorizedException : BaseCustomException
    {
        public UnAuthorizedException()
            : base("You are not authorized to perform this action.")
        {
        }
    }
}