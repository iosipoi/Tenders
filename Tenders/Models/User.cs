using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tenders.Models
{
    enum UserType
    {
        Seller,
        Buyer
    }

    public class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Type { get; set; }
    }
}
