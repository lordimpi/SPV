using FontAwesome.Sharp;
using SPV.Infrastructure.Services.Contracts;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SPV.Presentation
{
    public partial class Frm_DashBoard : Form
    {
        private IconButton currentBtn;
        private readonly Panel leftBorderBtn;
        private readonly IProductoService _productoService;
        private readonly IAreaDespachoService _areaDespachoService;
        private readonly IFamiliaService _familiaService;
        private readonly IMarcaService _marcaService;
        private readonly IMesaService _mesaService;
        private readonly IPuntoVentaService _puntoVentaService;
        private readonly ISubFamiliaService _subFamiliaService;
        private readonly IUnidadesMedidaService _unidadesMedidaService;

        public Frm_DashBoard(IProductoService productoService, IAreaDespachoService areaDespachoService, IFamiliaService familiaService, IMarcaService marcaService, IMesaService mesaService, IPuntoVentaService puntoVentaService, ISubFamiliaService subFamiliaService, IUnidadesMedidaService unidadesMedidaService)
        {
            InitializeComponent();
            CustomizeDesing();
            leftBorderBtn = new Panel
            {
                Size = new Size(7, 46)
            };
            Pnl_menu.Controls.Add(leftBorderBtn);

            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            _productoService = productoService;
            _areaDespachoService = areaDespachoService;
            _familiaService = familiaService;
            _marcaService = marcaService;
            this._mesaService = mesaService;
            _puntoVentaService = puntoVentaService;
            _subFamiliaService = subFamiliaService;
            _unidadesMedidaService = unidadesMedidaService;
        }

        #region "Mis Métodos"
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            IconoSeleccionado.IconChar = IconChar.Home;
            IconoSeleccionado.IconColor = Color.Black;
            TextoSeleccionado.Text = "Home";
            TextoSeleccionado.ForeColor = Color.Black;
        }
        private void CustomizeDesing()
        {
            Pnl_procesos.Visible = false;
            Pnl_reportes.Visible = false;
            Pnl_datosmaestros.Visible = false;
        }

        private void HideSubMenu()
        {
            if (Pnl_procesos.Visible == true)
            {
                Pnl_procesos.Visible = false;
            }

            if (Pnl_reportes.Visible == true)
            {
                Pnl_reportes.Visible = false;
            }

            if (Pnl_datosmaestros.Visible == true)
            {
                Pnl_datosmaestros.Visible = false;
            }
        }

        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(44, 105, 141);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                IconoSeleccionado.IconChar = currentBtn.IconChar;
                IconoSeleccionado.IconColor = color;
                TextoSeleccionado.Text = currentBtn.Text;
                TextoSeleccionado.ForeColor = color;
            }
        }

        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(24, 161, 251);
        }

        private Form ActiveForm = null;

        private void OpenForm(Form oForm)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }

            ActiveForm = oForm;
            oForm.TopLevel = false;
            oForm.FormBorderStyle = FormBorderStyle.None;
            oForm.Dock = DockStyle.Fill;
            Pnl_contenido.Controls.Add(oForm);
            Pnl_contenido.Tag = oForm;
            oForm.BringToFront();
            oForm.Show();
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_hora.Text = DateTime.Now.ToLongTimeString();
            Lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Btn_maximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr Hwnd, int wMsg, int wParam, int lParam);
        private void Pnl_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Btn_procesos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            ShowSubMenu(Pnl_procesos);
        }

        private void Btn_reportes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            ShowSubMenu(Pnl_reportes);
        }

        private void Btn_datosmaestros_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            ShowSubMenu(Pnl_datosmaestros);
        }

        private void Bnt_Dashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color4);
            CustomizeDesing();
        }

        private void DM_productos_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Productos(_productoService));
        }

        private void Pct_logo_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }

            Reset();
            CustomizeDesing();
        }

        private void DM_marcas_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Marcas(_marcaService));
        }

        private void DM_medidas_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Unidades_Medidas(_unidadesMedidaService));
        }

        private void DM_subfamilias_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_SubFamilias(_subFamiliaService));
        }

        private void DM_familias_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Familias(_familiaService));
        }

        private void DM_puntosventas_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Punto_Venta(_puntoVentaService));
        }

        private void DM_mesas_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Mesas(_mesaService));
        }

        private void DM_areadespacho_Click(object sender, EventArgs e)
        {
            OpenForm(new Frm_Area_Despacho(_areaDespachoService));
        }

        private void PR_registrarpedido_Click(object sender, EventArgs e)
        {
            //OpenForm(new Procesos.Frm_Registro_Pedidos());
        }

        private void PR_gestionturnos_Click(object sender, EventArgs e)
        {
            //OpenForm(new Procesos.Frm_Cierres_Turnos());
        }

    }
}
