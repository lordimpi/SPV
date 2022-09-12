namespace SPV.Presentation
{
    partial class Frm_Area_Despacho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Area_Despacho));
            this.Tbc_principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Lbl_totalregistros = new System.Windows.Forms.Label();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_Listado = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Txt_impresora = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_retornar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Pnl_titulo_form = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Tbc_principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.Pnl_titulo_form.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbc_principal
            // 
            this.Tbc_principal.Controls.Add(this.tabPage1);
            this.Tbc_principal.Controls.Add(this.tabPage2);
            this.Tbc_principal.ItemSize = new System.Drawing.Size(100, 30);
            this.Tbc_principal.Location = new System.Drawing.Point(16, 64);
            this.Tbc_principal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tbc_principal.Name = "Tbc_principal";
            this.Tbc_principal.SelectedIndex = 0;
            this.Tbc_principal.Size = new System.Drawing.Size(928, 441);
            this.Tbc_principal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Lbl_totalregistros);
            this.tabPage1.Controls.Add(this.Btn_buscar);
            this.tabPage1.Controls.Add(this.Txt_buscar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Dgv_Listado);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(920, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Lbl_totalregistros
            // 
            this.Lbl_totalregistros.AutoSize = true;
            this.Lbl_totalregistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_totalregistros.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_totalregistros.Location = new System.Drawing.Point(760, 338);
            this.Lbl_totalregistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_totalregistros.Name = "Lbl_totalregistros";
            this.Lbl_totalregistros.Size = new System.Drawing.Size(133, 17);
            this.Lbl_totalregistros.TabIndex = 4;
            this.Lbl_totalregistros.Text = "Total registros: 0";
            this.Lbl_totalregistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_buscar.Location = new System.Drawing.Point(393, 43);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(107, 33);
            this.Btn_buscar.TabIndex = 3;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = false;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(84, 47);
            this.Txt_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(300, 22);
            this.Txt_buscar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar:";
            // 
            // Dgv_Listado
            // 
            this.Dgv_Listado.AllowUserToAddRows = false;
            this.Dgv_Listado.AllowUserToDeleteRows = false;
            this.Dgv_Listado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Dgv_Listado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Listado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_Listado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Listado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Listado.ColumnHeadersHeight = 35;
            this.Dgv_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Listado.EnableHeadersVisualStyles = false;
            this.Dgv_Listado.Location = new System.Drawing.Point(20, 84);
            this.Dgv_Listado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_Listado.Name = "Dgv_Listado";
            this.Dgv_Listado.ReadOnly = true;
            this.Dgv_Listado.RowHeadersWidth = 51;
            this.Dgv_Listado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_Listado.Size = new System.Drawing.Size(877, 240);
            this.Dgv_Listado.TabIndex = 0;
            this.Dgv_Listado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Listado_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Txt_impresora);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Btn_retornar);
            this.tabPage2.Controls.Add(this.Btn_guardar);
            this.tabPage2.Controls.Add(this.Btn_cancelar);
            this.tabPage2.Controls.Add(this.Txt_descripcion);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(920, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Txt_impresora
            // 
            this.Txt_impresora.Location = new System.Drawing.Point(155, 108);
            this.Txt_impresora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_impresora.MaxLength = 50;
            this.Txt_impresora.Name = "Txt_impresora";
            this.Txt_impresora.ReadOnly = true;
            this.Txt_impresora.Size = new System.Drawing.Size(297, 22);
            this.Txt_impresora.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Impresora:(*)";
            // 
            // Btn_retornar
            // 
            this.Btn_retornar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(153)))), ((int)(((byte)(117)))));
            this.Btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar.ForeColor = System.Drawing.Color.White;
            this.Btn_retornar.Location = new System.Drawing.Point(383, 156);
            this.Btn_retornar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_retornar.Name = "Btn_retornar";
            this.Btn_retornar.Size = new System.Drawing.Size(107, 33);
            this.Btn_retornar.TabIndex = 6;
            this.Btn_retornar.Text = "Retornar";
            this.Btn_retornar.UseVisualStyleBackColor = false;
            this.Btn_retornar.Visible = false;
            this.Btn_retornar.Click += new System.EventHandler(this.Btn_retornar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_guardar.Location = new System.Drawing.Point(268, 156);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(107, 33);
            this.Btn_guardar.TabIndex = 5;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Visible = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_cancelar.Location = new System.Drawing.Point(153, 156);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(107, 33);
            this.Btn_cancelar.TabIndex = 4;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Visible = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(155, 76);
            this.Txt_descripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_descripcion.MaxLength = 30;
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.ReadOnly = true;
            this.Txt_descripcion.Size = new System.Drawing.Size(297, 22);
            this.Txt_descripcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Área despacho:(*)";
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.Btn_nuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.Btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_nuevo.ImageKey = "new.png";
            this.Btn_nuevo.ImageList = this.imageList1;
            this.Btn_nuevo.Location = new System.Drawing.Point(21, 512);
            this.Btn_nuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(100, 74);
            this.Btn_nuevo.TabIndex = 1;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "log-out.png");
            this.imageList1.Images.SetKeyName(1, "report.png");
            this.imageList1.Images.SetKeyName(2, "delete.png");
            this.imageList1.Images.SetKeyName(3, "edit.png");
            this.imageList1.Images.SetKeyName(4, "new.png");
            // 
            // Btn_actualizar
            // 
            this.Btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.Btn_actualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.Btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_actualizar.ImageKey = "edit.png";
            this.Btn_actualizar.ImageList = this.imageList1;
            this.Btn_actualizar.Location = new System.Drawing.Point(129, 512);
            this.Btn_actualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_actualizar.Name = "Btn_actualizar";
            this.Btn_actualizar.Size = new System.Drawing.Size(100, 74);
            this.Btn_actualizar.TabIndex = 2;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_actualizar.UseVisualStyleBackColor = false;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.Btn_eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.Btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_eliminar.ImageKey = "delete.png";
            this.Btn_eliminar.ImageList = this.imageList1;
            this.Btn_eliminar.Location = new System.Drawing.Point(237, 512);
            this.Btn_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(100, 74);
            this.Btn_eliminar.TabIndex = 3;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.Btn_reporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.Btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_reporte.ImageKey = "report.png";
            this.Btn_reporte.ImageList = this.imageList1;
            this.Btn_reporte.Location = new System.Drawing.Point(345, 512);
            this.Btn_reporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(100, 74);
            this.Btn_reporte.TabIndex = 4;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_reporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.Btn_salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.Btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir.ImageKey = "log-out.png";
            this.Btn_salir.ImageList = this.imageList1;
            this.Btn_salir.Location = new System.Drawing.Point(453, 512);
            this.Btn_salir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(100, 74);
            this.Btn_salir.TabIndex = 5;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Pnl_titulo_form
            // 
            this.Pnl_titulo_form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            this.Pnl_titulo_form.Controls.Add(this.label3);
            this.Pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.Pnl_titulo_form.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pnl_titulo_form.Name = "Pnl_titulo_form";
            this.Pnl_titulo_form.Size = new System.Drawing.Size(1312, 49);
            this.Pnl_titulo_form.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(37, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "ÁREA DE DESPACHO";
            // 
            // Frm_Area_Despacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.Pnl_titulo_form);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Tbc_principal);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Area_Despacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Area_Despacho";
            this.Load += new System.EventHandler(this.Frm_Area_Despacho_Load);
            this.Tbc_principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Pnl_titulo_form.ResumeLayout(false);
            this.Pnl_titulo_form.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_Listado;
        private System.Windows.Forms.Button Btn_retornar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_actualizar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Panel Pnl_titulo_form;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_totalregistros;
        private System.Windows.Forms.TextBox Txt_impresora;
        private System.Windows.Forms.Label label4;
    }
}