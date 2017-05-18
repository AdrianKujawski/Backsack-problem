﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackProblem.Buisness.Model;

namespace KnapsackProblem.Sets {
	public static class TestSet {

		public static List<SackItem> SetOne() {
			return new List<SackItem> {
				new SackItem("Ziemniak", 4, 3),
				new SackItem("Rękawica", 5, 1),
				new SackItem("Kamień", 1, 6),
				new SackItem("Pierśceń", 7, 2)
			};
		}

		public static List<SackItem> SetTwo() {
			return new List<SackItem> {
				new SackItem("Koszula flanelowa", 75, 7),
				new SackItem("Spodnie dżinsowe", 150, 8),
				new SackItem("Sweter", 250, 6),
				new SackItem("Czapka baseballowa", 35, 4),
				new SackItem("Kąpielówki", 10, 3),
				new SackItem("Obuwie sportowe", 100, 9)
			};
		}
	}
}
