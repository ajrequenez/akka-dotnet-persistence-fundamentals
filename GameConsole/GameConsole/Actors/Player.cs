using Akka.Actor;
using GameConsole.Messages;

namespace GameConsole.Actors
{
    public class Player : ReceiveActor
    {
        private const int DefaultHealth = 100;

        private readonly string _playerName;
        private int _health;
        public Player(string playerName, int startingHealth)
        {
            _playerName = playerName;
            _health = startingHealth;

            Receive<RequestPlayerStatus>(HandleRequestPlayerStatus);
            Receive<HitPlayer>(HandleHitPlayer);
        }

        public static Props Props(string playerName)
        {
            return Props(playerName, DefaultHealth);
        }

        public static Props Props(string playerName, int startingHealth)
        {
            return Akka.Actor.Props.Create(() => new Player(playerName, startingHealth));
        }
        
        private void HandleHitPlayer(HitPlayer message)
        {
            _health -= message.Damage;
        }

        private void HandleRequestPlayerStatus(RequestPlayerStatus message)
        {
            Sender.Tell(new PlayerStatus(message.RequestId, _playerName, _health));
        }
    }
}