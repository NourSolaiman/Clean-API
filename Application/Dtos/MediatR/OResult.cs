namespace Application.Dtos.MediatR
{
	internal class OResult<T>
	{
		public T? Result { get; set; }
		public required bool IsSuccess { get; set; }
		public string? ErrorMessage { get; set; }
	}
}
