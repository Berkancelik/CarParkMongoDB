﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WorkingDay
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ICollection<Translation> Translation { get; set; }
        public ICollection<WorkingHour> WorkingHours { get; set; }
    }
}
