using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class UnidadesMedidaService : IUnidadesMedidaService
    {
        private readonly IUnidadesMedidaRepository _unidadesMedidaRepository;

        public UnidadesMedidaService(IUnidadesMedidaRepository unidadesMedidaRepository)
        {
            _unidadesMedidaRepository = unidadesMedidaRepository;
        }

        public async Task<bool> DeleteUnidadMedida(int id)
        {
            return await _unidadesMedidaRepository.DeleteUnidadMedida(id);
        }

        public async Task<ICollection<UnidadesMedida>> ListUnidadesMedida(string texto)
        {
            return await _unidadesMedidaRepository.ListUnidadesMedida(texto);
        }

        public async Task<bool> SaveUnidadMedida(int opcion, UnidadesMedida unidadesMedida)
        {
            return await _unidadesMedidaRepository.SaveUnidadMedida(opcion, unidadesMedida);
        }
    }
}
