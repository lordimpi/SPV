using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Familias : Form
    {
        public Frm_Rpt_Familias()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Familias_Load(object sender, EventArgs e)
        {
            uSP_Listado_faTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_fa, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
