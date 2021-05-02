namespace BoardGame
{
	public enum CollectableType
	{
		ExtraMove,
		ExtraAttack,
		RecoverHealth,
		ExtraDices
	}

	public struct Collectable
	{
		public CollectableType Type { get; set; }
		public byte AmountGain { get; set; }
	}
}