namespace HinweigeberRestApi.SharedModels
{
	public class ReturnResult<T> : OperationResult
	{
		public T Result { get; set; }
	}

	public class OperationResult
	{
		public bool IsSuccess { get; set; } = true;

		public string ErrorMessage { get; set; }
	}
}
