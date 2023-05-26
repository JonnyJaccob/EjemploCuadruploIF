namespace EjemploCuadruplosYCiclo
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.rchCodigoEjemplo = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rchCodigoCargado = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnInsertar = new System.Windows.Forms.Button();
			this.btnCargar = new System.Windows.Forms.Button();
			this.btnSalir = new System.Windows.Forms.Button();
			this.dtgViewTablaSimbolo = new System.Windows.Forms.DataGridView();
			this.dtgColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColTipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColTokenUnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgViewCuadruplo = new System.Windows.Forms.DataGridView();
			this.dtgColIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColDatoObj = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColDatoF1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColDatoF2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtgColOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnLlenar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtgViewTablaSimbolo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgViewCuadruplo)).BeginInit();
			this.SuspendLayout();
			// 
			// rchCodigoEjemplo
			// 
			this.rchCodigoEjemplo.Location = new System.Drawing.Point(12, 25);
			this.rchCodigoEjemplo.Name = "rchCodigoEjemplo";
			this.rchCodigoEjemplo.Size = new System.Drawing.Size(217, 261);
			this.rchCodigoEjemplo.TabIndex = 0;
			this.rchCodigoEjemplo.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "CodigoEjemplo";
			// 
			// rchCodigoCargado
			// 
			this.rchCodigoCargado.Location = new System.Drawing.Point(235, 25);
			this.rchCodigoCargado.Name = "rchCodigoCargado";
			this.rchCodigoCargado.Size = new System.Drawing.Size(217, 261);
			this.rchCodigoCargado.TabIndex = 2;
			this.rchCodigoCargado.Text = "";
			this.rchCodigoCargado.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(248, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Codigo Cargado ";
			// 
			// btnInsertar
			// 
			this.btnInsertar.Location = new System.Drawing.Point(15, 311);
			this.btnInsertar.Name = "btnInsertar";
			this.btnInsertar.Size = new System.Drawing.Size(75, 23);
			this.btnInsertar.TabIndex = 4;
			this.btnInsertar.Text = "Insertar";
			this.btnInsertar.UseVisualStyleBackColor = true;
			this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
			// 
			// btnCargar
			// 
			this.btnCargar.Location = new System.Drawing.Point(107, 311);
			this.btnCargar.Name = "btnCargar";
			this.btnCargar.Size = new System.Drawing.Size(75, 23);
			this.btnCargar.TabIndex = 5;
			this.btnCargar.Text = "Cargar";
			this.btnCargar.UseVisualStyleBackColor = true;
			this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(203, 311);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(75, 23);
			this.btnSalir.TabIndex = 6;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// dtgViewTablaSimbolo
			// 
			this.dtgViewTablaSimbolo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgViewTablaSimbolo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgColID,
            this.dtgColVariable,
            this.dtgColTipoDato,
            this.dtgColToken,
            this.dtgColValor,
            this.dtgColTokenUnico,
            this.dtgColFila});
			this.dtgViewTablaSimbolo.Location = new System.Drawing.Point(477, 184);
			this.dtgViewTablaSimbolo.Name = "dtgViewTablaSimbolo";
			this.dtgViewTablaSimbolo.Size = new System.Drawing.Size(343, 150);
			this.dtgViewTablaSimbolo.TabIndex = 7;
			// 
			// dtgColID
			// 
			this.dtgColID.HeaderText = "ID";
			this.dtgColID.Name = "dtgColID";
			this.dtgColID.ReadOnly = true;
			// 
			// dtgColVariable
			// 
			this.dtgColVariable.HeaderText = "Variable";
			this.dtgColVariable.Name = "dtgColVariable";
			this.dtgColVariable.ReadOnly = true;
			// 
			// dtgColTipoDato
			// 
			this.dtgColTipoDato.HeaderText = "TipoDato";
			this.dtgColTipoDato.Name = "dtgColTipoDato";
			this.dtgColTipoDato.ReadOnly = true;
			// 
			// dtgColToken
			// 
			this.dtgColToken.HeaderText = "Token";
			this.dtgColToken.Name = "dtgColToken";
			this.dtgColToken.ReadOnly = true;
			// 
			// dtgColValor
			// 
			this.dtgColValor.HeaderText = "Valor";
			this.dtgColValor.Name = "dtgColValor";
			this.dtgColValor.ReadOnly = true;
			// 
			// dtgColTokenUnico
			// 
			this.dtgColTokenUnico.HeaderText = "Token Unico";
			this.dtgColTokenUnico.Name = "dtgColTokenUnico";
			this.dtgColTokenUnico.ReadOnly = true;
			// 
			// dtgColFila
			// 
			this.dtgColFila.HeaderText = "Fila";
			this.dtgColFila.Name = "dtgColFila";
			this.dtgColFila.ReadOnly = true;
			// 
			// dtgViewCuadruplo
			// 
			this.dtgViewCuadruplo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgViewCuadruplo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgColIndex,
            this.dtgColDatoObj,
            this.dtgColDatoF1,
            this.dtgColDatoF2,
            this.dtgColOperacion});
			this.dtgViewCuadruplo.Location = new System.Drawing.Point(477, 9);
			this.dtgViewCuadruplo.Name = "dtgViewCuadruplo";
			this.dtgViewCuadruplo.Size = new System.Drawing.Size(343, 150);
			this.dtgViewCuadruplo.TabIndex = 8;
			// 
			// dtgColIndex
			// 
			this.dtgColIndex.HeaderText = "Indice";
			this.dtgColIndex.Name = "dtgColIndex";
			this.dtgColIndex.ReadOnly = true;
			// 
			// dtgColDatoObj
			// 
			this.dtgColDatoObj.HeaderText = "Dato Objeto";
			this.dtgColDatoObj.Name = "dtgColDatoObj";
			this.dtgColDatoObj.ReadOnly = true;
			// 
			// dtgColDatoF1
			// 
			this.dtgColDatoF1.HeaderText = "Dato Fuente 1";
			this.dtgColDatoF1.Name = "dtgColDatoF1";
			this.dtgColDatoF1.ReadOnly = true;
			// 
			// dtgColDatoF2
			// 
			this.dtgColDatoF2.HeaderText = "Dato Fuente 2";
			this.dtgColDatoF2.Name = "dtgColDatoF2";
			this.dtgColDatoF2.ReadOnly = true;
			// 
			// dtgColOperacion
			// 
			this.dtgColOperacion.HeaderText = "Operacion";
			this.dtgColOperacion.Name = "dtgColOperacion";
			this.dtgColOperacion.ReadOnly = true;
			// 
			// btnLlenar
			// 
			this.btnLlenar.Location = new System.Drawing.Point(285, 311);
			this.btnLlenar.Name = "btnLlenar";
			this.btnLlenar.Size = new System.Drawing.Size(26, 23);
			this.btnLlenar.TabIndex = 9;
			this.btnLlenar.Text = "?";
			this.btnLlenar.UseVisualStyleBackColor = true;
			this.btnLlenar.Click += new System.EventHandler(this.btnLlenar_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(832, 346);
			this.Controls.Add(this.btnLlenar);
			this.Controls.Add(this.dtgViewCuadruplo);
			this.Controls.Add(this.dtgViewTablaSimbolo);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.btnCargar);
			this.Controls.Add(this.btnInsertar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rchCodigoCargado);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rchCodigoEjemplo);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dtgViewTablaSimbolo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgViewCuadruplo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox rchCodigoEjemplo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox rchCodigoCargado;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnInsertar;
		private System.Windows.Forms.Button btnCargar;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.DataGridView dtgViewTablaSimbolo;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColID;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColVariable;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColTipoDato;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColToken;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColValor;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColTokenUnico;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColFila;
		private System.Windows.Forms.DataGridView dtgViewCuadruplo;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColIndex;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColDatoObj;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColDatoF1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColDatoF2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dtgColOperacion;
		private System.Windows.Forms.Button btnLlenar;
	}
}

