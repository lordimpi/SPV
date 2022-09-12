using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class AreaDespachoService : IAreaDespachoService
    {
        private readonly IAreaDespachoRepository _areaDespachoRepository;

        public AreaDespachoService(IAreaDespachoRepository areaDespachoRepository)
        {
            _areaDespachoRepository = areaDespachoRepository;
        }

        public async Task<bool> DeleteAreaDespacho(int id)
        {
            return await _areaDespachoRepository.DeleteAreaDespacho(id);
        }

        public async Task<ICollection<AreaDespacho>> ListAreasDespacho(string texto)
        {
            return await _areaDespachoRepository.ListAreasDespacho(texto);
        }

        public async Task<bool> SaveAreaDespacho(int opcion, AreaDespacho areaDespacho)
        {
            return await _areaDespachoRepository.SaveAreaDespacho(opcion, areaDespacho);
        }
    }
}
