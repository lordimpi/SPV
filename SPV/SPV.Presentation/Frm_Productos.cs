using SPV.DataAcces.Entities;
using SPV.Infrastructure.Services.Contracts;
using SPV.Presentation.Reports;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_Productos : Form
    {

        #region "Mis Variables"
        private int nCodigo = 0;
        private int nCodigo_ma = 0;
        private int nCodigo_um = 0;
        private int nCodigo_sf = 0;
        private int nCodigo_ad = 0;
        private int Estadoguarda = 0;
        private DataTable Dtdetalle = new DataTable();
        private readonly IProductoService _productoService;
        #endregion

        public Frm_Productos(IProductoService productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        #region "Mis Métodos"
        private void Formato_pr()
        {
            Dgv_Listado.Columns[0].Width = 90;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_PR";
            Dgv_Listado.Columns[1].Width = 260;
            Dgv_Listado.Columns[1].HeaderText = "PRODUCTO";
            Dgv_Listado.Columns[2].Width = 150;
            Dgv_Listado.Columns[2].HeaderText = "MARCA";
            Dgv_Listado.Columns[3].Width = 100;
            Dgv_Listado.Columns[3].HeaderText = "MEDIDA";
            Dgv_Listado.Columns[4].Width = 150;
            Dgv_Listado.Columns[4].HeaderText = "SUBFAMILIA";
            Dgv_Listado.Columns[5].Width = 90;
            Dgv_Listado.Columns[5].HeaderText = "P.UNITARIO";
            Dgv_Listado.Columns[6].Width = 150;
            Dgv_Listado.Columns[6].HeaderText = "ÁREA DESPACHO";
            Dgv_Listado.Columns[7].Visible = false;
            Dgv_Listado.Columns[8].Visible = false;
            Dgv_Listado.Columns[9].Visible = false;
            Dgv_Listado.Columns[10].Visible = false;
            Dgv_Listado.Columns[11].Visible = false;
        }

        private void Formato_ma()
        {
            Dgv_1.Columns[0].Visible = false;
            Dgv_1.Columns[1].Width = 250;
            Dgv_1.Columns[1].HeaderText = "MARCA";
        }

        private void Formato_um()
        {
            Dgv_2.Columns[0].Visible = false;
            Dgv_2.Columns[1].Width = 250;
            Dgv_2.Columns[1].HeaderText = "MEDIDA";
        }

        private void Formato_sf()
        {
            Dgv_3.Columns[0].Visible = false;
            Dgv_3.Columns[1].Width = 250;
            Dgv_3.Columns[1].HeaderText = "SUBFAMILIA";
            Dgv_3.Columns[2].Width = 250;
            Dgv_3.Columns[2].HeaderText = "FAMILIA";
            Dgv_3.Columns[3].Visible = false;
        }

        private void Formato_ad()
        {
            Dgv_4.Columns[0].Visible = false;
            Dgv_4.Columns[1].Width = 250;
            Dgv_4.Columns[1].HeaderText = "ÁREA DE DESPACHO";
        }

        private async void Listado_pr(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = await _productoService.ListProductos(cTexto);
                Formato_pr();
                Lbl_totalregistros.Text = "Total registros: " + Convert.ToString(Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_ma(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = await _productoService.ListMarca(cTexto);
                Formato_ma();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_um(string cTexto)
        {
            try
            {
                Dgv_2.DataSource = await _productoService.ListUnidadesMedida(cTexto);
                Formato_um();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_sf(string cTexto)
        {
            try
            {
                Dgv_3.DataSource = await _productoService.ListSubFamilias(cTexto);
                Formato_sf();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private async void Listado_ad(string cTexto)
        {
            try
            {
                Dgv_4.DataSource = await _productoService.ListAreasDespacho(cTexto);
                Formato_ad();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_Texto()
        {
            Txt_descripcion_pr.Text = "";
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_um.Text = "";
            Txt_descripcion_sf.Text = "";
            Txt_precio_unitario.Text = "0.00";
            Txt_descripcion_ad.Text = "";
            Txt_observacion.Text = "";
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
            Txt_descripcion_pr.ReadOnly = !lEstado;
            Txt_precio_unitario.ReadOnly = !lEstado;
            Txt_observacion.ReadOnly = !lEstado;
        }

        private void Estado_BotonesProcesos(bool Lestado)
        {
            Btn_cancelar.Visible = Lestado;
            Btn_guardar.Visible = Lestado;
            Btn_retornar.Visible = !Lestado;
            Btn_lupa_ma.Visible = Lestado;
            Btn_lupa_um.Visible = Lestado;
            Btn_lupa_sf.Visible = Lestado;
            Btn_lupa_ad.Visible = Lestado;
            Btn_agregar_imagen.Visible = Lestado;
        }

        private async void Mostrar_img(int nCodigo_pr)
        {
            byte[] bImagen = new byte[0];
            bImagen = await _productoService.GetImage(nCodigo_pr);
            MemoryStream ms = new MemoryStream(bImagen);
            Pct_imagen.Image = System.Drawing.Bitmap.FromStream(ms);
        }

        private async void Mostrar_img_prod_pred()
        {
            byte[] bImagen = new byte[0];
            bImagen = await _productoService.GetImgProdPred();
            MemoryStream ms = new MemoryStream(bImagen);
            Pct_imagen.Image = System.Drawing.Bitmap.FromStream(ms);
        }

        private void Crear_Tabla_pv()
        {
            Dtdetalle = new DataTable("Detalle");
            Dtdetalle.Columns.Add("Descripcion_pv", System.Type.GetType("System.String"));
            Dtdetalle.Columns.Add("OK", System.Type.GetType("System.Boolean"));
            Dtdetalle.Columns.Add("Codigo_pv", System.Type.GetType("System.Int32"));

            Dgv_PuntosVentas.DataSource = Dtdetalle;

            Dgv_PuntosVentas.Columns[0].Width = 220;
            Dgv_PuntosVentas.Columns[0].HeaderText = "PUNTO DE VENTA";
            Dgv_PuntosVentas.Columns[0].ReadOnly = true;
            Dgv_PuntosVentas.Columns[1].Width = 45;
            Dgv_PuntosVentas.Columns[1].HeaderText = "OK";
            Dgv_PuntosVentas.Columns[1].ReadOnly = true;
            Dgv_PuntosVentas.Columns[2].Visible = false;
        }

        private void Agregar_pv(string Descripcion_pv, bool OK, int nCodigo_pv)
        {
            DataRow Fila = Dtdetalle.NewRow();
            Fila["Descripcion_pv"] = Descripcion_pv;
            Fila["OK"] = OK;
            Fila["Codigo_pv"] = nCodigo_pv;
            Dtdetalle.Rows.Add(Fila);
        }

        private async void Puntos_Ventas_OK(int nOpcion, int nCodigo_pr)
        {
            try
            {
                DataTable Tablatemp = new DataTable();
                Tablatemp = await _productoService.PuntosVentaOk(nOpcion, nCodigo_pr);
                Dtdetalle.Clear();
                for (int nFila = 0; nFila <= Tablatemp.Rows.Count - 1; nFila++)
                {
                    Agregar_pv(Convert.ToString(Tablatemp.Rows[nFila][0]),
                                   Convert.ToBoolean(Tablatemp.Rows[nFila][1]),
                                   Convert.ToInt32(Tablatemp.Rows[nFila][2]));
                }
                Dgv_PuntosVentas.DataSource = Dtdetalle;

                if (nOpcion >= 1)
                {
                    Dgv_PuntosVentas.Columns["OK"].ReadOnly = false;
                }
                else
                {
                    Dgv_PuntosVentas.Columns["OK"].ReadOnly = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Listado.CurrentRow.Cells["Codigo_pr"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_pr"].Value);
                Txt_descripcion_pr.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_pr"].Value);
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_ma"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_um"].Value);
                Txt_descripcion_sf.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_sf"].Value);
                Txt_precio_unitario.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["precio_unitario"].Value);
                Txt_descripcion_ad.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion_ad"].Value);
                Txt_observacion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Observacion"].Value);

                nCodigo_ma = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_ma"].Value);
                nCodigo_um = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_um"].Value);
                nCodigo_sf = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_sf"].Value);
                nCodigo_ad = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo_ad"].Value);
                Mostrar_img(nCodigo);
                Puntos_Ventas_OK(Estadoguarda, nCodigo);
            }
        }

        private void Selecciona_item_ma()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_1.CurrentRow.Cells["Codigo_ma"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_1.CurrentRow.Cells["Descripcion_ma"].Value);
                nCodigo_ma = Convert.ToInt32(Dgv_1.CurrentRow.Cells["Codigo_ma"].Value);
            }
        }

        private void Selecciona_item_um()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_2.CurrentRow.Cells["Codigo_um"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_um.Text = Convert.ToString(Dgv_2.CurrentRow.Cells["Descripcion_um"].Value);
                nCodigo_um = Convert.ToInt32(Dgv_2.CurrentRow.Cells["Codigo_um"].Value);
            }
        }

        private void Selecciona_item_sf()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_3.CurrentRow.Cells["Codigo_sf"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_sf.Text = Convert.ToString(Dgv_3.CurrentRow.Cells["Descripcion_sf"].Value);
                nCodigo_sf = Convert.ToInt32(Dgv_3.CurrentRow.Cells["Codigo_sf"].Value);
            }
        }

        private void Selecciona_item_ad()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_4.CurrentRow.Cells["Codigo_ad"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Txt_descripcion_ad.Text = Convert.ToString(Dgv_4.CurrentRow.Cells["Descripcion_ad"].Value);
                nCodigo_ad = Convert.ToInt32(Dgv_4.CurrentRow.Cells["Codigo_ad"].Value);
            }
        }
        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            Listado_pr("%");
            Listado_ma("%");
            Listado_um("%");
            Listado_sf("%");
            Listado_ad("%");
            Crear_Tabla_pv();

        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro 
            Estado_BotonesPrincipales(false);
            Estado_BotonesProcesos(true);
            Limpia_Texto();
            Estado_Texto(true);
            Puntos_Ventas_OK(Estadoguarda, 0);
            Mostrar_img_prod_pred();
            nCodigo = 0;
            nCodigo_ma = 0;
            nCodigo_um = 0;
            nCodigo_sf = 0;
            nCodigo_ad = 0;
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_pr.Focus();
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
                if (Txt_descripcion_pr.Text == string.Empty ||
                    Txt_descripcion_ma.Text == string.Empty ||
                    Txt_descripcion_um.Text == string.Empty ||
                    Txt_descripcion_sf.Text == string.Empty ||
                    Txt_descripcion_ad.Text == string.Empty ||
                    Txt_precio_unitario.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    Producto oPropiedad = new Producto
                    {
                        Codigo_pr = nCodigo,
                        Descripcion_pr = Txt_descripcion_pr.Text.Trim(),
                        Codigo_ma = nCodigo_ma,
                        Codigo_um = nCodigo_um,
                        Codigo_sf = nCodigo_sf,
                        Codigo_ad = nCodigo_ad,
                        Precio_unitario = Convert.ToDecimal(Txt_precio_unitario.Text),
                        Observacion = Txt_observacion.Text.Trim()
                    };
                    MemoryStream ms = new MemoryStream();
                    Pct_imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    oPropiedad.Imagen = ms.GetBuffer();

                    if (await _productoService.SaveProducto(Estadoguarda, oPropiedad, Dtdetalle))
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
                        nCodigo_ma = 0;
                        nCodigo_um = 0;
                        nCodigo_sf = 0;
                        nCodigo_ad = 0;
                        Listado_pr("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el producto",
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
                Txt_descripcion_pr.Focus();
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
                    if (await _productoService.DeleteProducto(nCodigo))
                    {
                        Listado_pr("%");
                        MessageBox.Show("El registro ha sido eliminado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        nCodigo = 0;
                        nCodigo_ma = 0;
                        nCodigo_um = 0;
                        nCodigo_sf = 0;
                        nCodigo_ad = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el producto",
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
            Listado_pr(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para hacer reportes", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Frm_Rpt_Productos oRpt_pr = new Frm_Rpt_Productos();
            oRpt_pr.Txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt_pr.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_ma();
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Visible = false;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            Listado_ma(Txt_buscar1.Text.Trim());
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_1.Location = Btn_lupa_ma.Location;
            Pnl_Listado_1.Visible = true;
            Txt_buscar1.Focus();
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            Pnl_Listado_2.Location = Btn_lupa_um.Location;
            Pnl_Listado_2.Visible = true;
            Txt_buscar2.Focus();
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_2.Visible = false;
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            Listado_um(Txt_buscar2.Text.Trim());
        }

        private void Dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_um();
            Pnl_Listado_2.Visible = false;
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_3.Visible = false;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            Listado_sf(Txt_buscar3.Text.Trim());
        }

        private void Dgv_3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_sf();
            Pnl_Listado_3.Visible = false;
            Txt_precio_unitario.Focus();
        }

        private void Btn_lupa_sf_Click(object sender, EventArgs e)
        {
            Pnl_Listado_3.Location = Btn_lupa_ma.Location;
            Pnl_Listado_3.Visible = true;
            Txt_buscar3.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_4.Visible = false;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            Listado_ad(Txt_buscar4.Text.Trim());
        }

        private void Dgv_4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecciona_item_ad();
            Pnl_Listado_4.Visible = false;
            Txt_observacion.Focus();
        }

        private void Btn_lupa_ad_Click(object sender, EventArgs e)
        {
            Pnl_Listado_4.Location = Btn_lupa_sf.Location;
            Pnl_Listado_4.Visible = true;
            Txt_buscar4.Focus();
        }

        private void Btn_agregar_imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Foto = new OpenFileDialog
            {
                Filter = "Image files(*.jpg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (Foto.ShowDialog() == DialogResult.OK)
            {
                Pct_imagen.Image = Image.FromFile(Foto.FileName);
            }
        }
    }
}
