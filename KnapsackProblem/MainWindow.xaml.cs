// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs">
//     Copyright (c) 2017, Adrian Kujawski.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows;
using KnapsackProblem.Buisness.Algorithm;
using KnapsackProblem.Buisness.Model;
using KnapsackProblem.Sets;

namespace KnapsackProblem {

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			var sack = new Sack(11, TestSet.SetTwo());
			var ds = new DynamicAlgorithm(sack);
			var bf = new BrutalForceAlgorithm(sack);
			var gr = new GreedyAlgorithm(sack);

			Execute(bf);
			Execute(gr);
			Execute(ds);
		}

		void Execute(KnapsackAlgorithm algorithm) {
			Console.WriteLine(" --- Algorytm " + algorithm.GetType().Name + " --- ");

			var result = algorithm.Compute();
			foreach (var sackItem in result) {
				Console.WriteLine(sackItem);
			}
			Console.WriteLine();
		}
	}

}
