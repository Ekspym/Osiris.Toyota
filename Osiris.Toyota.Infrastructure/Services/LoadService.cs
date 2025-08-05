using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Enums;
using Osiris.Toyota.Infrastructure.Connectors;
using Osiris.Toyota.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Services
{
    public interface ILoadService
    {
        Task<LoadDto> GetLoadAsync(string loadId);
        Task UpdateLoadStatus(string loadId, LoadState newState);
    }

    public class LoadService : ILoadService
    {
        private readonly TOneConnector _connector;
        private readonly IGenericMapper _mapper;

        public LoadService(TOneConnector connector, IGenericMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public async Task<LoadDto> GetLoadAsync(string loadId)
        {
            var response = await _connector.SendRequestAsync<object>(
                HttpMethod.Get, $"/api/v1/loads/{loadId}");

            return _mapper.Map<object, LoadDto>(response);
        }

        public Task UpdateLoadStatus(string loadId, LoadState newState)
        {
            throw new NotImplementedException();
        }
    }
}
