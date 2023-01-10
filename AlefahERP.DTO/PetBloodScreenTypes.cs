using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetBloodScreenTypes
    {
        [Key]
        public int PetBloodScreenTypeID { get; set; }
        public string PetBloodScreenTypeNameEN { get; set; }
        public string? PetBloodScreenTypeNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
