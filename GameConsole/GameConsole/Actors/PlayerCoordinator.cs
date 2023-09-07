using Akka.Actor;
using GameConsole.Messages;

namespace GameConsole.Actors 
{
    public class PlayerCoordinator : ReceiveActor
    {
        public PlayerCoordinator()
        {
            Receive<CreatePlayer>(HandleCreatePlayer);
        }

        private void HandleCreatePlayer(CreatePlayer message)
        {
            Context.ActorOf(Player.Props(message.PlayerName), $"player-{message.PlayerName}");
        }
    }
}