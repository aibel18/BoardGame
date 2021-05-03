using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class NavegationMenu : MonoBehaviour
	{
		public void SwitchScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}

		public void ExitApp()
		{
			Application.Quit();
		}
	}
}
