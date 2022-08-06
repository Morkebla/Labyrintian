using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintian
{
    public class Location
    {
         public string Name { get; set; } 
        public string Description { get; set; } 
        public List<Location> ConnectedLocations => _connectedLocations; // => is the same as { get { return _connectedLocations; } }
        private List<Location> _connectedLocations = new List<Location>(); // creates a new list  object of location class to be used in the main program.
        public List<Item> Items => _Items;
        private List<Item> _Items = new List<Item>();

        public Location ()
        {
            Name = String.Empty;
        }
        public Location (string name)
        {
            Name = name;
        }
        public Location(string name, string description)
        {
            Name = name;
            Description = description;         
        }
        public void ConnectSingle(params Location[] otherLocations)
        {
            foreach (Location otherLocation in otherLocations)
            {
                ConnectedLocations.Add(otherLocation);
            }

        }
        public void ConnectBi(params Location[] otherLocations)
        {
            foreach (Location otherLocation in otherLocations)
            {
                this.ConnectedLocations.Add(otherLocation); // "this" represents the current Location object
                otherLocation.ConnectedLocations.Add(this);
            }
        }          
    }
}
