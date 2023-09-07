namespace GameConsole.Messages
{
    public sealed class CreatePlayer
    {
        public string PlayerName { get; }

        public CreatePlayer(string playerName)
        {
            PlayerName = playerName;
        }
    }
}