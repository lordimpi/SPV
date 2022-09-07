using Microsoft.Extensions.DependencyInjection;
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
                var FrmPuntoVenta = serviceProvider.GetRequiredService<Frm_Punto_Venta>();
                Application.Run(FrmPuntoVenta);
            };
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPuntoVentaService, PuntoVentaService>()
                .AddScoped<IPuntoVentaRepository, PuntoVentaRepository>()
                .AddScoped<Frm_Punto_Venta>();
        }
    }
}
