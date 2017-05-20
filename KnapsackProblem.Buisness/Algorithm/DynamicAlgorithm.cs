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

	public class DynamicAlgorithm {
		readonly Sack _sack;
		readonly List<SackItem> _theBestItems;
		int _currentWeight;
		int[,] _keepTable;

		SackItem[] _sortedItem;
		int[,] A;

		public DynamicAlgorithm(Sack sack) {
			_theBestItems = new List<SackItem>();
			_sack = sack;
			A = new int[_sack.ItemsQuantity + 1, _sack.Capacity + 1];
			_keepTable = new int[_sack.ItemsQuantity + 1, _sack.Capacity + 1];
			_currentWeight = 0;
		}

		public void Compute() {
			_sortedItem = _sack.SackItems.OrderBy(sk => sk.Value / sk.Weight).ToArray();

			for (var currentItem = 0; currentItem <= _sack.ItemsQuantity; currentItem++) {
				for (var currentCapacity = 0; currentCapacity <= _sack.Capacity; currentCapacity++) {
					if (currentItem == 0 || currentCapacity == 0)
						A[currentItem, currentCapacity] = 0;
					else if (_sortedItem[currentItem - 1].Weight <= currentCapacity)
						A[currentItem, currentCapacity] = Max(currentItem, currentCapacity);
					else {
						A[currentItem, currentCapacity] = A[currentItem - 1, currentCapacity];
					}
				}
			}

			Console.WriteLine(A[_sack.ItemsQuantity, _sack.Capacity]);
#if DEBUG
			WriteATable();
			WriteKeepTable();
			ShowBestSolution();
#endif
		}

		int Max(int item, int capacity) {
			var firstValue = _sortedItem[item - 1].Value + A[item - 1, capacity - _sortedItem[item - 1].Weight];
			var secondValue = A[item - 1, capacity];

			if (firstValue < secondValue) return secondValue;

			_keepTable[item, capacity] = 1;
			return firstValue;
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
					Console.Write($"   {A[currentItem, currentCapacity]}");
				}
				Console.WriteLine();
			}
		}

		void ShowBestSolution() {
			Console.WriteLine(Environment.NewLine + " --- The best solution --- ");

			var item = _sack.ItemsQuantity;
			var weight = _sack.Capacity;

			for (var i = item; i > 0; i--) {
				if (_keepTable[i, weight] == 1) {
					Console.WriteLine(_sortedItem[i-1]);
					weight--;
				}
			}
		}
	}

}
