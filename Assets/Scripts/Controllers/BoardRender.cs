using UnityEngine;
using UnityEngine.UI;

namespace BoardGame
{
	public class BoardRender : MonoBehaviour
	{
		public GameObject tilePrefab;
		public GameObject characterPrefab;

		public Material quadTile;
		public Material quadTileEmpty;
		public Material select;

		public Text fightText;

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

					if (this.game.Board.IsEmpty(x, z))
						tileObject.GetComponent<Renderer>().material = quadTileEmpty;
					else
						tileObject.GetComponent<Renderer>().material = quadTile;

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

			var playerIndex = this.game.GetIndexActivePlayer();

			this.characterPlayer[playerIndex].GetComponent<Renderer>().material = select;
		}

		void Update()
		{
			if (this.game.IsFight)
			{
				fightText.enabled = true;
			}
			else
			{
				fightText.enabled = false;
				GameObject titleObject = PickTile.GetTile();

				if (titleObject == null)
					return;

				TileComponent titleComponent = titleObject.GetComponent<TileComponent>();

				if (this.game.IsValidMove(titleComponent.position))
				{
					this.game.GainPlayer(titleComponent.collectable);

					var playerIndex = this.game.GetIndexActivePlayer();
					var otherPlayerIndex = this.game.GetIndexInactivePlayer();

					var nextPosition = new Vector3(titleComponent.position.x - midleX, this.characterPlayer[playerIndex].transform.position.y, titleComponent.position.y - midleZ);
					this.characterPlayer[playerIndex].transform.position = nextPosition;

					this.game.MovedPlayer(titleComponent.position);

					if (!this.game.CanMove())
					{
						this.characterPlayer[playerIndex].GetComponent<Renderer>().material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Material>("Default-Diffuse.mat");
						this.characterPlayer[otherPlayerIndex].GetComponent<Renderer>().material = select;
					}

					Renderer titleRenderer = titleObject.GetComponent<Renderer>();

					if (this.game.Board.IsEmpty(titleComponent.position.x, titleComponent.position.y))
						titleRenderer.material = quadTileEmpty;
					else
						titleRenderer.material = quadTile;
				}
			}
		}

	}
}