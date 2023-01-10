using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public int BookingHeadId { get; set; }
        public int Rating { get; set; }
        public string? FeedbackDetail { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
