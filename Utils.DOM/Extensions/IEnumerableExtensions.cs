namespace Skyline.DataMiner.Utils.DOM.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	internal static class IEnumerableExtensions
	{
		public static IEnumerable<TResult> SelectNonNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return source.Select(selector).Where(x => x != null);
		}
	}
}
