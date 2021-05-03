using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class Game : MonoBehaviour
	{

		private Canvas UICanvas;
		private IInputHandler InputHandler;

		public BoardGrid Board { get; set; }
		public Player[] Players { get; set; }

		int count;

		void Awake()
		{
			this.UICanvas = GameObject.Find("UI").GetComponent<Canvas>();
			this.InputHandler = new GameInputHandler();
			this.Board = new BoardGrid(8, 8);

			this.Players = new Player[2];
			this.Players[0] = new Player(true);
			this.Players[1] = new Player(false);

			this.InitPostionPlayer(0, 0, this.Board.Length(1) / 2);
			this.InitPostionPlayer(1, this.Board.Length(0) - 1, this.Board.Length(1) / 2);
		}

		// Start is called before the first frame update
		void Start()
		{

			this.count = 1;
		}

		// Update is called once per frame
		void Update()
		{
			var inputKey = this.InputHandler.GetInput();

			if (inputKey != Action.None)
				print("KEY:" + inputKey);

			if (this.count % 500 == 0)
			{
				SceneManager.LoadScene("FinalMenu", LoadSceneMode.Single);
			}
			else
			{
				this.count++;
			}

			if (this.count % 100 == 0)
			{
				this.ChangeTurn();
			}
		}

		void InitPostionPlayer(int player, int posX, int posY)
		{
			this.Players[player].Position = new Vector2Int(posX, posY);
			this.Board.AddCharacter(posX, posY);
		}

		public int MovePlayer(Vector2Int nextPosition)
		{
			var playerIndex = this.GetPlayerActive();

			this.Players[playerIndex].Position = nextPosition;
			this.Board.AddCharacter(nextPosition.x, nextPosition.y);

			return playerIndex;
		}

		void ChangeTurn()
		{
			this.Players[0].State = !this.Players[0].State;
			this.Players[1].State = !this.Players[1].State;
		}

		int GetPlayerActive()
		{
			if (this.Players[0].State)
				return 0;
			return 1;
		}
	}
}
