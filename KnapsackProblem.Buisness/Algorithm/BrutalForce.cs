// -----------------------------------------------------------------------
// <copyright file="BrutalForce.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Algorithm.Helper;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class BrutalForce {
		readonly Sack _sack;
		readonly List<SackItem> _theBestItems;
		int _bestValue;
		IEnumerable<SackItem> _sortedItem;

		public BrutalForce(Sack sack) {
			_theBestItems = new List<SackItem>();
			_sack = sack;
			_bestValue = 0;
		}

		public IEnumerable<SackItem> Compute() {
			SortItems();
			CompareItems();
			Write();
			return _theBestItems;
		}

		void CompareItems() {
			for (var i = 1; i <= _sortedItem.Count(); i++) {
				var loo = Permutation.GetPermutations(_sortedItem, i);
				foreach (var items in loo) {
					var value = items.Sum(it => it.Value);
					var size = items.Sum(it => it.Size);
					if (value <= _bestValue || size > _sack.Capacity) continue;

					SetNewBest(value, items);
				}
			}
		}

		void SetNewBest(int value, IEnumerable<SackItem> items) {
			_bestValue = value;
			_theBestItems.Clear();
			_theBestItems.AddRange(items);
		}

		void SortItems() {
			_sortedItem = _sack.SackItems.OrderBy(item => item.Value / item.Size);
		}

		void Write() {
			foreach (var sackSackItem in _theBestItems) {
				Console.WriteLine(sackSackItem);
			}
		}
	}

}
