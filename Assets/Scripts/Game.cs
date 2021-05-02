using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardGame
{

	public class Game : MonoBehaviour
	{

		private Canvas CanvasObject;
		private IInputHandler InputHandler;

		public BoardGrid Board { get; set; }

		int count;

		void Awake()
		{
			this.CanvasObject = GameObject.Find("Menu").GetComponent<Canvas>();
			this.InputHandler = new GameInputHandler();
			this.Board = new BoardGrid(16, 16);
		}

		// Start is called before the first frame update
		void Start()
		{
			this.count = 1;
			this.CanvasObject.GetComponent<Canvas>().enabled = false;
		}

		// Update is called once per frame
		void Update()
		{
			var inputKey = this.InputHandler.GetInput();

			if (inputKey != Action.None)
				print("KEY:" + inputKey);

			if (this.count % 200 == 0)
			{
				this.CanvasObject.GetComponent<Canvas>().enabled = true;
				// print("END GAME");
			}
			else
			{
				this.count++;
			}
		}
	}
}
