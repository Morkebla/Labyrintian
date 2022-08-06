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
        public Item (string itemName)
        {
           ItemName= itemName;

        }
    }
}
