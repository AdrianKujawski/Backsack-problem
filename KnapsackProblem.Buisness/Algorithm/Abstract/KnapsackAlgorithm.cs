using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public abstract class KnapsackAlgorithm {
		protected readonly Sack _sack;
		protected readonly List<SackItem> _theBestItems;
		IEnumerable<SackItem> _sortedItem;

		protected KnapsackAlgorithm(Sack sack) {
			_theBestItems = new List<SackItem>();
			_sack = sack;
		}

		public abstract IEnumerable<SackItem> Compute();

		void SortItems() {
			_sortedItem = _sack.SackItems.OrderByDescending(item => item.Value / item.Weight);
		}
	}

}