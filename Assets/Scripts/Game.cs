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
			this.Board = new BoardGrid(16, 16);

			this.Players =  new Player[2];
			this.Players[0] = new Player();
			this.Players[1] = new Player();
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
		}
	}
}
