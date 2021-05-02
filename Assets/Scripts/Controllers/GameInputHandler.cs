using UnityEngine;

namespace BoardGame
{

	public class GameInputHandler : IInputHandler
	{
		public Action GetInput()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				return Action.Up;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				return Action.Down;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				return Action.Left;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				return Action.Right;
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				return Action.DiceRoll;
			}
			return Action.None;
		}
	}
}