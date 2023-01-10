using System.Numerics;
using System.Reflection;

namespace AlefahERP.DTO
{
    public class viewBookingHead
    {
        public int BookingHeadID { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CustomerID { get; set; }
        public int MembershipCategoryID { get; set; }
        public string? MembershipCategoryCode { get; set; }
        public string? MembershipCategoryNameEN { get; set; }
        public string? MembershipCategoryNameAR { get; set; }
        public int? No_of_Visit_Begin { get; set; }
        public int? No_of_Visit_End { get; set; }
        public string FileNumber { get; set; }
        public string FullName { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CustomerPetID { get; set; }
        public string? PetName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? PetSpeciesID { get; set; }
        public int? PetSubSpeciesID { get; set; }
        public int? PetBreedID { get; set; }
        public int? PetColorID { get; set; }
        public int? PetSizeID { get; set; }
        public string? PetWeight { get; set; }
        public int? PetOriginID { get; set; }
        public string? PetStatus { get; set; }
        public int? ServiceTypeID { get; set; }
        public string? ServiceTypeNameEN { get; set; }
        public string? ServiceTypeNameAR { get; set; }
        public int? BookingStatusID { get; set; }
        public string? BookingStatusCode { get; set; }
        public string? BookingStatusNameEN { get; set; }
        public string? BookingStatusNameAR { get; set; }
        public int BranchID { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchNameEN { get; set; }
        public string? BranchNameAR { get; set; }
        public string? Branch_AddressLine1 { get; set; }
        public string? Branch_AddressLine2 { get; set; }
        public string? Branch_CountryName { get; set; }
        public string? Branch_CountryCode { get; set; }
        public string? Branch_RegionName { get; set; }
        public string? Branch_RegionCode { get; set; }
        public string? Branch_CityName { get; set; }
        public string? Branch_CityCode { get; set; }
        public string? Branch_Location { get; set; }
        public string? ContactName { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactEmail { get; set; }
        public int? BookingAssignFromUserID { get; set; }
        public DateTime? FromUser_BookingAssignFromDate { get; set; }
        public string? AssignFromUser_FullName { get; set; }
        public string? AssignFromUser_Mobile { get; set; }
        public string? AssignFromUser_UserRoleCode { get; set; }
        public string? AssignFromUser_UserRoleNameEN { get; set; }
        public string? AssignFromUser_UserRoleNameAR { get; set; }
        public int? BookingAssignToUserID { get; set; }
        public string? AssignToUser_FullName { get; set; }
        public string? AssignToUser_Mobile { get; set; }
        public string? AssignToUser_UserRoleCode { get; set; }
        public string? AssignToUser_UserRoleNameEN { get; set; }
        public string? AssignToUser_UserRoleNameAR { get; set; }
        public DateTime? ToUser_BookingAssignDate { get; set; }
        public int? BookingCloseUserID { get; set; }
        public string? CloseUser_FullName { get; set; }
        public string? CloseUser_Mobile { get; set; }
        public string? CloseUser_UserRoleCode { get; set; }
        public string? CloseUser_UserRoleNameEN { get; set; }
        public string? CloseUser_UserRoleNameAR { get; set; }
        public DateTime? BookingCloseDate { get; set; }



    }
}
