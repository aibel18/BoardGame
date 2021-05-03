namespace BoardGame
{
	public class Dices : IRollEvent
	{
		public int[] DiceValues { get; set; }
		public int DiceNumber;
		public int SideNumber;

		public Dices(int diceNumber, int sideNumber)
		{
			this.DiceNumber = diceNumber;
			this.SideNumber = sideNumber;
			this.DiceValues = new int[sideNumber];

			this.RollDices();
		}

		public void RollDices()
		{
			for (int i = 0; i < this.DiceNumber; i++)
			{
				this.DiceValues[i] = UnityEngine.Random.Range(0,this.SideNumber) + 1;
			}
		}

	}
}