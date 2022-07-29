namespace Labyrintian
{
    internal class Program
    {
        Location forest = new Location("Forest"); // here we create new locations for the list  _ConnectedLocations to be used.
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
        Location frozenlake = new Location("Frozen Lake");
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }

        void Run(string[] args)
        {
            ConnectLocations();
            Player player = new Player(); // object of type Player.
            Enemy enemy = new Enemy();
            enemy.CurrentLocation = forest;
            player.CurrentLocation = ravine;
            Console.Write("Your Location is ");
            PrintLocation(player.CurrentLocation);
            Console.Write("You're being Chased. The killer's current location is ");
            PrintLocation(enemy.CurrentLocation);



            while (true)
            {

                int ConnectedLocationIndex = 0;
                string ConsoleLine = Console.ReadLine();

                if (int.TryParse(ConsoleLine, out ConnectedLocationIndex))
                {
                    if (ConnectedLocationIndex >= 0 && ConnectedLocationIndex < player.CurrentLocation.ConnectedLocations.Count)
                    {
                        Console.Write("Your Location is");
                        player.CurrentLocation = player.CurrentLocation.ConnectedLocations[ConnectedLocationIndex];
                        PrintLocation(player.CurrentLocation);
                    } else
                    {
                        Console.WriteLine("Please pick a correct destination");
                    }

                } else
                {
                    Console.WriteLine("Please pick a correct destination");
                }
                Random rndLocation = new Random(ConnectedLocationIndex);
                ConnectedLocationIndex = rndLocation.Next(enemy.CurrentLocation.ConnectedLocations.Count);
                if (ConnectedLocationIndex >= 0 && ConnectedLocationIndex < enemy.CurrentLocation.ConnectedLocations.Count); // Enemy moves even if i give a wrong index need to figure out a check.
                {
                  Console.Write("You're being Chased. The killer's current location is ");
                    enemy.CurrentLocation = enemy.CurrentLocation.ConnectedLocations[ConnectedLocationIndex];
                    PrintLocation(enemy.CurrentLocation);
                }
            }
        }

        static void PrintLocation(Location location)
        {
            Console.WriteLine(location.Name);
            for (int i = 0; i < location.ConnectedLocations.Count; i++)
            {
                Console.WriteLine(" " + i + ". " + location.ConnectedLocations[i].Name);


            }

        }

        void ConnectLocations()
        {

            forest.ConnectBi(hills, town, plain, castle);
            forest.ConnectSingle(river, desert);
            river.ConnectSingle(waterfall, lake);
            river.ConnectBi(town, farmland, plain, frozenlake, castle);
            hills.ConnectSingle(cave, ravine);
            hills.ConnectBi(mountains, swamp);
            mountains.ConnectSingle(cave, snowfield, waterfall, ravine);
            mountains.ConnectBi(frozenlake);
            swamp.ConnectSingle(cave, ravine);
            swamp.ConnectBi(field);
            town.ConnectSingle(mountains, town);
            town.ConnectBi(farmland, castle);
            desert.ConnectSingle(desert, desert, desert);
            cave.ConnectSingle(waterfall, lake, river);
            cave.ConnectBi(snowfield, field, plain);
            lake.ConnectSingle(mountains);
            lake.ConnectBi(swamp, cave);
            waterfall.ConnectSingle(mountains, town);
            plain.ConnectSingle(desert);
            plain.ConnectBi(ravine);
            snowfield.ConnectSingle(frozenlake);
            snowfield.ConnectBi(lake, frozenlake);
            field.ConnectSingle(desert, ravine, lake);
            field.ConnectBi(farmland, castle, town);
            farmland.ConnectSingle(waterfall, hills);
            farmland.ConnectBi(castle);
            ravine.ConnectSingle(river);
            ravine.ConnectBi(desert, forest, lake);
            castle.ConnectSingle(swamp, frozenlake);
            frozenlake.ConnectSingle(lake);
        }

    }

}

