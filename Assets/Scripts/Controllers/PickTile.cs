using UnityEngine;

namespace BoardGame
{

	public class PickTile
	{
		public static TileComponent GetTile()
		{
			if (Input.GetMouseButtonUp(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.tag == "TilePrefab")
					{
						return hit.transform.gameObject.GetComponent<TileComponent>();
					}
				}
			}
			return null;
		}
	}
}