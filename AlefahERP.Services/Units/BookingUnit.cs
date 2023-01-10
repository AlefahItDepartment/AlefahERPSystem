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
    public class BookingUnit : IBookingUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public BookingUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }

        public IBookingService BookingHead => _serviceProvider.GetRequiredService<IBookingService>();

        public IFeedbackService Fedback => _serviceProvider.GetRequiredService<IFeedbackService>();
    }
}
