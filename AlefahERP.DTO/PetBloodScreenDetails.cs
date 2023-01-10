using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetBloodScreenDetails
    {
        [Key]
        public int PetBloodScreenDetailID { get; set; }
        public int PetBloodScreenTypeID { get; set; }
        public int PetSubSpeciesID { get; set; }
       // [Precision(2)]
        public double? Low { get; set; }
        //[Precision(2)]
        public double? High { get; set; }

    }
}
