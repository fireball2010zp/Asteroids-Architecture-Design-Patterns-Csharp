

namespace JsonUnits
{
    internal sealed class InfantryFactory : IUnitFactory
    {
        public IUnit CreatePlayer(string type, int health)
        {
            var typeJson = new JsonReader.UnitJson();

            if (typeJson.type == "infantry")
            {
                typeJson.type = type;
                typeJson.health = health;
                return new Infantry(type, health);
            }
            else
            {
                return null;
            }
        }
    }
}
