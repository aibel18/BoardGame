using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class Roller : MonoBehaviour
	{
		public int playerNumber;
		private Game game;

		void Start()
		{
			this.game = GameObject.Find("Game").GetComponent<Game>();
		}

		public void RollDices()
		{
			this.game.RollDives(this.playerNumber);
		}
	}
}
