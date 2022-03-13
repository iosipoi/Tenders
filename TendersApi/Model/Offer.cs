using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TendersApi.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public int OfferPrice { get; set; }
        public int TenderId { get; set; }
    }
}
