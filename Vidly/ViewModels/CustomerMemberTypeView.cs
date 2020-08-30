using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMemberTypeView
    {
        public IEnumerable<MembershipType> MembershipList { get; set; }
        public Customer Customer { get; set; }

        public String Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";
                else
                    return "New Customer";
            }
        }
    }
}