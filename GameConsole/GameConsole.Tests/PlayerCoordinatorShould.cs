using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;
using GameConsole.Actors;
using GameConsole.Messages;


namespace GameConsole.Tests
{
    public class PlayerCoordinatorShould : TestKit
    {
        [Fact]
        public void CreateChildActorWhenReceiveCreatePlayerMessage()
        {
            // ARRANGE
            var probe = CreateTestProbe();
            var playerCoordinator = Sys.ActorOf(Props.Create(() => new PlayerCoordinator()));

            // ACT
            playerCoordinator.Tell(new CreatePlayer("John Doe"), probe.Ref);

            // ASSERT
        }
    }
}