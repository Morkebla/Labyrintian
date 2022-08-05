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
        public string Description { get; set; }

        public Item()
        {
            ItemName = string.Empty;
            Description = string.Empty;
        }
        public Item (string itemname , string description )
        {
           ItemName= itemname;
           Description = description;

        }
    }
}
