using SPV.DataAcces.Entities;
using SPV.Infrastructure.Services.Contracts;
using SPV.Presentation.Reports;
using System;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_Mesas : Form
    {

        #region "Mis Variables"
        private int nCodigo = 0;
        private int nCodigo_pv = 0;
        private int Estadoguarda = 0;
        private readonly IMesaService _mesaService;
        #endregion

        public Frm_Mesas(IMesaService mesaService)
        {
            InitializeComponent();
            _mesaService = mesaService;
        }

        #region "Mis Métodos"
        private void Formato_me()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_ME";
            Dgv_Listado.Columns[1].Width = 260;
            Dgv_Listado.Columns[1].HeaderText = "MESA";
            Dgv_Listado.Columns[2].Width = 260;
            Dgv_Listado.Columns[2].HeaderText = "PUNTO DE VENTA";
            Dgv_Listado.Columns[3].Visible = false;
        }

        private void Formato_pv()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 350;
            Dgv_1.Columns[1].HeaderText = "PUNTO DE VENTA";
        }

        private async void Listado_me(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = await _mesaService.ListMesas(cTexto);
                Formato_me();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = await _mesaService.ListPuntosVenta(cTexto);
                Formato_pv();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion.Text = "";
            Txt_punto_venta.Text = "";
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["Codigo_me"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_me"].Value);
                Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_me"].Value);
                Txt_punto_venta.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_pv"].Value);
                nCodigo_pv = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_pv"].Value);
            }
        }

        private void Selecciona_item_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["Codigo_pv"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_punto_venta.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["Descripcion_pv"].Value);
                nCodigo_pv = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_pv"].Value);
            }
        }
        #endregion

        private void Frm_Mesas_Load(object sender, EventArgs e)
        {
            Listado_me("%");
            Listado_pv("%");
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
                    Txt_punto_venta.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    Mesa oPropiedad = new Mesa
                    {
                        Codigo_me = nCodigo,
                        Descripcion_me = Txt_descripcion.Text.Trim(),
                        Codigo_pv = nCodigo_pv
                    };
                    if (await _mesaService.SaveMesa(Estadoguarda, oPropiedad))
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
                        nCodigo_pv = 0;
                        Listado_me("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el registro",
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
                    if (await _mesaService.DeleteMesa(nCodigo))
                    {
                        Listado_me("%");
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
            Listado_me(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para hacer reportes", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Frm_Rpt_Mesas oRpt_me = new Frm_Rpt_Mesas();
            oRpt_me.Txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt_me.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_pv();
            Pnl_Listado_1.Visible = false;
            Txt_descripcion.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            Listado_pv(Txt_buscar1.Text.Trim());
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa1.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }
    }
}
