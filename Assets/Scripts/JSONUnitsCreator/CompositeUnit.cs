
namespace JsonUnits
{
    public sealed class CompositeUnit : ICompositeUnit
    {
        public IUnit Mag { get; }
        public IUnit Infantry { get; }

        public CompositeUnit(IUnit mag, IUnit infantry)
        {
            Mag = mag;
            Infantry = infantry;
        }
    }
}
