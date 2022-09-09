using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Unidades_Medidas : Form
    {
        public Frm_Rpt_Unidades_Medidas()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Unidades_Medidas_Load(object sender, EventArgs e)
        {
            uSP_Listado_umTableAdapter.Fill(this.dataSet_DatosMaestros.USP_Listado_um, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
