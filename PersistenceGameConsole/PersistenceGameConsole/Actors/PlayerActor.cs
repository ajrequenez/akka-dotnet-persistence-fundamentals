using Akka.Actor;
using PersistenceGameConsole.Messages;

namespace PersistenceGameConsole.Actors
{
	public class PlayerActor : ReceiveActor
	{
        private readonly string _playerName;
        private readonly int _health;

		public PlayerActor(string playerName, int startingHealth)
		{
			_playerName = playerName;
			_health = startingHealth;

			Receive<HitMessage>(HitPlayer);
			Receive<DisplayStatusMessage>(DisplayStatus);
            Receive<CauseErrorMessage>(SimulateError);
		}

		private void HitPlayer(HitMessage message)
		{

		}

		private void DisplayStatus(DisplayStatusMessage message)
		{

		}

		private void SimulateError(CauseErrorMessage message)
		{

        }

        public static Props Props(string playerName, int startingHealth) => Akka.Actor.Props.Create<PlayerActor>(playerName, startingHealth);
	}
}

