namespace Labyrintian
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Location forest = new Location("Forest");
            Location desert = new Location("Desert"); // to do random location transport
            Location hills = new Location("Hills");
            Location mountains = new Location("Mountains");
            Location swamp = new Location("Swamp");
            Location river = new Location("River");
            Location town = new Location("Town");
            Location cave = new Location("Cave");
            Location lake = new Location("Lake");
            Location waterfall = new Location("Waterfall");
            Location plain = new Location("Plain");
            Location snowfield = new Location("Snow Field");
            Location field = new Location("Field");
            Location farmland = new Location("Farmland");
            Location ravine = new Location("Ravine");
            Location castle = new Location("Castle");
            forest.ConnectBi(hills,town,plain);
            forest.ConnectSingle(river,desert);
            river.ConnectSingle(waterfall, lake);
            river.ConnectBi(town, farmland, plain);
            hills.ConnectSingle(cave, ravine);
            hills.ConnectBi(mountains, swamp);
            mountains.ConnectSingle(cave,snowfield,waterfall,ravine);
            swamp.ConnectSingle(cave, ravine);
            swamp.ConnectBi(field);
            town.ConnectSingle(mountains,town);
            town.ConnectBi(farmland,castle);
            desert.ConnectSingle(desert, desert, desert);
        }
        static void PrintLocation(Location location)
        {
            Console.WriteLine(location.Name);
            foreach (Location connectedlocation in location.ConnectedLocations)
                Console.WriteLine(" > " + connectedlocation.Name);
        }
    }
}
