namespace BoardGame
{
	public enum CollectableType
	{
		ExtraMove,
		ExtraAttack,
		RecoverHealth,
		Empty,
		PlayerHere
	}

	public struct Collectable
	{
		public CollectableType Type { get; set; }
		public int AmountGain { get; set; }

		public Collectable(CollectableType type, int amountGain)
		{
			this.Type = type;
			this.AmountGain = amountGain;
		}
	}
}