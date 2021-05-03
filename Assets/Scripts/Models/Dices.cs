namespace BoardGame
{
	public class Dices : IRollEvent
	{
		public int[] DiceValue { get; set; }
		public int DiceNumber;
		public int SideNumber;

		public Dices(int diceNumber, int sideNumber)
		{
			this.DiceNumber = diceNumber;
			this.SideNumber = sideNumber;
			this.DiceValue = new int[diceNumber];

			this.RollDices();
		}

		public void RollDices()
		{
			for (int i = 0; i < this.DiceNumber; i++)
			{
				this.DiceValue[i] = UnityEngine.Random.Range(0, this.SideNumber) + 1;
			}
		}

		public bool CompareDive(int[] OtherDiceValues)
		{

			int[] dicesOrdered1 = new int[this.DiceNumber];
			int[] dicesOrdered2 = new int[this.DiceNumber];

			this.DiceValue.CopyTo(dicesOrdered1, 0);
			OtherDiceValues.CopyTo(dicesOrdered2, 0);

			System.Array.Sort(dicesOrdered1);
			System.Array.Sort(dicesOrdered2);

			int count = 0;

			for (int i = 0; i < this.DiceNumber; i++)
			{
				if (dicesOrdered1[i] >= dicesOrdered2[i])
					count++;
				else
					count--;
			}

			return count >= 0;

		}


	}
}