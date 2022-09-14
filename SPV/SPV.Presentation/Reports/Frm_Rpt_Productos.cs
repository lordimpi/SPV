using System;
using System.Windows.Forms;

namespace SPV.Presentation.Reports
{
    public partial class Frm_Rpt_Productos : Form
    {
        public Frm_Rpt_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Productos_Load(object sender, EventArgs e)
        {
            uSP_Listado_prTableAdapter.Fill(dataSet_DatosMaestros.USP_Listado_pr, cTexto: Txt_p1.Text.Trim());

            reportViewer1.RefreshReport();
        }
    }
}
