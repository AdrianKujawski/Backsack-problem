// -----------------------------------------------------------------------
// <copyright file="BrutalForceAlgorithm.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Algorithm.Helper;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class BrutalForceAlgorithm : KnapsackAlgorithm {
		int _bestValue;

		public BrutalForceAlgorithm(Sack sack) : base(sack) {
			_bestValue = 0;
		}

		public override IEnumerable<SackItem> Compute() {
			CompareItems();
			return _theBestItems;
		}

		void CompareItems() {
			for (var i = 1; i <= _sack.ItemsQuantity; i++) {
				var permutations = Permutation.GetPermutations(_sack.SackItems, i);
				foreach (var items in permutations) {
					int value;
					if (CheckResults(items, out value)) continue;

					SetNewBest(value, items);
				}
			}
		}

		bool CheckResults(IEnumerable<SackItem> items, out int value) {
			value = items.Sum(it => it.Value);
			var size = items.Sum(it => it.Weight);
			return value <= _bestValue || size > _sack.Capacity;
		}

		void SetNewBest(int value, IEnumerable<SackItem> items) {
			_bestValue = value;
			_theBestItems.Clear();
			_theBestItems.AddRange(items);
		}
	}

}
