using UnityEngine;

namespace BoardGame
{
	public class MathUtil
	{
		public static bool DistanceMinorThan(Vector2Int v1, Vector2Int v2, float distance)
		{
			var v = v1 - v2;

			if (Mathf.Abs(v.x) <= distance && Mathf.Abs(v.y) <= distance)
			{
				return true;
			}
			return false;
		}
	}
}