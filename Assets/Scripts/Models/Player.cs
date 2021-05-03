namespace BoardGame
{
	public class Player
	{
		public bool State { get; set; }
		public bool FightState { get; set; }
		public Dices Dices { get; set; }

		public int Health { get; set; }
		public int Attack { get; set; }
		public int Move { get; set; }
		public UnityEngine.Vector2Int Position { get; set; }

		public Player(int health)
		{
			this.Dices = new Dices(3, 6);
			
			this.Health = health;

			this.State = false;
			this.FightState = false;
			this.Attack = 0;
			this.Move = 0;

		}
	}
}