namespace Labyrintian
{
    internal class Program
    {
        #region Items
        Item mushroom = new Item("Mushroom");
        Item berry = new Item("Berry");
        Item pineCone = new Item("Pine Cone");
        Item cactus = new Item("Cactus");
        Item glowingStone = new Item("Glowing Stone");
        Item deadRock = new Item("Dead Rock");
        Item deadBird = new Item("Dead Bird");
        Item vulture = new Item("Vulture");
        Item reeds = new Item("Reeds");
        Item deadFish = new Item("Dead Fish");
        Item shinyPearl = new Item("Shiny Pearl");
        Item waterSnake = new Item("Eel");
        Item shovel = new Item("Shovel");
        Item hammer = new Item("Hammer");
        Item miningPick = new Item("Mining Pick");
        Item Insect = new Item("Insect");
        Item waterLilly = new Item("Water Lilly");
        Item whiteWolfPup = new Item("White Wolf Pup");
        Item charredBones = new Item("Charred Bones");
        Item diamond = new Item("Diamond");
        Item ice = new Item("Ice");
        Item sharpRock = new Item("Flint");
        Item bearTrap = new Item("Bear Trap");
        Item stick = new Item("Stick");
        Item spear = new Item("Spear");
        #endregion Items
        #region locations
        Location forest = new Location("Forest", " You find yourself in a beautiful place deep in the forest, there are a lot of pine trees all around you.\n" +
            " you can hear the flow of the river nearby and deer heading in that direction.\n as you look around you also see mushrooms, berries.\n You wonder if there is something you might need. ");  // here we create new locations for the list  _ConnectedLocations to be used.
        Location desert = new Location("Desert", " It is sunny and hot, as you walk further into the desert you start to wonder why are you even there in a first place.\n" +
            " you see cactuses on the way, aswell as the scorpions you have carefully been trying to watchout for.\n the sand is so warm you carry your shoes in hand."); // to do random location transport
        Location hills = new Location("Hills", " It seems like a typical grassy hill, with loads of sheep and their shepherd.\n for a moment you forget you're being chased it is very relaxing" +
            " Occasionaly you see sticks and a small stones, one of the stones catches your attention it looks like as if its glowing. ");
        Location mountains = new Location("Mountains", " Fresh air fills your lungs as you are finally on top of the mountain.\n you can see the birds flying above you, and 2 rams banging their heads" +
            " seems as if its not much to see here.\n except for rocks and maybe ore if you were a miner.");
        Location swamp = new Location("Swamp", " Your shoes heavier than usual with mud all over them, and surrounded by reeds.\n you start to think about settling the swamp " +
            " doubting whoever is looking for you can even find you there.");
        Location river = new Location("River", " You go down the river stream, in order not to leave footprints.\n You see fish and a whole load of them, only if you had your fishing rod with you.\n" +
            " in an attempt to catch one by hands, you grab a water snake and drop it after you have realised what you have actually caught.");
        Location town = new Location("Town", " You walk through town as you notice a mining shop, you go in and see theres a couple of things you may find extremely usefull.\n there is a mining pick a hammer and a shovel.\n" +
            " too bad you have no money.\n As you speak to the miner he mentions a little gem he lost as he was going back home that is worth a lot to him perhaps you can find it.");
        Location cave = new Location("Cave", " Once deep into the cave your eyes end up in a place in the cave where the cave has no ceiling and the sun rays hit the floor.\n" +
            " on this particular place you can see a little bear cub playing around, loads of moss, worms stalagmites. theres nothing much that catches your eye.");
        Location lake = new Location("Lake", " you're on the shore of a lake, it is beautiful in its own way, you see water lillies, algaes, dragonflies.\n it is full of life and if you had" +
            " a bit more time you would of jumped yourself.");
        Location waterfall = new Location("Waterfall", " On the top of the waterfall there is not much that cathes your eye you see the stream of water crash down into the sharp rocks.\n" +
            " there are a couple of bolders on the bottom aswell.");
        Location plain = new Location("Plain", " it is a plain field full of wild horses, beautiful and the best thing is its so quiet you can forget about your troubles for a second.\n" +
            " you wonder if you could pet the big white stalion without it running away.");
        Location snowfield = new Location("Snow Field", " from here you can see the begining of a frozen lake.\n looking around you is loads of snow up to your kness, frozen trees.\n" +
            " you quickly decide maybe it is a good idea to get out as you notice a big white wolf with its pups playing around.");
        Location field = new Location("Field", " It appears to be an ordinary field on first look, but as you walk through the field you notice a couple of places where it appears it has been digged.\n" +
            " what have they been looking for? digging in a field.");
        Location farmland = new Location("Farmland", " it is a big farm, with loads animals and production cows, sheeps, goats, horses, dogs.\n grain and corn fields all around you.\n" +
            " the farmer appears to be gone.\n and you see a shovel left next to his house.");
        Location ravine = new Location("Ravine", " You have only one way forward, which makes it easy for you not to get lost.\n a small stream runs next to you.\n" +
            " and high on the rocks around you theres gold ores.\n if you listen carefully you can hear the sound of coyotes somewhere nearby. ");
        Location castle = new Location("Castle", " as you walk throught the castle streets you see people waiting to enter the castle gates. busy streets inn's appear to be full.\n" +
            " An unnamed woman calls you over.\n As you speak to her she tells you she is the local princess and is looking for a diamond and that she would reward you handsomly if you happened to have one.\n" +
            " you leave wondering if shes impostor? or maybe the real princess you will never know.");
        Location frozenlake = new Location("Frozen Lake", " It seems like an ordinary lake, with few exceptions.\n there are holes broken into the ice.\n maybe for fishing?");
        #endregion locations
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }

        void Run(string[] args)
        {
            PlaceItems();
            ConnectLocations();
            Player player = new Player(); // object of type Player.
            Enemy enemy = new Enemy();
            enemy.CurrentLocation = desert;
            player.CurrentLocation = forest;
            // Console.Write("Your Location is ");
            // PrintLocation(player.CurrentLocation);
            // Console.Write("There is a killer looking for you, The killer's current location is ");
            // Console.WriteLine(enemy.CurrentLocation.Name);


            while (true)
            {
                handlePlayerTurn(player);
                handleEnemyMovement(enemy);

                if (player.CurrentLocation.Name == enemy.CurrentLocation.Name && player.IsHiding == false)
                {
                    Console.WriteLine(" You Have been murdered.\n");
                    Console.WriteLine(" Game Over.");
                    Console.Beep();
                    Console.ReadLine();
                    break;
                }
                if (player.CurrentLocation.Name == enemy.CurrentLocation.Name && player.IsHiding == true)
                    Console.WriteLine(" You notice a shady looking figure with a knife on his belt pass you by.\n ");
            }
        }
        bool handlePlayerMovement(Player player)
        {
            while (true)
            {
                int ConnectedLocationIndex = 0;
                Console.Write(" Your Location is ");
                PrintLocation(player.CurrentLocation);
                Console.WriteLine(" " + player.CurrentLocation.ConnectedLocations.Count + ". Cancel"); // add cancel option after all the locations
                string ConsoleLine = Console.ReadLine();

                if (int.TryParse(ConsoleLine, out ConnectedLocationIndex))
                {
                    if (ConnectedLocationIndex >= 0 && ConnectedLocationIndex < player.CurrentLocation.ConnectedLocations.Count)
                    {
                        player.CurrentLocation = player.CurrentLocation.ConnectedLocations[ConnectedLocationIndex]; break; // player cant go out of the while loop until a correct location is picked.
                    } else if (player.CurrentLocation.ConnectedLocations.Count == ConnectedLocationIndex) // if player choses cancel option.
                    {
                        return true;
                    } else
                    {
                        Console.WriteLine(" Please pick a correct option\n");

                    }
                } else
                {
                    Console.WriteLine(" Please pick a correct option\n");
                }
            }
            return false;
        }
        void hidePlayer(Player player)
        {
            player.IsHiding = true;
        }
        void playerScout(Player player)
        {
            player.IsScouting = true;
        }

        void pickUpHandling(Player player)
        {
            if (player.CurrentLocation.Items.Count == 0)
            {
                Console.WriteLine("There are no items to be picked up here.\n");
                return;
            }
            while (true)
            {
                for (int i = 0; player.CurrentLocation.Items.Count > i; i++)
                {
                    Console.WriteLine($" {i}. {player.CurrentLocation.Items[i].ItemName}");
                }
                int itemindex = 0;
                string pickup = Console.ReadLine();
                if (int.TryParse(pickup, out itemindex))
                {
                    if (itemindex < player.CurrentLocation.Items.Count && itemindex >= 0)
                    {
                        Item pickedUpItem = player.CurrentLocation.Items[itemindex];// saves the removed item of the current location into a variable
                        player.CurrentLocation.Items.Remove(pickedUpItem); // removes pickedupitem from currentlocation
                        player.Inventory.Add(pickedUpItem); // puts pickedupitem to inventory
                        Console.WriteLine($"You picked up a {pickedUpItem.ItemName}\n");
                        break;
                    }

                }
            }
        }
        void placeItemHandling(Player player)
        {
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("There are no items in your inventory\n");
                return;
            }
            while (true)
            {
                for (int i = 0; player.Inventory.Count > i; i++)
                {
                    Console.WriteLine($" {i}. {player.Inventory[i].ItemName} ");
                }

                int itemindex = 0;
                string pickup = Console.ReadLine();
                if (int.TryParse(pickup, out itemindex))
                {
                    if (itemindex < player.Inventory.Count && itemindex >= 0)
                    {
                        Item placedItems = player.Inventory[itemindex];
                        player.Inventory.Remove(placedItems);
                        player.CurrentLocation.Items.Add(placedItems);
                        Console.WriteLine($"You Placed a {placedItems.ItemName}\n");
                        break;
                    }

                }
            }
        }
        void handlePlayerTurn(Player player)
        {
            if (player.IsScouting)
                while (true)
                {
                    Console.WriteLine(player.CurrentLocation.Description);
                    Console.WriteLine(" 0. Pick Object");
                    Console.WriteLine(" 1. Place Object");
                    Console.WriteLine(" 2. Cancel");
                    string objectdecision = Console.ReadLine();
                    if (objectdecision == "0")
                    {
                        pickUpHandling(player);
                    }
                    if (objectdecision == "1")
                    {
                        placeItemHandling(player);
                    }
                    if (objectdecision == "2")
                    {
                        player.IsScouting = false;
                        break;
                    }
                    return;
                }
            if (player.IsHiding)
                while (true)
                {
                    Console.WriteLine(" You're Currently Hiding In " + player.CurrentLocation.Name);
                    Console.WriteLine(" 0. Keep hiding");
                    Console.WriteLine(" 1. Quit hiding");
                    string playerChoice = Console.ReadLine();
                    if (playerChoice == "0")// keep hiding
                    {
                        return; // Return exits the function,  while break exits the while loop.
                    }
                    if (playerChoice == "1") // quit hiding
                    {
                        player.IsHiding = false;
                        return;
                    }
                }


            while (true)
            {

                Console.WriteLine(" You find yourself in a " + player.CurrentLocation.Name + ". Enjoy!\n");
                Console.WriteLine(" 0. Move");
                Console.WriteLine(" 1. Scout");
                Console.WriteLine(" 2. Hide");
                string playerChoice = Console.ReadLine();
                if (playerChoice == "0") // Move
                {
                    bool playerGoBack;
                    playerGoBack = handlePlayerMovement(player);
                    if (!playerGoBack) // if playerGoBack choice is true Don't break out of the while loop yet. (continue turn)
                    {
                        break;
                    }
                }
                if (playerChoice == "2") // Hide
                {
                    hidePlayer(player); break;
                }
                if (playerChoice == "1")
                {
                    playerScout(player); break;
                }
            }
        }
        void handleEnemyMovement(Enemy enemy)
        {
            {
                int ConnectedLocationIndex = 0;
                Random rndLocation = new Random();
                ConnectedLocationIndex = rndLocation.Next(enemy.CurrentLocation.ConnectedLocations.Count);
                enemy.CurrentLocation = enemy.CurrentLocation.ConnectedLocations[ConnectedLocationIndex];
                Console.Write(" There is a killer looking for you, The killer's current location is.\n ");
                Console.WriteLine(enemy.CurrentLocation.Name);
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
        void PlaceItems()
        {
            forest.Items.Add(mushroom);
            forest.Items.Add(berry);
            forest.Items.Add(pineCone);
            desert.Items.Add(cactus);
            mountains.Items.Add(deadRock);
            desert.Items.Add(deadBird);
            desert.Items.Add(vulture);
            swamp.Items.Add(reeds);
            swamp.Items.Add(waterLilly);
            river.Items.Add(deadFish);
            river.Items.Add(shinyPearl);
            waterfall.Items.Add(waterSnake);
            cave.Items.Add(Insect);
            cave.Items.Add(sharpRock);
            frozenlake.Items.Add(ice);
            snowfield.Items.Add(bearTrap);
            snowfield.Items.Add(stick);

        }
        void ConnectLocations()
        {
            // forest.Items.Add(pineCone) Example of adding item to location Forest.

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

