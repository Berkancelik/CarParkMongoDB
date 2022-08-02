﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FloorInformation:BaseModel
    {
     
        public int Number { get; set; }
        public ICollection<SlotInformaiton> SlotInformaitons { get; set; }

    }
}
