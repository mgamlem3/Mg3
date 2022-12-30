namespace Mg3.Utility.RetryUtility;

public static class RetryUtility
{
	/// <summary>
	/// Allows retrying of an async operation when an exception occurs
	/// </summary>
	/// <typeparam name="T">Expected return type from operation</typeparam>
	/// <param name="function">Operation to perform</param>
	/// <param name="maxRetries">Number of times to allow an exception before giving up</param>
	/// <param name="backoffTimes">Optional array of times (in milliseconds) to wait between retries. Can be less than <paramref name="maxRetries"/></param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="function"/> is null</exception>
	/// <exception cref="RetryUtilityException">Thrown when exception occurred on final retry with exception wrapped inside</exception>
	public static async Task<T> RetryOnExceptionAsync<T>(Func<Task<T>> function, int maxRetries = 5, int[]? backoffTimes = null)
	{
		if (function is null)
			throw new ArgumentNullException(nameof(function));

		var retries = 0;
		while (retries <= maxRetries)
		{
			try
			{
				return await function();
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e);

				if (retries == maxRetries)
					throw new RetryUtilityException("Exception on final retry", e, true, true);
				else if (backoffTimes is not null)
					Thread.Sleep(backoffTimes[Math.Min(retries, backoffTimes.Length)]);

			}

			retries++;
		}

		throw new RetryUtilityException($"Unexpected error in {nameof(RetryOnExceptionAsync)}");
	}

	public class RetryUtilityException : Exception
	{
		public RetryUtilityException()
		{
		}

		public RetryUtilityException(string message) : base(message)
		{
		}

		public RetryUtilityException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public RetryUtilityException(string message, Exception innerException, bool? wasThrownFromRetry, bool? wasThrownOnFinalRetry) : base(message, innerException)
		{
			WasThrownFromRetry = wasThrownFromRetry;
			WasThrownOnFinalRetry = wasThrownOnFinalRetry;
		}

		/// <summary>
		/// True if was thrown when attempting retry of an operation
		/// </summary>
		public bool? WasThrownFromRetry { get; set; }

		/// <summary>
		/// True if exception occurred on the final retry of an operation
		/// </summary>
		public bool? WasThrownOnFinalRetry { get; set; }
	}
}
