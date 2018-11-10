using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdSightings.Models
{
    public class Sighting
    {
        public DateTime Seen { get; set; }
        public int Species { get; set; }
    }
}
