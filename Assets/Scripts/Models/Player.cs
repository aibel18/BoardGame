using System;

namespace BoardGame
{
	public class Player
	{
		public bool State { get; set; }
		public Dices Dices { get; set; }

		public int Health { get; set; }
		public int Attack { get; set; }
		public UnityEngine.Vector2Int Position { get; set; }

		public Player(bool state)
		{
			this.Dices = new Dices(3, 6);

			this.Health = 10;
			this.Attack = 5;
			this.State = state;
		}
	}
}