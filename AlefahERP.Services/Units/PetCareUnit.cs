using AlefahERP.Services.Interfaces;
using AlefahERP.Services.IUnits;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Units
{
    public class PetCareUnit : IPetCareUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public PetCareUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }

        public IPetBloodChemistryDetailsService PetBloodChemistryDetails => _serviceProvider.GetRequiredService<IPetBloodChemistryDetailsService>();

        public IPetBloodChemistryTypesService PetBloodChemistryTypes => _serviceProvider.GetRequiredService<IPetBloodChemistryTypesService>();

        public IPetBloodScreenDetailsService PetBloodScreenDetails => _serviceProvider.GetRequiredService<IPetBloodScreenDetailsService>();

        public IPetBloodScreenTypesService PetBloodScreenTypes => _serviceProvider.GetRequiredService<IPetBloodScreenTypesService>();

        public IPetBreedsService PetBreeds => _serviceProvider.GetRequiredService<IPetBreedsService>();

        public IPetColorsService PetColors => _serviceProvider.GetRequiredService<IPetColorsService>();

        public IPetExamineDetailsService PetExamineDetails => _serviceProvider.GetRequiredService<IPetExamineDetailsService>();

        public IPetExamineTypesService PetExamineTypes => _serviceProvider.GetRequiredService<IPetExamineTypesService>();

        public IPetOriginsService PetOrigins => _serviceProvider.GetRequiredService<IPetOriginsService>();

        public IPetSizesService PetSizes => _serviceProvider.GetRequiredService<IPetSizesService>();

        public IPetSpeciesService PetSpecies => _serviceProvider.GetRequiredService<IPetSpeciesService>();

        public IPetSubSpeciesService PetSubSpecies => _serviceProvider.GetRequiredService<IPetSubSpeciesService>();
    }
}
