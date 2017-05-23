using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackProblem.Buisness.Algorithm;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Buisness.Timer {
	public class Timer {
		readonly KnapsackAlgorithm _algorithm;
		readonly Stopwatch _stopWatch;

		public Timer(KnapsackAlgorithm algorithm) {
			_algorithm = algorithm;
			_stopWatch = Stopwatch.StartNew();
		}

		public double MeasureTime() {
			_algorithm.Compute();
			_stopWatch.Stop();
			return _stopWatch.Elapsed.TotalMilliseconds;
		}

		public Tuple<IEnumerable<SackItem>, double> MeasureTimeWithResult() {
			var result = _algorithm.Compute();
			_stopWatch.Stop();
			return new Tuple<IEnumerable<SackItem>, double>(result, _stopWatch.Elapsed.TotalMilliseconds);
		}
	}
}
