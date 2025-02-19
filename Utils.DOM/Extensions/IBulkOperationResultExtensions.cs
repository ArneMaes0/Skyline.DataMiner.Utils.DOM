namespace Skyline.DataMiner.Utils.DOM.Extensions
{
	using System;

	using Skyline.DataMiner.Net.Messages;
	using Skyline.DataMiner.Utils.DOM.Exceptions;

	/// <summary>
	/// Extension methods for <see cref="IBulkOperationResultExtensions"/>.
	/// </summary>
	public static class IBulkOperationResultExtensions
	{
		/// <summary>
		/// This extension method inspects the result of a bulk operation and throws a <see cref="BulkCrudFailedException{T}"/> if any failures are detected in the operation.
		/// </summary>
		/// <param name="result">The result of the bulk operation that is being inspected for failures.</param>
		/// <exception cref="BulkCrudFailedException{T}">Thrown when the bulk operation result contains one or more failures.</exception>
		/// <typeparam name="T">The type of the items involved in the bulk operation.</typeparam>
		public static void ThrowOnFailure<T>(this IBulkOperationResult<T> result) where T : IEquatable<T>
		{
			if (result == null)
			{
				throw new ArgumentNullException(nameof(result));
			}

			if (result.HasFailures())
			{
				throw new BulkCrudFailedException<T>(result);
			}
		}
	}
}
