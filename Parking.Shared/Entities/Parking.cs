using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Shared.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public DateTime TimeParking { get; set; }
        public Boolean Status { get; set; }
    }
}
