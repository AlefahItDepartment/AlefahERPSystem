using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class TestTypesParametersDetails
    {
        [Key]
        public int TestTypeParameterDetailID { get; set; }
        public int TestTypeParameterID { get; set; }
        public int PetSpeciesID { get; set; }
        public float? Low { get; set; }
        public float? High { get; set; }
        public float? Positive { get; set; }
        public float? Nagitive { get; set; }
    }
}
