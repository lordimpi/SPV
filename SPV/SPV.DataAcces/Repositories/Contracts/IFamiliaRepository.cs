using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IFamiliaRepository
    {
        Task<ICollection<Familia>> ListFamilias(string texto);
        Task<bool> SaveFamilia(int opcion, Familia familia);
        Task<bool> DeleteFamilia(int id);
    }
}
