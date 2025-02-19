namespace Skyline.DataMiner.Utils.DOM.Exceptions
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.ManagerStore;
	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	/// Represents an exception that occurs when a bulk CRUD operation fails.
	/// </summary>
	public class BulkCrudFailedException<T> : CrudFailedException where T : IEquatable<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BulkCrudFailedException{T}"/> class.
		/// </summary>
		/// <param name="result">The result of the bulk operation that failed.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> is <c>null</c>.</exception>
		public BulkCrudFailedException(IBulkOperationResult<T> result) : base(result.GetTraceData())
		{
			Result = result ?? throw new ArgumentNullException(nameof(result));
		}

		/// <summary>
		/// Gets the result of the bulk operation that failed.
		/// </summary>
		public IBulkOperationResult<T> Result { get; }

		/// <summary>
		/// Gets the list of identifiers for the items that were successfully processed.
		/// </summary>
		public IList<T> SuccessfulIds => Result.SuccessfulIds;

		/// <summary>
		/// Gets the list of identifiers for the items that failed to process.
		/// </summary>
		public IList<T> UnsuccessfulIds => Result.UnsuccessfulIds;

		/// <summary>
		/// Gets the trace data associated with each item in the operation.
		/// </summary>
		public IDictionary<T, TraceData> TraceDataPerItem => Result.TraceDataPerItem;
	}
}
