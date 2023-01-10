using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class BookingStatus
    {
        [Key]
        public int BookingStatusID { get; set; }
        public string BookingStatusCode { get; set; }
        public string BookingStatusNameEN { get; set; }
        public string? BookingStatusNameAR { get; set; }
        public bool? IsActive { get; set; }

    }
}
