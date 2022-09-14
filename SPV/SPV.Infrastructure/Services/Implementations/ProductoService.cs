using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IAreaDespachoRepository _areaDespachoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly ISubFamiliaRepository _subFamiliaRepository;
        private readonly IUnidadesMedidaRepository _unidadesMedidaRepository;

        public ProductoService(IProductoRepository productoRepository, IAreaDespachoRepository areaDespachoRepository, IMarcaRepository marcaRepository, ISubFamiliaRepository subFamiliaRepository, IUnidadesMedidaRepository unidadesMedidaRepository)
        {
            _productoRepository = productoRepository;
            _areaDespachoRepository = areaDespachoRepository;
            _marcaRepository = marcaRepository;
            _subFamiliaRepository = subFamiliaRepository;
            _unidadesMedidaRepository = unidadesMedidaRepository;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            return await _productoRepository.DeleteProducto(id);
        }

        public async Task<byte[]> GetImage(int nCodigo_pr)
        {
            return await _productoRepository.GetImage(nCodigo_pr);
        }

        public async Task<byte[]> GetImgProdPred()
        {
            return await _productoRepository.GetImgProdPred();
        }

        public async Task<ICollection<AreaDespacho>> ListAreasDespacho(string texto)
        {
            return await _areaDespachoRepository.ListAreasDespacho(texto);
        }

        public async Task<ICollection<Marca>> ListMarca(string texto)
        {
            return await _marcaRepository.ListMarcas(texto);
        }

        public async Task<ICollection<Producto>> ListProductos(string texto)
        {
            return await _productoRepository.ListProductos(texto);
        }

        public async Task<ICollection<SubFamilia>> ListSubFamilias(string texto)
        {
            return await _subFamiliaRepository.ListSubFamilias(texto);
        }

        public async Task<ICollection<UnidadesMedida>> ListUnidadesMedida(string texto)
        {
            return await _unidadesMedidaRepository.ListUnidadesMedida(texto);
        }

        public async Task<DataTable> PuntosVentaOk(int nOpcion, int nCodigo_pr)
        {
            return await _productoRepository.PuntosVentaOk(nOpcion, nCodigo_pr);
        }

        public async Task<bool> SaveProducto(int opcion, Producto producto, DataTable dataTable)
        {
            return await _productoRepository.SaveProducto(opcion, producto, dataTable);
        }
    }
}
