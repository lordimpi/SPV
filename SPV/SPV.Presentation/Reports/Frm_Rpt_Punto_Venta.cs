using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Punto_Venta : Form
    {
        public Frm_Rpt_Punto_Venta()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Punto_Venta_Load(object sender, EventArgs e)
        {
            uSP_Listado_pvTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_pv, cTexto: Txt_p1.Text);
            reportViewer1.RefreshReport();
            //reportViewer2.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
