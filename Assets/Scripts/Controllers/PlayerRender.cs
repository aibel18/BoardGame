using UnityEngine;
using UnityEngine.UI;

namespace BoardGame
{

	public class PlayerRender : MonoBehaviour
	{
		public Button[] dices;
		public Button state;
		public int playerNumber;
		public Text health;
		public Text attack;
		public Text move;

		private Player player;

		// Start is called before the first frame update
		void Start()
		{
			this.player = GameObject.Find("Game").GetComponent<Game>().Players[playerNumber];
		}

		// Update is called once per frame
		void Update()
		{
			for (int i = 0; i < dices.Length; i++)
			{
				this.dices[i].GetComponentInChildren<Text>().text = "" + this.player.Dices.DiceValue[i];
			}

			this.health.text = "" + this.player.Health;
			this.attack.text = "" + this.player.Attack;
			this.move.text = "" + this.player.Move;

			this.state.GetComponent<Image>().color = this.player.State ? Color.green : Color.clear;

		}
	}
}
