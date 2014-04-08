using System;

namespace TeamHaven.WebApi.Models
{
	public class WebApiResult<T>
	{
		public T Result { get; set; }
		public ApiStatus Status { get; set; }

		public static WebApiResult<T> Failure(string message)
		{
			return new WebApiResult<T>
			{
				Result = default(T),
				Status = new ApiStatus
				{
					Success = false,
					Message = message
				}
			};
		}

		public static WebApiResult<T> Success(T result)
		{
			return new WebApiResult<T>
			{
				Result = result,
				Status = new ApiStatus
				{
					Success = true,
					Message = null
				}
			};
		}
	}
}
