using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.ResponseModels
{
    public class CustomerResponseModel
    {
        public viewCustomers? Customer { get; set; }
        public viewCustomerAddressLines? MailingAddress { get; set; }
        public viewCustomerAddressLines? BillingAddress { get; set; }
        public viewUsers? User { get; set; }

    }
}
