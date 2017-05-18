// -----------------------------------------------------------------------
// <copyright file="BrutalForce.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Algorithm.Helper;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class BrutalForce {
		readonly Sack _sack;
		readonly List<SackItem> _theBestItems;
		int _bestValue;

		public BrutalForce(Sack sack) {
			_theBestItems = new List<SackItem>();
			_sack = sack;
			_bestValue = 0;
		}

		public IEnumerable<SackItem> Compute() {
			CompareItems();
			return _theBestItems;
		}

		void CompareItems() {
			for (var i = 1; i <= _sack.SackItems.Count(); i++) {
				var loo = Permutation.GetPermutations(_sack.SackItems, i);
				foreach (var items in loo) {
					int value;
					if (CheckResults(items, out value)) continue;

					SetNewBest(value, items);
				}
			}
		}

		bool CheckResults(IEnumerable<SackItem> items, out int value) {
			value = items.Sum(it => it.Value);
			var size = items.Sum(it => it.Weight);
			if (value <= _bestValue || size > _sack.Capacity) return true;

			return false;
		}

		void SetNewBest(int value, IEnumerable<SackItem> items) {
			_bestValue = value;
			_theBestItems.Clear();
			_theBestItems.AddRange(items);
		}
	}

}
