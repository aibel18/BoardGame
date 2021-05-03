using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoardGame
{

	public class Game : MonoBehaviour
	{

		private Canvas UICanvas;
		private IInputHandler InputHandler;

		public BoardGrid Board { get; set; }
		public Player[] Players { get; set; }

		public bool IsFight { get; set; }

		int indexActivePlayer;
		int MoveDefault = 3;

		void Awake()
		{
			this.UICanvas = GameObject.Find("UI").GetComponent<Canvas>();
			this.InputHandler = new GameInputHandler();
			this.Board = new BoardGrid(8, 8);

			this.Players = new Player[2];
			this.Players[0] = new Player(5);
			this.Players[1] = new Player(5);

			this.InitPostionPlayer(0, 0, this.Board.Length(1) / 2);
			this.InitPostionPlayer(1, this.Board.Length(0) - 1, this.Board.Length(1) / 2);
		}

		// Start is called before the first frame update
		void Start()
		{
			this.indexActivePlayer = 0;
			this.Players[this.indexActivePlayer].State = true;

			this.Players[0].Move = MoveDefault;
			this.Players[1].Move = MoveDefault;
			this.IsFight = false;
		}

		// Update is called once per frame
		void Update()
		{
			var inputKey = this.InputHandler.GetInput();

			if (inputKey != Action.None)
				print("KEY:" + inputKey);

			if (this.IsFight)
			{
				if (!this.Players[0].FightState && !this.Players[1].FightState)
				{
					this.Fight();
				}
			}
			else
			{
				this.TurnPlayer();
			}

		}

		void InitPostionPlayer(int player, int posX, int posY)
		{
			this.Players[player].Position = new Vector2Int(posX, posY);
			this.Board.AddCharacter(posX, posY);
		}

		void TurnPlayer()
		{

			if (this.Players[0].Health <= 0 || this.Players[1].Health <= 0)
			{
				SceneManager.LoadScene("FinalMenu", LoadSceneMode.Single);
			}

			if (this.Players[this.indexActivePlayer].Move <= 0)
			{
				this.ChangeTurn();
			}
		}

		public bool IsValidMove(Vector2Int nextPosition)
		{
			var otherPlayerPosition = this.Players[this.GetIndexInactivePlayer()].Position;

			if (!MathUtil.DistanceMinorThan(this.Players[this.indexActivePlayer].Position, nextPosition, 1f))
			{
				return false;
			}

			if (otherPlayerPosition.x != nextPosition.x || otherPlayerPosition.y != nextPosition.y)
				return true;
			return false;
		}

		public void MovedPlayer(Vector2Int nextPosition)
		{
			this.Players[this.indexActivePlayer].Position = nextPosition;
			this.Board.AddCharacter(nextPosition.x, nextPosition.y);
			this.Players[this.indexActivePlayer].Move--;

			VerifyFight();
		}

		void VerifyFight()
		{
			if (MathUtil.DistanceMinorThan(this.Players[0].Position, this.Players[1].Position, 1f))
			{
				this.Players[0].FightState = true;
				this.Players[1].FightState = true;
				this.IsFight = true;
			}
		}

		void Fight()
		{
			// win current player
			if (this.Players[this.indexActivePlayer].Dices.CompareDive(this.Players[this.GetIndexInactivePlayer()].Dices.DiceValue))
			{
				this.Players[this.GetIndexInactivePlayer()].Health -= this.Players[this.indexActivePlayer].Attack;
				this.Players[this.indexActivePlayer].Attack = 0;
			}
			// win other player
			else
			{
				this.Players[this.indexActivePlayer].Health -= this.Players[this.GetIndexInactivePlayer()].Attack;
				this.Players[this.GetIndexInactivePlayer()].Attack = 0;
			}

			this.IsFight = false;
		}

		public void GainPlayer(Collectable collectable)
		{
			switch (collectable.Type)
			{
				case CollectableType.RecoverHealth:
					this.Players[this.indexActivePlayer].Health += collectable.AmountGain;
					break;
				case CollectableType.ExtraMove:
					this.Players[this.indexActivePlayer].Move += collectable.AmountGain;
					break;
				case CollectableType.ExtraAttack:
					this.Players[this.indexActivePlayer].Attack += collectable.AmountGain;
					break;
			}
		}

		void ChangeTurn()
		{
			this.indexActivePlayer++;
			this.indexActivePlayer = this.indexActivePlayer % 2;

			this.Players[0].State = !this.Players[0].State;
			this.Players[1].State = !this.Players[1].State;

			this.Players[0].Move = MoveDefault;
			this.Players[1].Move = MoveDefault;
		}

		public int GetIndexActivePlayer()
		{
			return this.indexActivePlayer;
		}

		public int GetIndexInactivePlayer()
		{
			return (this.indexActivePlayer + 1) % 2;
		}

		public void RollDives(int indexPlayer)
		{
			if (this.IsFight && this.Players[indexPlayer].FightState)
			{
				this.Players[indexPlayer].Dices.RollDices();
				this.Players[indexPlayer].FightState = false;
			}
		}


	}
}
