using System.Reflection;

namespace AlefahERP.DTO
{
    public class viewUsers
    {

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpired { get; set; }
        public string? OTPNumber { get; set; }
        public DateTime? OTPExpired { get; set; }
        public int UserRoleID { get; set; }
        public string UserRoleCode { get; set; }
        public string UserRoleNameEN { get; set; }
        public string? UserRoleNameAR { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }





    }
}
