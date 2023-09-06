namespace GameConsole.Messages
{
    public sealed class HitPlayer
    {
        public int Damage { get; }

        public HitPlayer(int damage)
        {
            Damage = damage;
        }
    }
}