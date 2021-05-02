namespace BoardGame
{
	public class BoardGrid
	{

		public char[,] Matrix { get; set; }

		public BoardGrid(int width, int height)
		{
			this.Matrix = new char[width, height];

		}
	}
}