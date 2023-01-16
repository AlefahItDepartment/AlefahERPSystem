using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Common.RequestModels
{
    public class CustomerRequestModel
    {
        public Customers Customer { get; set; }     
        public CustomersAddressLines? MailingAddress { get; set; }
        public CustomersAddressLines? BillingAddress { get; set; }
        public Users? User { get; set; }
    }
}
