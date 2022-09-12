using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.DataAccess.Entities;
using SPV.DataAccess.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IPuntoVentaRepository _puntoVentaRepository;

        public MesaService(IMesaRepository mesaRepository, IPuntoVentaRepository puntoVentaRepository)
        {
            _mesaRepository = mesaRepository;
            _puntoVentaRepository = puntoVentaRepository;
        }

        public async Task<bool> DeleteMesa(int id)
        {
            return await _mesaRepository.DeleteMesa(id);
        }

        public async Task<ICollection<Mesa>> ListMesas(string texto)
        {
            return await _mesaRepository.ListMesas(texto);
        }

        public async Task<ICollection<PuntoVenta>> ListPuntosVenta(string texto)
        {
            return await _puntoVentaRepository.ListPuntoVentas(texto);
        }

        public async Task<bool> SaveMesa(int opcion, Mesa mesa)
        {
            return await _mesaRepository.SaveMesa(opcion, mesa);
        }
    }
}
