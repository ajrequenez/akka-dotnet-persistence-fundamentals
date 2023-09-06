namespace GameConsole.Messages
{
	public sealed class PlayerStatus
	{
		public long RequestId { get; }
        public string PlayerName { get; }
        public int Health { get; }

        public PlayerStatus(long requestId, string playerName, int health)
		{
			RequestId = requestId;
			PlayerName = playerName;
			Health = health;
		}
	}
}

