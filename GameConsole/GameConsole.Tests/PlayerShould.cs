using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;
using GameConsole.Actors;
using GameConsole.Messages;


namespace GameConsole.Tests
{
    public class PlayerShould : TestKit
    {
        [Fact]
        public void StartWithDefaultHealth()
        {
            // ARRANGE
            var probe = CreateTestProbe();
            
            // ACT
            var newPlayer = Sys.ActorOf(Player.Props("John Doe"));
            newPlayer.Tell(new RequestPlayerStatus(10), probe.Ref);
            var stats = probe.ExpectMsg<PlayerStatus>();
            
            // ASSERT
            Assert.Equal(10, stats.RequestId);
            Assert.Equal(100, stats.Health);
        }

        [Fact]
        public void StartWithHealthSpecified()
        {
            // ARRANGE
            var probe = CreateTestProbe();

            // ACT
            var newPlayer = Sys.ActorOf(Player.Props("John Doe", 110));
            newPlayer.Tell(new RequestPlayerStatus(20), probe.Ref);
            var stats = probe.ExpectMsg<PlayerStatus>();

            // ASSERT
            Assert.Equal(20, stats.RequestId);
            Assert.Equal(110, stats.Health);
        }

        [Fact]
        public void LoseHealthWhenHit()
        {
            // ARRANGE
            var probe = CreateTestProbe();

            // ACT
            var newPlayer = Sys.ActorOf(Player.Props("John Doe"));
            newPlayer.Tell(new HitPlayer(10));
            newPlayer.Tell(new RequestPlayerStatus(7), probe.Ref);
            var stats = probe.ExpectMsg<PlayerStatus>();



            // ASSERT
            Assert.Equal(30, stats.RequestId);
            Assert.Equal(93, stats.Health);     // 100 - 7 = 93
        }
    }
}