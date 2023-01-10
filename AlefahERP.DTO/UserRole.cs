using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        public string UserRoleCode { get; set; }
        public string UserRoleNameEN { get; set; }
        public string? UserRoleNameAR { get; set; }

    }
}
