using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kemwell.Core
{
    public  class RealEstateProperty
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public long Cost { get; set; }
        public string ImageIdentifier { get; set; }
    }
}
