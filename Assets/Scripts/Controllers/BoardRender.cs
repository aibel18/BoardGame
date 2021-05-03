using UnityEngine;

namespace BoardGame
{
	public class BoardRender : MonoBehaviour
	{
		public GameObject tilePrefab;
		public GameObject characterPrefab;

		public GameObject[] characterPlayer;
		private Game game;

		void Awake()
		{
			this.game = GameObject.Find("Game").GetComponent<Game>();
		}

		float midleX;
		float midleZ;

		void Start()
		{

			var lengthX = this.game.Board.Length(0);
			var lengthZ = this.game.Board.Length(1);

			midleX = lengthX / 2 - 0.5f;
			midleZ = lengthZ / 2 - 0.5f;

			for (int z = 0; z < lengthZ; ++z)
			{
				for (int x = 0; x < lengthX; ++x)
				{
					GameObject tileObject = Instantiate(tilePrefab, new Vector3(x - midleX, -0.25f, z - midleZ), Quaternion.identity);

					tileObject.transform.SetParent(this.gameObject.transform, false);

					var titleRender = tileObject.AddComponent<TileComponent>() as TileComponent;
					titleRender.collectable = this.game.Board.Matrix[x, z];
					titleRender.position = new Vector2Int(x, z);
				}
			}

			this.characterPlayer = new GameObject[this.game.Players.Length];

			for (int i = 0; i < this.game.Players.Length; i++)
			{
				this.characterPlayer[i] = Instantiate(characterPrefab, new Vector3(this.game.Players[i].Position.x - midleX, 0.5f, this.game.Players[i].Position.y - midleZ), Quaternion.identity);

				this.characterPlayer[i].transform.SetParent(this.gameObject.transform, false);
			}
		}

		void Update()
		{
			TileComponent titleComponent = PickTile.GetTile();

			if (titleComponent != null)
			{
				var playerIndex = this.game.MovePlayer(titleComponent.position);

				var nextPosition = new Vector3(this.game.Players[playerIndex].Position.x - midleX, this.characterPlayer[playerIndex].transform.position.y, this.game.Players[playerIndex].Position.y - midleZ);
				this.characterPlayer[playerIndex].transform.position = nextPosition;
			}
		}

	}
}