using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{
	public class TileComponent : MonoBehaviour
	{
		public Collectable collectable {get; set;}
		public Vector2Int position {get; set;}
	}
}
