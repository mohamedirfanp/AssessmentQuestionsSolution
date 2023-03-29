namespace AssessmentQuestions
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Program program = new();
			program.MainforFirstProb();
		}

		protected void MainforFirstProb()
		{
            PersonalityProblem personalityProblem = new PersonalityProblem();
			personalityProblem.MainFunction();

        }

		protected void MainforSecondProb()
		{
			ChocolateQuestion dispenser = new ChocolateQuestion();

			// Add Chocolate Function
			dispenser.addChocolate("red", 10);
			dispenser.addChocolate("yellow", 19);
			dispenser.addChocolate("purple", 3);
			dispenser.addChocolate("crimson", 12);
			dispenser.addChocolate("green", 10);

			// Remove Chocolate Function
			List<string> removed_chocolates = new List<string>();
			removed_chocolates = dispenser.removeChocolate(1);
			Console.Write("The Removed Chocolates : ");
			foreach (var item in removed_chocolates)
			{
				Console.Write(item + ",");

			}

			Console.WriteLine();

			// dispenseChocolates on number 
			List<string> dispensed_chocolates = new List<string>();
			dispensed_chocolates = dispenser.dispenseChocolates(2);
			Console.Write("The Dispensed Chocolates : ");
			foreach (var item in dispensed_chocolates)
			{
				Console.Write(item + ",");
			}

			Console.WriteLine();

			// dispenseChocolatesOfColor on color and number
			List<(string, int)> dispensed_chocolates_on_color = new List<(string, int)>();
			dispensed_chocolates_on_color = dispenser.dispenseChocolatesOfColor("red", 9);
			Console.Write("The Dispensed Chocolates Based on Color : ");
			foreach (var item in dispensed_chocolates_on_color)
			{
				Console.Write(item + ",");
			}

			Console.WriteLine();

			// The total Chocolates 
			List<(string,int)> total_chocolates = new List<(string, int)> ();
			total_chocolates = dispenser.noOfChocolates();
			Console.WriteLine("The total Chocolates Available : ");
			foreach (var item in total_chocolates)
			{
				Console.WriteLine(item);
			}

			// Sorting the Chocolates based on the dictionary Count
			dispenser.sortChocolateBasedOnCount();
			Console.WriteLine("The Dispenser is Sorted in Descending");

			// Color Changing -> number, color, finalColor
			dispenser.changeChocolateColor(10, "yellow", "purple");

			// Change the All the Color -> Color to final color
			dispenser.changeChocolateColorAllOfxCount("red", "silver");

			// Challenge 1
			// Decrease by one choco the color from top 
			dispenser.removeChocolateOfColor("silver");

			// Challenge 2
			// Find the Rainbow count Chocolates
			int rainbow_chocolates = dispenser.dispenseRainbowChocolates(2);
			Console.WriteLine("The Number of rainbow Chocolates : "+  rainbow_chocolates);



		}
	}
}