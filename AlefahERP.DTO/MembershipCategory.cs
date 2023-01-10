using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class MembershipCategory
    {
        [Key]
        public int MembershipCategoryID { get; set; }
        public string MembershipCategoryCode { get; set; }
        public string MembershipCategoryNameEN { get; set; }
        public string MembershipCategoryNameAR { get; set; }
        public int? No_of_Visit_Begin { get; set; }
        public int? No_of_Visit_End { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
