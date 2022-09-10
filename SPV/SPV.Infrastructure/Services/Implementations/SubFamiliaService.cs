using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class SubFamiliaService : ISubFamiliaService
    {
        private readonly IFamiliaRepository _familiaRepository;
        private readonly ISubFamiliaRepository _subFamiliaRepository;

        public SubFamiliaService(IFamiliaRepository familiaRepository, ISubFamiliaRepository subFamiliaRepository)
        {
            _familiaRepository = familiaRepository;
            _subFamiliaRepository = subFamiliaRepository;
        }

        public async Task<bool> DeleteSubFamilia(int id)
        {
            return await _subFamiliaRepository.DeleteSubFamilia(id);
        }

        public async Task<ICollection<Familia>> ListFamilias(string texto)
        {
            return await _familiaRepository.ListFamilias(texto);
        }

        public async Task<ICollection<SubFamilia>> ListSubFamilias(string texto)
        {
            return await _subFamiliaRepository.ListSubFamilias(texto);
        }

        public async Task<bool> SaveSubFamilia(int opcion, SubFamilia subFamilia)
        {
            return await _subFamiliaRepository.SaveSubFamilia(opcion, subFamilia);
        }
    }
}
