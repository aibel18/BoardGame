using UnityEngine;
using UnityEngine.UI;

namespace BoardGame
{

	public class FinalMenu : MonoBehaviour
	{

		public Text player;
		public Text health;

		void Start()
		{
			this.player.text = PlayerPrefs.GetString(KeyWordPersistence.NamePlayer + 1);
			this.health.text = PlayerPrefs.GetString(KeyWordPersistence.HealthPlayer);
		}
	}
}
