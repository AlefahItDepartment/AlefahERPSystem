using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class BranchSchedules
    {
        [Key]
        public int BranchScheduleID { get; set; }
        public int BranchID { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int? MaxAppts { get; set; }
        public int? CountAppts { get; set; }
        public bool? IsAvailable { get; set; }


    }
}
