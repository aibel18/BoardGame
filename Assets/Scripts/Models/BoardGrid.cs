using UnityEngine;

namespace BoardGame
{
	public class BoardGrid
	{
		public Collectable[,] Matrix { get; set; }

		int TileTotal;
		int TileTenPercent;
		int TileCount;

		public BoardGrid(int width, int height)
		{
			this.Matrix = new Collectable[width, height];
			this.InitBoard();
			this.TileCount = this.TileTotal = width * height;
			this.TileTenPercent = (int)(this.TileTotal * 0.1);
		}

		public void InitBoard()
		{
			var lengthX = this.Matrix.GetLength(0);
			var lengthZ = this.Matrix.GetLength(1);

			for (int z = 0; z < lengthZ; ++z)
			{
				for (int x = 0; x < lengthX; ++x)
				{
					this.Matrix[x, z] = new Collectable(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(1, 5));
				}
			}
		}

		public void ReFillBoard(Vector2Int player1, Vector2Int player2)
		{
			var lengthX = this.Matrix.GetLength(0);
			var lengthY = this.Matrix.GetLength(1);

			for (int y = 0; y < lengthY; ++y)
			{
				for (int x = 0; x < lengthX; ++x)
				{
					if ((x == player1.x && y == player1.y) || (x == player2.x && y == player2.y))
					{
						continue;
					}
					if (this.IsEmpty(x, y))
					{
						this.Matrix[x, y].InitCollectable(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(1, 5));
						this.TileCount++;
					}
				}
			}
		}

		public void AddCharacter(int posX, int posZ)
		{
			this.Matrix[posX, posZ].Type = CollectableType.Empty;
			this.Matrix[posX, posZ].AmountGain = 0;
			this.TileCount--;
		}

		public bool VerifyTenPercent()
		{
			return this.TileCount < this.TileTenPercent;
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