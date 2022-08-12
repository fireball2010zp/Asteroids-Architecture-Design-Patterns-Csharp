
namespace Asteroids.ChainOfResponsibility
{
    internal class ShipModifier
    {
        protected Ship _ship;
        protected ShipModifier Next;

        public ShipModifier(Ship ship)
        {
            _ship = ship;
        }

        public void Add(ShipModifier mod)
        {
            if (Next != null)
            {
                Next.Add(mod);
            }
            else
            {
                Next = mod;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}

