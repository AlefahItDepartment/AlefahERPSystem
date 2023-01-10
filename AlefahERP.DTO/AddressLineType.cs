using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class AddressLineType
    {
        [Key]
        public int AddressLineTypeID { get; set; }
        public string AddressLineTypeName { get; set; }

    }
}
