namespace BoardGame
{
	public class BoardGrid
	{

		CollectableType[] types = { CollectableType.ExtraAttack, CollectableType.ExtraMove, CollectableType.RecoverHealth };

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
					this.Matrix[z, x] = new Collectable()
					{
						Type = types[UnityEngine.Random.Range(0, 3)],
						AmountGain = UnityEngine.Random.Range(1, 3)
					};
				}
			}
		}

		public void AddCharacter(int posX, int posZ)
		{
			this.Matrix[posX, posZ].Type = CollectableType.PlayerHere;
			this.Matrix[posX, posZ].AmountGain = 0;
		}

		public void UseCollectable(int posX, int posZ)
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

		public bool IsPlayerHere(int posX, int posZ)
		{
			return this.Matrix[posX, posZ].Type == CollectableType
			.PlayerHere;
		}

		public int Length(int n)
		{
			return this.Matrix.GetLength(n);
		}
	}
}