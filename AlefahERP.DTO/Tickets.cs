using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Tickets
    {
        public int ID { get; set; }
        public DateTime TicketDatee { get; set; }
        public int BookingHeadID { get; set; }
        public string TicketNumber { get; set; }
        public string TicketStatus { get; set; }

    }
}
