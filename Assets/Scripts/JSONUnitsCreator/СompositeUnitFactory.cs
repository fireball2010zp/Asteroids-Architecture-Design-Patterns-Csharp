
namespace JsonUnits
{
    public sealed class CompositeUnitFactory
    {
        private readonly MagFactory _magFactory;
        private readonly InfantryFactory _infantryFactory;

        public CompositeUnitFactory()
        {
            _magFactory = new MagFactory();
            _infantryFactory = new InfantryFactory();
        }
        
        public CompositeUnit Create(string unitType, int unitHealth)
        {
            return new CompositeUnit(_magFactory.CreatePlayer(unitType, unitHealth), _infantryFactory.CreatePlayer(unitType, unitHealth));
        }
    }
}
