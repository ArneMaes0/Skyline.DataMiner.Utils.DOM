namespace Skyline.DataMiner.Utils.DOM.UnitTesting
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.Net.Messages.SLDataGateway;

	internal class DomPagingHandler<T> : IDisposable
	{
		private readonly IEnumerator<T> _enumerator;

		private bool _hasNext;
		private T _nextRow;

		private bool _isDisposed;

		public DomPagingHandler(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			_enumerator = items.GetEnumerator();
			TryMoveNext();
		}

		public PagingCookie Cookie { get; } = PagingCookie.CreateNew();

		public List<T> GetNextPage(long pageSize, out bool isLast)
		{
			var page = new List<T>();

			for (int i = 0; i < pageSize && _hasNext; i++)
			{
				page.Add(_nextRow);
				TryMoveNext();
			}

			if (!_hasNext)
			{
				Dispose();
			}

			isLast = !_hasNext;
			return page;
		}

		public void Dispose()
		{
			if (_isDisposed)
			{
				return;
			}

			_enumerator?.Dispose();
			_isDisposed = true;
		}

		private void TryMoveNext()
		{
			_hasNext = _enumerator.MoveNext();
			_nextRow = _hasNext ? _enumerator.Current : default;
		}
	}
}
