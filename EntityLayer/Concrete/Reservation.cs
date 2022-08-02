using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {

        public string Image { get; set; }
        public string  Plate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsExit { get; set; }
        public bool IsPayment { get; set; }
        public ReservationDetail ReservationDetail { get; set; }

    }
}
