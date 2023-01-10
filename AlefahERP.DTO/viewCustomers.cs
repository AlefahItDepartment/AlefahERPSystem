using System.Numerics;
using System.Reflection.Emit;

namespace AlefahERP.DTO
{
    public class viewCustomers
    {
        public int CustomerID { get; set; }
        public int MembershipCategoryID { get; set; }
        public string MembershipCategoryCode { get; set; }
        public string MembershipCategoryNameEN { get; set; }
        public string? MembershipCategoryNameAR { get; set; }
        public int? No_of_Visit_Begin { get; set; }
        public int? No_of_Visit_End { get; set; }
        public string FileNumber { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int UserID { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
