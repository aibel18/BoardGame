using System;

namespace BoardGame
{
	public class Dice
	{
		public int[] Numbers { get; set; }

		public Dice(int SideNumber)
		{
			this.Numbers = new int[SideNumber];
			for (int i = 0; i < this.Numbers.Length; i++)
			{
				this.Numbers[i] = i + 1;
			}
		}

		public int Roll()
		{
			var side = new Random().Next(this.Numbers.Length);
			return this.Numbers[side];
		}

	}
}