using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BoardGame
{

	public class PlayerRender : MonoBehaviour
	{
		public Button[] dices;
		public int playerNumber;
		public Text health;
		public Text attack;

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
				this.dices[i].GetComponentInChildren<Text>().text = ""+this.player.Dices.DiceValues[i];
			}
			this.health.text = "" + this.player.Character.Health;
			this.attack.text = "" + this.player.Character.Attack;
		}
	}
}
