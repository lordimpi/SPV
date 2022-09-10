using SPV.DataAcces.Entities;
using SPV.Infrastructure.Services.Contracts;
using SPV.Presentation.Reports;
using System;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_Familias : Form
    {
        #region "Variables"
        private int nCodigo = 0;
        private int Estadoguarda = 0;
        private readonly IFamiliaService _familiaService;
        #endregion

        public Frm_Familias(IFamiliaService famliaService)
        {
            InitializeComponent();
            _familiaService = famliaService;
        }

        #region "Métodos"
        private void Formato_fa()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "Código";
            Dgv_Listado.Columns[1].Width = 350;
            Dgv_Listado.Columns[1].HeaderText = "Familia";
        }

        private async void Listado_fa(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = await _familiaService.ListFamilias(cTexto);
                Formato_fa();
                Lbl_totalregistros.Text = $"Total registros: {Dgv_Listado.Rows.Count}";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion.Text = "";
        }

        private void Estado_BotonesPrincipales(bool lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void Estado_Texto(bool lEstado)
        {
            Txt_descripcion.ReadOnly = !lEstado;
        }

        private void Estado_BotonesProcesos(bool Lestado)
        {
            Btn_cancelar.Visible = Lestado;
            Btn_guardar.Visible = Lestado;
            Btn_retornar.Visible = !Lestado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["Codigo_fa"].Value)))
            {
                MessageBox.Show("Selecciona un registro", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_fa"].Value);
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_fa"].Value);
            }
        }
        #endregion

        private void Frm_Familias_Load(object sender, EventArgs e)
        {
            Listado_fa("%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro 
            Estado_BotonesPrincipales(false);
            Estado_BotonesProcesos(true);
            Limpia_Texto();
            Estado_Texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpia_Texto();
            Estado_Texto(false);
            Estado_BotonesPrincipales(true);
            Estado_BotonesProcesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            Tbc_principal.SelectedIndex = 0;
        }

        private async void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_descripcion.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Familia familia = new Familia()
                    {
                        Codigo_fa = nCodigo,
                        Descripcion_fa = Txt_descripcion.Text.Trim()
                    };
                    if (await _familiaService.SaveFamilia(Estadoguarda, familia))
                    {
                        MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpia_Texto();
                        Estado_Texto(false);
                        Estado_BotonesPrincipales(true);
                        Estado_BotonesProcesos(false);
                        Estadoguarda = 0;
                        Listado_fa("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar los datos", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para actualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Estadoguarda = 2; //Actualiza registro
            Estado_BotonesPrincipales(false);
            Estado_BotonesProcesos(true);
            Estado_Texto(true);
            Limpia_Texto();
            Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion.Focus();
        }

        private void Dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Estadoguarda == 0)
            {
                Selecciona_item();
                Estado_BotonesProcesos(false);
                Tbc_principal.SelectedIndex = 1;
            }

        }

        private async void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para eliminar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Selecciona_item();
                if (await _familiaService.DeleteFamilia(nCodigo))
                {
                    Listado_fa("%");
                    MessageBox.Show("El registro ha sido eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Limpia_Texto();
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_fa(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para hacer reportes", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Frm_Rpt_Familias oRpt_fa = new Frm_Rpt_Familias();
            oRpt_fa.Txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt_fa.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
