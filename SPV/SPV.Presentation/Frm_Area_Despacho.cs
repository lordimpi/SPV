using SPV.DataAcces.Entities;
using SPV.Infrastructure.Services.Contracts;
using System;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_Area_Despacho : Form
    {

        #region "Mis Variables"
        private int nCodigo = 0;
        private int Estadoguarda = 0;
        private readonly IAreaDespachoService _areaDespachoService;
        #endregion
        public Frm_Area_Despacho(IAreaDespachoService areaDespachoService)
        {
            InitializeComponent();
            _areaDespachoService = areaDespachoService;
        }

        #region "Mis Métodos"
        private void Formato_ad()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_AD";
            Dgv_Listado.Columns[1].Width = 220;
            Dgv_Listado.Columns[1].HeaderText = "ÁREA DE DESPACHO";
            Dgv_Listado.Columns[2].Width = 300;
            Dgv_Listado.Columns[2].HeaderText = "IMPRESORA";
        }

        private async void Listado_ad(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = await _areaDespachoService.ListAreasDespacho(cTexto);
                Formato_ad();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion.Text = "";
            Txt_impresora.Text = "";
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
            Txt_impresora.ReadOnly = !lEstado;
        }

        private void Estado_BotonesProcesos(bool Lestado)
        {
            Btn_cancelar.Visible = Lestado;
            Btn_guardar.Visible = Lestado;
            Btn_retornar.Visible = !Lestado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["Codigo_ad"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_ad"].Value);
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_ad"].Value);
                Txt_impresora.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Impresora"].Value);
            }
        }
        #endregion

        private void Frm_Area_Despacho_Load(object sender, EventArgs e)
        {
            Listado_ad("%");
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
                if (Txt_descripcion.Text == string.Empty ||
                    Txt_impresora.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    AreaDespacho oPropiedad = new AreaDespacho
                    {
                        Codigo_ad = nCodigo,
                        Descripcion_ad = Txt_descripcion.Text.Trim(),
                        Impresora = Txt_impresora.Text.Trim()
                    };
                    if (await _areaDespachoService.SaveAreaDespacho(Estadoguarda, oPropiedad))
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
                        Listado_ad("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardad el registro",
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
                Txt_descripcion.Focus();
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
                    if (await _areaDespachoService.DeleteAreaDespacho(nCodigo))
                    {
                        Listado_ad("%");
                        MessageBox.Show("El registro ha sido eliminado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
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
            Listado_ad(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                MessageBox.Show("No hay registros para hacer reportes", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Frm_Rpt_Area_Despacho oRpt_ad = new Frm_Rpt_Area_Despacho();
            //oRpt_ad.Txt_p1.Text = Txt_buscar.Text.Trim();
            //oRpt_ad.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
