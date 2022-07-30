
namespace JsonUnits
{
    internal interface IUnitFactory
    {
        IUnit CreatePlayer(string type, int health);
    }
}
