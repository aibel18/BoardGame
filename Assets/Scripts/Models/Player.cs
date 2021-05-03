using System;

namespace BoardGame
{
	public class Player
	{
		public Dices Dices { get; set; }
		public Character Character { get; set; }

		public Player()
		{
				this.Dices = new Dices(3, 6);
				this.Character = new Character(10,5);

		}
	}
}