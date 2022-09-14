using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Area_Despacho : Form
    {
        public Frm_Rpt_Area_Despacho()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Area_Despacho_Load(object sender, EventArgs e)
        {
            uSP_Listado_adTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_ad, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
