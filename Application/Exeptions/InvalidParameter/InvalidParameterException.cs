namespace Application.Exceptions.InvalidParameter
{
	public class InvalidParameterException : BaseCustomException
	{
		public InvalidParameterException(string parameterName)
			: base($"Invalid parameter {parameterName}.")
		{
		}
	}
}