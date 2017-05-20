// -----------------------------------------------------------------------
// <copyright file="GreedyAlgorithm.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class GreedyAlgorithm : KnapsackAlgorithm {
		int _currentWeight;
		IEnumerable<SackItem> _sortedItem;

		public GreedyAlgorithm(Sack sack) : base(sack) {
			_currentWeight = 0;
		}

		public override IEnumerable<SackItem> Compute() {
			SortItems();
			CompareItems();
			return _theBestItems;
		}

		void CompareItems() {
			foreach (var sackItem in _sortedItem) {
				if (sackItem.Weight + _currentWeight > _sack.Capacity) continue;

				_currentWeight += sackItem.Weight;
				_theBestItems.Add(sackItem);
			}
		}

		void SortItems() {
			_sortedItem = _sack.SackItems.OrderByDescending(item => item.Value / item.Weight);
		}
	}

}
