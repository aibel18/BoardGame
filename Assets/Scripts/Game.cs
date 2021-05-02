using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardGame
{

	public class Game : MonoBehaviour
	{

		private Canvas CanvasObject;

		int count;

		// Start is called before the first frame update
		void Start()
		{
			this.count = 1;
			this.CanvasObject = GameObject.Find("Menu").GetComponent<Canvas>();
			this.CanvasObject.GetComponent<Canvas>().enabled = false;
			print("INIT GAME");
		}

		// Update is called once per frame
		void Update()
		{

			if (this.count % 200 == 0)
			{
				this.CanvasObject.GetComponent<Canvas>().enabled = true;
				print("END GAME");
			}
			else
			{
				this.count++;
			}
		}
	}
}
