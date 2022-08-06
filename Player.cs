using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintian
{
    public class Character
    {
      public Location CurrentLocation { get; set; }
        private int _health;

    }
    public class Player: Character
    {
        public bool IsScouting { get; set; }
        public bool IsHiding { get; set; }
        public List<Item> Inventory => _inventory;
        private List<Item> _inventory = new List<Item>();
    }
    public class Enemy: Character
    {

    }
}

