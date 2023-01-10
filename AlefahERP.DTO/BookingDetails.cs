using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class BookingDetails
    {
        [Key]
        public int BookingDetailID { get; set; }
        public int BookingHeadID { get; set; }
        public int ServiceTypeID { get; set; }
        public int ServiceDetailID { get; set; }
        public DateTime? BookingBeginDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
        public int? BookingDuration { get; set; }
        [Precision(18, 2)]
        public decimal? UnitPrice { get; set; }
        [Precision(18, 2)]
        public decimal? ServiceChargesPrice { get; set; }
        [Precision(18, 2)]
        public decimal? TotalAmount { get; set; }
        [Precision(18, 2)]
        public decimal? DiscountPercentage { get; set; }
        [Precision(18, 2)]
        public decimal? DiscountAmount { get; set; }
        [Precision(18, 2)]
        public decimal? GrossAmount { get; set; }
        [Precision(18, 2)]
        public decimal? VATPercentage { get; set; }
        [Precision(18, 2)]
        public decimal? VATAmount { get; set; }
        [Precision(18, 2)]
        public decimal? NETAmount { get; set; }

    }
}
