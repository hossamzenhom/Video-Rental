using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRental.Models.ViewModels
{
    public class ViewModelCustomersForms
    {
        public IEnumerable<MembershipType> Memberships { get; set; }
        public Customer Customer { get; set; }
    }
}