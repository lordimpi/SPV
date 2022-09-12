using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Mesas : Form
    {
        public Frm_Rpt_Mesas()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Mesas_Load(object sender, EventArgs e)
        {
            uSP_Listado_meTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_me, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
