using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class FamiliaService : IFamliaService
    {
        private readonly IFamiliaRepository _repository;

        public FamiliaService(IFamiliaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteFamilia(int id)
        {
            return await _repository.DeleteFamilia(id);
        }

        public async Task<ICollection<Familia>> ListFamilias(string texto)
        {
            return await _repository.ListFamilias(texto);
        }

        public async Task<bool> SaveFamilia(int opcion, Familia familia)
        {
            return await _repository.SaveFamilia(opcion, familia);
        }
    }
}
