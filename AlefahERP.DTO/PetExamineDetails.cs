using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetExamineDetails
    {
        [Key]
        public int PetExamineDetailID { get; set; }
        public int PetExamineTypeID { get; set; }
        public int PetSubSpeciesID { get; set; }
        //[Precision(18, 2)]
        public double? EL { get; set; }
        //[Precision(18, 2)]
        public double? Low { get; set; }
        //[Precision(18, 2)]
        public double? High { get; set; }
        //[Precision(18, 2)]
       // public decimal? EH { get; set; }
        [Precision(18, 2)]
        public double? Panting { get; set; }

    }
}
