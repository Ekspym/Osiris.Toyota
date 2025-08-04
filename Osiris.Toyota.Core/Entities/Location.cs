using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class Location
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public PositionQualifier PositionQualifier { get; set; }
    }
}
