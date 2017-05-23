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
			_stopWatch = new Stopwatch();
		}

		public double MeasureTime() {
			_stopWatch.Start();
			_algorithm.Compute();
			_stopWatch.Stop();
			return _stopWatch.Elapsed.TotalMilliseconds;
		}

		public Tuple<IEnumerable<SackItem>, double> MeasureTimeWithResult() {
			_stopWatch.Start();
			var result = _algorithm.Compute();
			_stopWatch.Stop();
			return new Tuple<IEnumerable<SackItem>, double>(result, _stopWatch.Elapsed.TotalMilliseconds);
		}
	}
}
