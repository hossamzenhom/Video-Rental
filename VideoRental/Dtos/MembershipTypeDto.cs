using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRental.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}