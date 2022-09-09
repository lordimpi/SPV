using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;

        public MarcaService(IMarcaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteMarca(int id)
        {
            return await _repository.DeleteMarca(id);
        }

        public async Task<ICollection<Marca>> ListMarcas(string texto)
        {
            return await _repository.ListMarcas(texto);
        }

        public async Task<bool> SaveMarca(int opcion, Marca marca)
        {
            return await _repository.SaveMarca(opcion, marca);
        }
    }
}
