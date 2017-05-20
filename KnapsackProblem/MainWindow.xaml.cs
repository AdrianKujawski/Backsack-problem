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

			var sack = new Sack(5, TestSet.SetOne());
			var ds = new DynamicAlgorithm(sack);
			var result = ds.Compute();
			foreach (var sackItem in result) {
				Console.WriteLine(sackItem);
			}
		}
	}

}
