using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.RequestModels
{
    public class BookingRequestModel
    {
        public BookingHead Booking { get; set; }
        public List<BookingDetails>? BookingDetails { get; set; }
    }
}
