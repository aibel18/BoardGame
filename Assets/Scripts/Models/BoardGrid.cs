namespace BoardGame
{
	public class BoardGrid
	{
		public Collectable[,] Matrix { get; set; }

		public BoardGrid(int width, int height)
		{
			this.Matrix = new Collectable[width, height];
			this.InitBoard();
		}

		public void InitBoard()
		{
			var lengthX = this.Matrix.GetLength(0);
			var lengthZ = this.Matrix.GetLength(1);

			for (int z = 0; z < lengthZ; ++z)
			{
				for (int x = 0; x < lengthX; ++x)
				{
					this.Matrix[z, x] = new Collectable(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(1, 5));
				}
			}
		}

		public void AddCharacter(int posX, int posZ)
		{
			this.Matrix[posX, posZ].Type = CollectableType.Empty;
			this.Matrix[posX, posZ].AmountGain = 0;
		}

		public void VerifyTenPercent()
		{

		}

		public bool IsEmpty(int posX, int posZ)
		{
			return this.Matrix[posX, posZ].Type == CollectableType
			.Empty;
		}

		public int Length(int n)
		{
			return this.Matrix.GetLength(n);
		}
	}
}