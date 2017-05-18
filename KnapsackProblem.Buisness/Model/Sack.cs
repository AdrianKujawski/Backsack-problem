using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem.Buisness.Model {

	public class Sack {
		public IEnumerable<SackItem> SackItems { get; }
		public int Capacity { get; }
		public int ItemsQuantity => SackItems.Count();

		public Sack(IEnumerable<SackItem> sackItems) {
			SackItems = sackItems;
		}

		public Sack(int capacity, IEnumerable<SackItem> sackItems) {
			SackItems = sackItems;
			Capacity = capacity;
		}

		public void ShowItems() {
			if (SackItems == null) return;
			foreach (var sackItem in SackItems) {
				Console.WriteLine(sackItem);
			}
		}
	}

}
