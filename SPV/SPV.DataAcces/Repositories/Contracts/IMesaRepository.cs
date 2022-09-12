using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IMesaRepository
    {
        Task<ICollection<Mesa>> ListMesas(string texto);
        Task<bool> SaveMesa(int opcion, Mesa mesa);
        Task<bool> DeleteMesa(int id);
    }
}
