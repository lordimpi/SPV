using SPV.DataAcces.Entities;
using SPV.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IMesaService
    {
        Task<ICollection<Mesa>> ListMesas(string texto);
        Task<ICollection<PuntoVenta>> ListPuntosVenta(string texto);
        Task<bool> SaveMesa(int opcion, Mesa mesa);
        Task<bool> DeleteMesa(int id);
    }
}
