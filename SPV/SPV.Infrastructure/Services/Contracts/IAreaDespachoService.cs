using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IAreaDespachoService
    {
        Task<ICollection<AreaDespacho>> ListAreasDespacho(string texto);
        Task<bool> SaveAreaDespacho(int opcion, AreaDespacho areaDespacho);
        Task<bool> DeleteAreaDespacho(int id);
    }
}
