using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Infrastructure.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IGenericMapper _mapper;
        private readonly TOneConnector _connector;  // Reuse existing connector

        public VehicleService(IGenericMapper mapper, TOneConnector connector)
        {
            _mapper = mapper;
            _connector = connector;
        }

        public VehicleDto GetVehicleStatus(string vin)
        {
            var vehicle = _connector.FetchVehicle(vin);  // Uses existing infra
            return _mapper.Map<VehicleDto>(vehicle);
        }
    }
}
