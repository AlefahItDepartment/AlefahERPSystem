using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AlefahERP.DTO
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public int MembershipCategoryID { get; set; }
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
