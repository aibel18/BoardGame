namespace BoardGame
{
	public class Character
	{

		public int Health { get; set; }
		public int Attack { get; set; }

		public Character(int health, int attack)
		{
			this.Health = health;
			this.Attack = attack;
		}
	}
}

