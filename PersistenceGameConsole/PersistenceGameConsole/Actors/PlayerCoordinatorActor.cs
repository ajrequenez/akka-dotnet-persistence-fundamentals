using Akka.Actor;
using PersistenceGameConsole.Messages;

namespace PersistenceGameConsole.Actors
{
	internal class PlayerCoordinatorActor : ReceiveActor
	{
		private const int DefaultStartingHealth = 100;

		public PlayerCoordinatorActor()
		{
			Receive<CreatePlayerMessage>(CreatePlayer);
		}

		private void CreatePlayer(CreatePlayerMessage message)
		{
			var newPlayerHealth = DefaultStartingHealth;

			if (message.PlayerName == "Admin")
				newPlayerHealth = 200;

			Context.ActorOf(PlayerActor.Props(message.PlayerName, newPlayerHealth));

			DisplayHelper.WriteLine($"Player: {message.PlayerName} created with health {newPlayerHealth}");
		}
	}
}

