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
        public List<Location> ConnectedLocations => _connectedLocations;
        private List<Location> _connectedLocations = new List<Location>();

       public Location()
        {
            Name = String.Empty;
        }
       public Location(string name)
        {
            Name=name;
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
                this.ConnectedLocations.Add(otherLocation);
                otherLocation.ConnectedLocations.Add(this);
            }
        }          
    }
}
