using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class Roller : MonoBehaviour
	{
		public int playerNumber;
		private Player player;

		void Start()
		{
			this.player = GameObject.Find("Game").GetComponent<Game>().Players[playerNumber];
		}

		public void RollDices()
		{
			if (this.player.State)
			{
				this.player.Dices.RollDices();
			}

		}
	}
}
