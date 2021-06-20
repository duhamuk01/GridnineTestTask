using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
	static class Filter<T> where T: class
	{
		public static List<T> FilterCollection(ICollection<T> collection, params ICheck<T>[] filterRules)
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			var src = collection;
			List<T> result = null;
			foreach (var rule in filterRules)
			{
				result = new List<T>();
				Parallel.ForEach(src, (element) => { 
					if (rule.Check(element)) 
						lock(result)
							result.Add(element); 
				});
				src = result;
			}
			return result;
		}
	}
}
