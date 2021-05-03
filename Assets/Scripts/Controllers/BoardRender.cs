using UnityEngine;

namespace BoardGame
{
	public class BoardRender : MonoBehaviour
	{
		public GameObject tilePrefab;
		private Game game;

		void Awake()
		{
			this.game = GameObject.Find("Game").GetComponent<Game>();
		}

		void Start()
		{

			var midleX = this.game.Board.Matrix.GetLength(0) / 2;
			var midleZ = this.game.Board.Matrix.GetLength(1) / 2;

			for (int z = -midleZ; z < midleZ; ++z)
			{
				for (int x = -midleX; x < midleX; ++x)
				{
					Instantiate(tilePrefab, new Vector3(x + 0.5f, 0, z + 0.5f), Quaternion.identity);
				}
			}
		}

	}
}