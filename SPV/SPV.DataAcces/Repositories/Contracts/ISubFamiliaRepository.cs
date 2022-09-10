using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface ISubFamiliaRepository
    {
        Task<ICollection<SubFamilia>> ListSubFamilias(string texto);
        Task<bool> SaveSubFamilia(int opcion, SubFamilia subFamilia);
        Task<bool> DeleteSubFamilia(int id);
    }
}
