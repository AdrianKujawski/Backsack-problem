// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using KnapsackProblem.Buisness.Algorithm;
using KnapsackProblem.Buisness.Model;
using KnapsackProblem.Sets;
using Timer = KnapsackProblem.Buisness.Timer.Timer;

namespace KnapsackProblem {

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		List<double> avgDynamicTime = new List<double>();
		List<double> avgGreedyTime = new List<double>();
		int _W;
		int _maxV;
		int _maxW;
		int _minV;
		int _minW;
		int _qty;

		public MainWindow() {
			InitializeComponent();

		}

		void Button_Click(object sender, RoutedEventArgs e) {
			if (!CheckInputData()) return;

			var sack = AddNewItems();

			var brutalForce = new BrutalForceAlgorithm(sack);
			var greedy = new GreedyAlgorithm(sack);
			var dynamic = new DynamicAlgorithm(sack);

			Compute(brutalForce);
			Compute(greedy);
			Compute(dynamic);
		}

		void Compute(KnapsackAlgorithm algorithm) {
			var timer = new Timer(algorithm);
			var result = timer.MeasureTimeWithResult();

			FillTable(algorithm.GetType(), result);
		}

		void FillTable(Type algorithmType, Tuple<IEnumerable<SackItem>, double> result) {
			if (algorithmType == typeof(BrutalForceAlgorithm)) {
				lBFweight.Content = result.Item1.Sum(i => i.Weight);
				lBFvalue.Content = result.Item1.Sum(i => i.Value);
				lBFtime.Content = result.Item2 + "ms";
			}
			else if (algorithmType == typeof(GreedyAlgorithm)) {
				lGweight.Content = result.Item1.Sum(i => i.Weight);
				lGvalue.Content = result.Item1.Sum(i => i.Value);
				lGtime.Content = result.Item2 + "ms";
			}
			else if (algorithmType == typeof(DynamicAlgorithm)) {
				lDweight.Content = result.Item1.Sum(i => i.Weight);
				lDvalue.Content = result.Item1.Sum(i => i.Value);
				lDtime.Content = result.Item2 + "ms";
			}
		}

		Sack AddNewItems() {
			var setOfItems = TestSet.RandomSet(_qty, _minV, _maxV, _minW, _maxW);
			lvItems.Items.Clear();
			setOfItems.ForEach(i => lvItems.Items.Add(i));
			return new Sack(_W, setOfItems);
		}

		bool CheckInputData() {
			try {
				_W = int.Parse(tbBackpackWeight.Text);
				_qty = int.Parse(tbQty.Text);
				_maxV = int.Parse(tbmaxv.Text);
				_maxW = int.Parse(tbmaxw.Text);
				_minV = int.Parse(tbminv.Text);
				_minW = int.Parse(tbminw.Text);
			}
			catch (Exception) {
				return false;
			}

			return true;
		}
	}

}
