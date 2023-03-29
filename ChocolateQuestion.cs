using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentQuestions
{
	internal class ChocolateQuestion
	{

		private List<string> dipenser = new List<string>();
		public List<string> Dispenser
		{
			get
			{
				return dipenser;
			}
			set
			{
				dipenser = value;
			}
		}
		// Top resembles the end
		// Bottom resembles the start


		private SortedDictionary<string,int> chocolateCount = new SortedDictionary<string,int>();
		public SortedDictionary<string, int> ChocolateCount
		{
			get
			{
				return chocolateCount;
			}
		}


		public void addChocolate(string color, int count)
		{
			Dispenser.Add(color);

			if (ChocolateCount.ContainsKey(color)) 
				ChocolateCount[color] = ChocolateCount[color] + count;
			else ChocolateCount[color] = count;
		}
		public List<string> removeChocolate(int remove_number)
		{
			List<string> RemovedChocolateList = new List<string>();

			while(remove_number > 0)
			{
				if (Dispenser.Count <= 0)
					throw new Exception("The Dispenser is Empty!");
				else
				{
					int idx = Dispenser.Count - 1;
					string current_chocolate = Dispenser[idx];
					ChocolateCount.Remove(current_chocolate);
					RemovedChocolateList.Add(current_chocolate);
					Dispenser.Remove(current_chocolate);
				}
				remove_number --;
			}
			return RemovedChocolateList;
		}

		public List<string> dispenseChocolates(int dispense_number)
		{
			if (dispense_number > Dispenser.Count)
				throw new Exception("The Dispense Number is Greater than Dispenser Contains");

			List<string> dispensed_chocolate = new List<string>();

			int idx = 0;
			while(idx < dispense_number)
			{
				string current_chocolate = Dispenser[idx];
				ChocolateCount[current_chocolate] = ChocolateCount[current_chocolate] - 1;
				dispensed_chocolate.Add(current_chocolate);
				idx ++;
			}
			return dispensed_chocolate;
		}

		public List<(string,int)> dispenseChocolatesOfColor(string color, int dispense_number)
		{
			if (!Dispenser.Contains(color))
				throw new Exception("The Chocolate is not avaliable");
			
			List<(string,int)> dispensed_color = new List<(string, int)>();

			int idx = 0;

			while(idx < Dispenser.Count )
			{
				string current_color = Dispenser[idx];
				if(current_color == color)
				{
					if (ChocolateCount[color] < dispense_number)
						throw new Exception("We dont have enough chocolates");

					dispensed_color.Add((current_color, dispense_number));
					ChocolateCount[color] = ChocolateCount[color] - 1;
				}
				idx ++;
			}
			return dispensed_color;
		}

		public List<(string,int)> noOfChocolates()
		{

			//[green, silver, blue, crimson, purple, red, pink]
			List<(string,int)> total_chocolates = new List<(string,int)> ();
			int idx = 0;
			while( idx < Dispenser.Count)
			{
				string current_color = Dispenser[idx];
				total_chocolates.Add((current_color, ChocolateCount[current_color]));
				idx++;
			}
			return total_chocolates;
		}

		public void sortChocolateBasedOnCount()
		{
			Dispenser.Clear();
			foreach (var item in ChocolateCount.OrderByDescending(key => key.Value))
			{
				Dispenser.Add(item.Key);
			}
        }

		public void changeChocolateColor(int count, string color , string finalColor)
		{
			int color_idx = Dispenser.IndexOf(color);
			Dispenser[color_idx] = finalColor;
			//int Choco_count = ChocolateCount[color];
			ChocolateCount.Remove(color);
			ChocolateCount[finalColor] = count ;

		}


		public List<(string,int)> changeChocolateColorAllOfxCount(string color, string finalColor)
		{
			int idx = 0;
			List<(string,int)> total_final_color = new List<(string, int)> ();
            while (idx < Dispenser.Count)
			{
				if (Dispenser[idx] == color)
				{
					Dispenser[idx] = finalColor;
					int choco_count = ChocolateCount[color];
					ChocolateCount.Remove(color);
					ChocolateCount[finalColor] = choco_count;
					total_final_color.Add((finalColor, choco_count));

				}

				idx++;

			}
			return total_final_color;
		}

		public void removeChocolateOfColor(string color)
		{
			int idx = ChocolateCount.Count - 1;
			while (idx >= 0)
			{
				if (Dispenser[idx] == color)
				{
					ChocolateCount[color] = ChocolateCount[color] - 1;
					return;
				}
			}
		}

		public int dispenseRainbowChocolates(int rainbow_dispense)
		{
			int rainbow_dispense_count = 0;
			foreach (var item in ChocolateCount)
			{
				int numberRainbow = item.Value / 3;
				rainbow_dispense_count += numberRainbow;
			}
			return Math.Min(rainbow_dispense,rainbow_dispense_count);
		}


	}
}
