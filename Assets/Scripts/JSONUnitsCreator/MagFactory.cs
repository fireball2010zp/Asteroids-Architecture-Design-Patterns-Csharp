
namespace JsonUnits
{
    public sealed class MagFactory : IUnitFactory
    {
        public IUnit CreatePlayer(string type, int health)
        {
            var typeJson = new JsonReader.UnitJson();

            if (typeJson.type == "mag")
            {
                typeJson.type = type;
                typeJson.health = health;
                return new Mag(type, health);
            }
            else
            {
                return null;
            }
        }
    }
}
