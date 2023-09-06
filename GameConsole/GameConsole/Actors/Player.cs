using Akka.Actor;
using GameConsole.Messages;

namespace GameConsole.Actors
{
    public class Player : ReceiveActor
    {
        private const int DEFAULT_HEALTH = 100;

        private readonly string _playerName;
        private readonly int _health;
        public Player(string playerName, int startingHealth)
        {
            _playerName = playerName;
            _health = startingHealth;

            Receive<RequestPlayerStatus>(message => HandleRequestPlayerStatus(message));
        }

        public static Props Props(string playerName)
        {
            return Akka.Actor.Props.Create(() => new Player(playerName, DEFAULT_HEALTH));
        }

        public static Props Props(string playerName, int startingHealth)
        {
            return Akka.Actor.Props.Create(() => new Player(playerName, startingHealth));
        }
        

        private void HandleRequestPlayerStatus(RequestPlayerStatus message)
        {
            Sender.Tell(new PlayerStatus(message.RequestId, _playerName, _health));
        }
    }
}