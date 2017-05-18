using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem.Buisness.Model {

	public class SackItem {

		public string Name { get; }
		public int Value { get; }
		public int Weight { get; }

		public SackItem(string name, int value, int weight) {
			Name = name;
			Value = value;
			Weight = weight;
		}

		public override string ToString() {
			return $"{Name}, Size:{Weight}, Value:{Value}";
		}
	}

}
