// -----------------------------------------------------------------------
// <copyright file="DynamicAlgorithm.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Algorithm {

	public class DynamicAlgorithm : KnapsackAlgorithm {
		readonly int[,] _a;
		readonly int[,] _keepTable;
		SackItem[] _items;

		public DynamicAlgorithm(Sack sack) : base(sack) {
			_a = new int[_sack.ItemsQuantity + 1, _sack.Capacity + 1];
			_keepTable = new int[_sack.ItemsQuantity + 1, _sack.Capacity + 1];
		}

		public override IEnumerable<SackItem> Compute() {
			_items = _sack.SackItems.ToArray();
			CompareItems();
#if DEBUG
			WriteATable();
			WriteKeepTable();
#endif
			ChooseBestItems();
			return _theBestItems;
		}

		void CompareItems() {
			for (var currentItem = 0; currentItem <= _sack.ItemsQuantity; currentItem++) {
				for (var currentCapacity = 0; currentCapacity <= _sack.Capacity; currentCapacity++) {
					if (currentItem == 0 || currentCapacity == 0)
						_a[currentItem, currentCapacity] = 0;
					else if (_items[currentItem - 1].Weight <= currentCapacity)
						_a[currentItem, currentCapacity] = Max(currentItem, currentCapacity);
					else {
						_a[currentItem, currentCapacity] = _a[currentItem - 1, currentCapacity];
					}
				}
			}
		}

		int Max(int item, int capacity) {
			var firstValue = _items[item - 1].Value + _a[item - 1, capacity - _items[item - 1].Weight];
			var secondValue = _a[item - 1, capacity];

			if (firstValue < secondValue) return secondValue;

			_keepTable[item, capacity] = 1;
			return firstValue;
		}

		void ChooseBestItems(){
			_theBestItems.Clear();
			var item = _sack.ItemsQuantity;
			var weight = _sack.Capacity;

			for (var i = item; i > 0; i--) {
				if (_keepTable[i, weight] != 1) continue;

				_theBestItems.Add(_items[i - 1]);
				weight -= _items[i - 1].Weight;
			}
		}

		void WriteKeepTable() {
			for (var currentItem = 0; currentItem <= _sack.ItemsQuantity; currentItem++) {
				for (var currentCapacity = 0; currentCapacity <= _sack.Capacity; currentCapacity++) {
					Console.Write($" {_keepTable[currentItem, currentCapacity]}");
				}

				Console.WriteLine();
			}
		}

		void WriteATable() {
			for (var currentItem = 0; currentItem <= _sack.ItemsQuantity; currentItem++) {
				for (var currentCapacity = 0; currentCapacity <= _sack.Capacity; currentCapacity++) {
					Console.Write($"   {_a[currentItem, currentCapacity]}");
				}

				Console.WriteLine();
			}
		}
	}

}
