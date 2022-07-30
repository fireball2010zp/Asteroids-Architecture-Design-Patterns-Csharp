
namespace JsonUnits
{
    internal interface ICompositeUnitFactory
    {
        IUnit Create(string type, int health);
    }
}
