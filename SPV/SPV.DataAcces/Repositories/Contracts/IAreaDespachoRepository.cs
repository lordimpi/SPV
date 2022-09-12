using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IAreaDespachoRepository
    {
        Task<ICollection<AreaDespacho>> ListAreasDespacho(string texto);
        Task<bool> SaveAreaDespacho(int opcion, AreaDespacho areaDespacho);
        Task<bool> DeleteAreaDespacho(int id);
    }
}
