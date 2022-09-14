﻿using Microsoft.Extensions.DependencyInjection;
using SPV.DataAcces.Repositories.Contracts;
using SPV.DataAcces.Repositories.Implementations;
using SPV.DataAccess.Repositories.Contracts;
using SPV.DataAccess.Repositories.Implementations;
using SPV.Infrastructure.Services.Contracts;
using SPV.Infrastructure.Services.Implementations;
using System;
using System.Windows.Forms;


namespace SPV.Presentation
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                //var FrmPuntoVenta = serviceProvider.GetRequiredService<Frm_Punto_Venta>();
                var FrmPuntoVenta = serviceProvider.GetRequiredService<Frm_Productos>();
                Application.Run(FrmPuntoVenta);
            };
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPuntoVentaService, PuntoVentaService>()
                .AddScoped<IPuntoVentaRepository, PuntoVentaRepository>()
                .AddScoped<IFamiliaRepository, FamiliaRepository>()
                .AddScoped<IFamiliaService, FamiliaService>()
                .AddScoped<IMarcaRepository, MarcaRepository>()
                .AddScoped<IMarcaService, MarcaService>()
                .AddScoped<IUnidadesMedidaRepository, UnidadesMedidaRepository>()
                .AddScoped<IUnidadesMedidaService, UnidadesMedidaService>()
                .AddScoped<ISubFamiliaRepository, SubFamiliaRepository>()
                .AddScoped<ISubFamiliaService, SubFamiliaService>()
                .AddScoped<IMesaRepository,MesaRepository>()
                .AddScoped<IMesaService,MesaService>()
                .AddScoped<IAreaDespachoRepository, AreaDespachoRepository>()
                .AddScoped<IAreaDespachoService, AreaDespachoService>()
                .AddScoped<IProductoRepository, ProductoRepository>()
                .AddScoped<IProductoService, ProductoService>()
                .AddScoped<Frm_Punto_Venta>()
                .AddScoped<Frm_Familias>()
                .AddScoped<Frm_Marcas>()
                .AddScoped<Frm_Unidades_Medidas>()
                .AddScoped<Frm_SubFamilias>()
                .AddScoped<Frm_Mesas>()
                .AddScoped<Frm_Area_Despacho>()
                .AddScoped<Frm_Productos>();
        }
    }
}
