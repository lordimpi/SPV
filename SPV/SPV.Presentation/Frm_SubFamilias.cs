using SPV.DataAcces.Entities;
using SPV.Infrastructure.Services.Contracts;
using SPV.Presentation.Reports;
using System;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_SubFamilias : Form
    {

        #region "Mis Variables"
        private int nCodigo = 0;
        private int nCodigo_fa = 0;
        private int Estadoguarda = 0;
        private readonly ISubFamiliaService _subFamiliaService;
        #endregion
        public Frm_SubFamilias(ISubFamiliaService subFamiliaService)
        {
            InitializeComponent();
            _subFamiliaService = subFamiliaService;
        }

        #region "Mis Métodos"
        private void Formato_sf()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_SF";
            Dgv_Listado.Columns[1].Width = 260;
            Dgv_Listado.Columns[1].HeaderText = "SUBFAMILIA";
            Dgv_Listado.Columns[2].Width = 260;
            Dgv_Listado.Columns[2].HeaderText = "FAMILIA";
            Dgv_Listado.Columns[3].Visible = false;
        }

        private void Formato_fa()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 350;
            Dgv_1.Columns[1].HeaderText = "FAMILIA";
        }

        private async void Listado_sf(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = await _subFamiliaService.ListSubFamilias(cTexto);
                Formato_sf();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_fa(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = await _subFamiliaService.ListFamilias(cTexto);
                Formato_fa();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion.Text = "";
            Txt_familia.Text = "";
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
            Btn_lupa1.Visible = Lestado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["Codigo_sf"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_sf"].Value);
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_sf"].Value);
                Txt_familia.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_fa"].Value);
                nCodigo_fa = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_fa"].Value);
            }
        }

        private void Selecciona_item_fa()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["Codigo_fa"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_familia.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["Descripcion_fa"].Value);
                nCodigo_fa = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_fa"].Value);
            }
        }
        #endregion

        private void Frm_SubFamilias_Load(object sender, EventArgs e)
        {
            Listado_sf("%");
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
            Btn_lupa1.Focus();
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
                if (Txt_descripcion.Text == string.Empty ||
                    Txt_familia.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    string Rpta = "";
                    SubFamilia oPropiedad = new SubFamilia
                    {
                        Codigo_sf = nCodigo,
                        Descripcion_sf = Txt_descripcion.Text.Trim(),
                        Codigo_fa = nCodigo_fa
                    };
                    if (await _subFamiliaService.SaveSubFamilia(Estadoguarda, oPropiedad))
                    {
                        MessageBox.Show("Los datos han sido guardados correctamente",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        Limpia_Texto();
                        Estado_Texto(false);
                        Estado_BotonesPrincipales(true);
                        Estado_BotonesProcesos(false);
                        Estadoguarda = 0;
                        nCodigo = 0;
                        nCodigo_fa = 0;
                        Listado_sf("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta,
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
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
            if (Dgv_Listado.Rows.Count > 0)
            {
                Estadoguarda = 2; //Actualiza registro
                Estado_BotonesPrincipales(false);
                Estado_BotonesProcesos(true);
                Estado_Texto(true);
                Limpia_Texto();
                Selecciona_item();
                Tbc_principal.SelectedIndex = 1;
                Btn_lupa1.Focus();
            }
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
            if (Dgv_Listado.Rows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?",
                                        "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    Selecciona_item();
                    if (await _subFamiliaService.DeleteSubFamilia(nCodigo))
                    {
                        Listado_sf("%");
                        MessageBox.Show("El registro ha sido eliminado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        nCodigo = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                    Limpia_Texto();
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_sf(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para hacer reportes", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Frm_Rpt_SubFamilias oRpt_sf = new Frm_Rpt_SubFamilias();
            oRpt_sf.Txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt_sf.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_fa();
            Pnl_Listado_1.Visible = false;
            Txt_descripcion.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            Listado_fa(Txt_buscar1.Text.Trim());
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa1.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }
    }
}
