using SPV.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAccess.Repositories.Contracts
{
    public interface IPuntoVentaRepository
    {
        Task<ICollection<PuntoVenta>> ListPuntoVentas(string texto);
        Task<bool> SavePuntoVenta(int opcion, PuntoVenta puntoVenta);
        Task<bool> DeletePuntoVenta(int id);
    }
}
