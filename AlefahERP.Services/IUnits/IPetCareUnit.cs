using AlefahERP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.IUnits
{
    public interface IPetCareUnit
    {
        //IPetBloodChemistryDetailsService PetBloodChemistryDetails { get; }
        //IPetBloodChemistryTypesService PetBloodChemistryTypes { get; }
        //IPetBloodScreenDetailsService PetBloodScreenDetails { get; }
        //IPetBloodScreenTypesService PetBloodScreenTypes { get; }
        IPetBreedsService PetBreeds { get; }
        IPetColorsService PetColors { get; }
        //IPetExamineDetailsService PetExamineDetails { get; }
        //IPetExamineTypesService PetExamineTypes { get; }
        //IPetOriginsService PetOrigins { get; }
        IPetSizesService PetSizes { get; }
        IPetSpeciesService PetSpecies { get; }
        //IPetSpeciesService PetSpecies { get; }

    }
}
