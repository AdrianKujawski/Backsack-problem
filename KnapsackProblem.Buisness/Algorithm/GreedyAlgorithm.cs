using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class GreedyAlgorithm {
		readonly Sack _sack;
		readonly List<SackItem> _theBestItems;
		int _currentWeight;
		IEnumerable<SackItem> _sortedItem;

		public GreedyAlgorithm(Sack sack) {
			_theBestItems = new List<SackItem>();
			_sack = sack;
			_currentWeight = 0;
		}

		public IEnumerable<SackItem> Compute() {
			SortItems();
			CompareItems();
			return _theBestItems;
		}

		void CompareItems() {
			foreach (var sackItem in _sortedItem) {
				if(sackItem.Weight + _currentWeight > _sack.Capacity) continue;

				_currentWeight += sackItem.Weight;
				_theBestItems.Add(sackItem);
			}
		}

		void SortItems() {
			_sortedItem = _sack.SackItems.OrderByDescending(item => item.Value / item.Weight);
		}
	}
}
