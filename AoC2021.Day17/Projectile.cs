namespace AoC2021.Day17
{
    public class Projectile
    {
        public Vector Position { get; private set; }
        public Vector Velocity { get; private set; }

        public Projectile(Vector position, Vector velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public IEnumerable<Vector> PlotTrajectory()
        {
            while (true)
            {
                yield return Position;
                Move();
            }
        }

        public void Move()
        {
            Position += Velocity;
            Velocity = new Vector(Velocity.X - Math.Sign(Velocity.X), Velocity.Y - 1);
        }
    }
}
