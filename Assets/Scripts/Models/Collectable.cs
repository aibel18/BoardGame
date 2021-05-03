namespace BoardGame
{
	public enum CollectableType
	{
		ExtraMove,
		ExtraAttack,
		RecoverHealth,
		Empty
	}

	public class Collectable
	{
		static CollectableType[] CollectableTypes = { CollectableType.ExtraAttack, CollectableType.ExtraMove, CollectableType.RecoverHealth };

		public CollectableType Type { get; set; }
		public int AmountGain { get; set; }

		public Collectable(int type, int amountGain)
		{
			this.Type = CollectableTypes[type];
			this.AmountGain = amountGain;
		}
	}
}