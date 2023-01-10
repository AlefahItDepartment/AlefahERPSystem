namespace AlefahERP.DTO
{
    public class viewBookingDetails
    {
        public int BookingDetailID { get; set; }
        public int BookingHeadID { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceTypeNameEN { get; set; }
        public string? ServiceTypeNameAR { get; set; }
        public string? ServiceTypeImage { get; set; }
        public int ServiceDetailID { get; set; }
        public string ServiceDetailNameEN { get; set; }
        public string? ServiceDetailNameAR { get; set; }
        public DateTime? BookingBeginDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
        public int? BookingDuration { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? ServiceChargesPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? VATPercentage { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? NETAmount { get; set; }

    }
}
