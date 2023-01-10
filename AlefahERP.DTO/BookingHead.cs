using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class BookingHead
    {
        [Key]
        public int BookingHeadID { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CustomerID { get; set; }
        public int CustomerPetID { get; set; }
        public int ServiceTypeID { get; set; }
        public int BookingStatusID { get; set; }
        public int BranchID { get; set; }
        public int? BookingAssignFromUserID { get; set; }
        public DateTime? FromUser_BookingAssignFromDate { get; set; }
        public int? BookingAssignToUserID { get; set; }
        public DateTime? ToUser_BookingAssignDate { get; set; }
        public int? BookingCloseUserID { get; set; }
        public DateTime? BookingCloseDate { get; set; }

    }
}
