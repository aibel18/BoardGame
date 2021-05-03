using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class Roller : MonoBehaviour
	{
		public int playerNumber;
		public IRollEvent eventRoll;

		void Start()
		{
			this.eventRoll = GameObject.Find("Game").GetComponent<Game>().Players[playerNumber].Dices;
		}

		public void RollDices()
		{
			this.eventRoll.RollDices();
		}
	}
}
