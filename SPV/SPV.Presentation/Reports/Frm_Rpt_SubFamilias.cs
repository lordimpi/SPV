using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_SubFamilias : Form
    {
        public Frm_Rpt_SubFamilias()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_SubFamilias_Load(object sender, EventArgs e)
        {
            uSP_Listado_sfTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_sf, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
