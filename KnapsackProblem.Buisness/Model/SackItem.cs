using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem.Buisness.Model {

	public class SackItem {

		public string Name { get; }
		public int Value { get; }
		public int Size { get; }

		public SackItem(string name, int value, int size) {
			Name = name;
			Value = value;
			Size = size;
		}

		public override string ToString() {
			return $"{Name}, Size:{Size}, Value:{Value}";
		}
	}

}
