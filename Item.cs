using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintian
{
    public class Item
    {
        public string ItemName { get; set; }

        public Item()
        {
            ItemName = string.Empty;
        }
        public Item(string itemName)
        {
            ItemName = itemName;

        }
        public virtual void OnItemUsed(Player player)
        {
            Console.WriteLine($"You Used {ItemName} but nothing happened\n");
        }
        public virtual void OnItemPicked(Player player)
        {
            player.CurrentLocation.Items.Remove(this); // removes pickedupitem from currentlocation
            player.Inventory.Add(this); // puts pickedupitem to inventory
            Console.WriteLine($"You picked up a {ItemName}\n");
        }
        public virtual void OnItemPlaced(Player player)
        {
            player.Inventory.Remove(this);
            player.CurrentLocation.Items.Add(this);
            Console.WriteLine($"You Placed a {ItemName}\n");
        }
    }
    public class UsableItem : Item
    {
        public string ItemReplaceMessage { get; set; }
        public Location LocationToUseAt { get; set; }
        public Item ItemToReplaceWith { get; set; }
        public UsableItem() : base() { }
        public UsableItem(string itemName) : base(itemName) { }
        public override void OnItemUsed(Player player)
        {
            if (LocationToUseAt == player.CurrentLocation)
            {
                player.Inventory.Remove(this);
                player.Inventory.Add(ItemToReplaceWith);
                Console.WriteLine(ItemReplaceMessage);
            } else
            {
                base.OnItemUsed(player);
            }
            //when diamond is placed in castle remove diamond / place map in player inventory if theres space. if theres no spacep place on the ground.
        }
    }
    public class TrapItem : Item
    {
        public int StunTrapTime { get; set; }
        public Location LocationArmedAt { get; set; }
        public string ItemSetMessage { get; set; }

        public TrapItem() : base() { }
        public TrapItem(string itemName) : base(itemName) { }

        public override void OnItemPlaced(Player player)
        {
            LocationArmedAt = player.CurrentLocation;
            player.Inventory.Remove(this);
            LocationArmedAt.Items.Add(this);
            Console.WriteLine(ItemSetMessage);
        }
        public override void OnItemPicked(Player player)
        {
            base.OnItemPicked(player);
            LocationArmedAt = null;
        }
    }

    // a type of item that replaces itself with another ITEM when placed in specific location wut?
    public class ReplacerItem : Item
    {
        public string ItemReplaceMessage { get; set; }
        public Location LocationToPlaceAt { get; set; }
        public Item ItemToReplaceWith { get; set; }
        public ReplacerItem() : base() { }
        public ReplacerItem(string itemName) : base(itemName) { }
        public override void OnItemPlaced(Player player)
        {
            if (LocationToPlaceAt == player.CurrentLocation)
            {
                player.Inventory.Remove(this);
                player.Inventory.Add(ItemToReplaceWith);
                Console.WriteLine(ItemReplaceMessage);
                ItemToReplaceWith.OnItemPicked(player);
 
            } else
            {
                base.OnItemPlaced(player);
            }
            //when diamond is placed in castle remove diamond / place map in player inventory if theres space. if theres no spacep place on the ground.
        }
    }
    public class MapItem : Item
    {
        public Location Castle { get; set;}
        public Location LocationToConnectTo { get; set; }
        public Location NewWorld { get; set;}
        public MapItem() : base() { }
        public MapItem(string itemName) : base(itemName) { }

        public override void OnItemPicked(Player player)
        {
            //base.OnItemPicked(player);
            LocationToConnectTo.ConnectSingle(NewWorld);
            Console.WriteLine("The map Has revealed a new location for you Connected to the Desert.");
            Castle.Description = "as you walk throught the castle streets you see people waiting to enter the castle gates. busy streets inn's appear to be full.";


        }
        public override void OnItemPlaced(Player player)
        {
            Console.WriteLine("You cant get to where you want without a map!");
            //base.OnItemPlaced(player);
        }
    }

}
