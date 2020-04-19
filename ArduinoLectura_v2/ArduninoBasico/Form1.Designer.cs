namespace ArduninoBasico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonConectar = new System.Windows.Forms.Button();
            this.comboPuerto = new System.Windows.Forms.ComboBox();
            this.labelPuerto = new System.Windows.Forms.Label();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.labelDatos = new System.Windows.Forms.Label();
            this.textEncoder1 = new System.Windows.Forms.TextBox();
            this.labelEncoder1 = new System.Windows.Forms.Label();
            this.labelEncoder2 = new System.Windows.Forms.Label();
            this.textEncoder2 = new System.Windows.Forms.TextBox();
            this.labelAngSharp = new System.Windows.Forms.Label();
            this.textAngSharp = new System.Windows.Forms.TextBox();
            this.labelDistSharp = new System.Windows.Forms.Label();
            this.textDistSharp = new System.Windows.Forms.TextBox();
            this.labelPosicion = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.textX = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelGama = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.textGama = new System.Windows.Forms.TextBox();
            this.labelMov = new System.Windows.Forms.Label();
            this.buttonLin = new System.Windows.Forms.Button();
            this.buttonRot = new System.Windows.Forms.Button();
            this.textLin = new System.Windows.Forms.TextBox();
            this.textRot = new System.Windows.Forms.TextBox();
            this.labelLin = new System.Windows.Forms.Label();
            this.labelRot = new System.Windows.Forms.Label();
            this.labelPwmLin = new System.Windows.Forms.Label();
            this.labelPwmRot = new System.Windows.Forms.Label();
            this.textPwmLin = new System.Windows.Forms.TextBox();
            this.textPwmRot = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonConectar
            // 
            this.buttonConectar.Location = new System.Drawing.Point(12, 81);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(86, 23);
            this.buttonConectar.TabIndex = 3;
            this.buttonConectar.Text = "Conectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboPuerto
            // 
            this.comboPuerto.FormattingEnabled = true;
            this.comboPuerto.Location = new System.Drawing.Point(12, 25);
            this.comboPuerto.Name = "comboPuerto";
            this.comboPuerto.Size = new System.Drawing.Size(86, 21);
            this.comboPuerto.TabIndex = 6;
            // 
            // labelPuerto
            // 
            this.labelPuerto.AutoSize = true;
            this.labelPuerto.Location = new System.Drawing.Point(12, 9);
            this.labelPuerto.Name = "labelPuerto";
            this.labelPuerto.Size = new System.Drawing.Size(38, 13);
            this.labelPuerto.TabIndex = 8;
            this.labelPuerto.Text = "Puerto";
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(12, 52);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(86, 23);
            this.buttonActualizar.TabIndex = 9;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.Location = new System.Drawing.Point(134, 9);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(35, 13);
            this.labelDatos.TabIndex = 10;
            this.labelDatos.Text = "Datos";
            // 
            // textEncoder1
            // 
            this.textEncoder1.Enabled = false;
            this.textEncoder1.Location = new System.Drawing.Point(193, 25);
            this.textEncoder1.Name = "textEncoder1";
            this.textEncoder1.Size = new System.Drawing.Size(69, 20);
            this.textEncoder1.TabIndex = 11;
            // 
            // labelEncoder1
            // 
            this.labelEncoder1.AutoSize = true;
            this.labelEncoder1.Location = new System.Drawing.Point(134, 28);
            this.labelEncoder1.Name = "labelEncoder1";
            this.labelEncoder1.Size = new System.Drawing.Size(53, 13);
            this.labelEncoder1.TabIndex = 12;
            this.labelEncoder1.Text = "Encoder1";
            // 
            // labelEncoder2
            // 
            this.labelEncoder2.AutoSize = true;
            this.labelEncoder2.Location = new System.Drawing.Point(134, 57);
            this.labelEncoder2.Name = "labelEncoder2";
            this.labelEncoder2.Size = new System.Drawing.Size(53, 13);
            this.labelEncoder2.TabIndex = 13;
            this.labelEncoder2.Text = "Encoder2";
            // 
            // textEncoder2
            // 
            this.textEncoder2.Enabled = false;
            this.textEncoder2.Location = new System.Drawing.Point(193, 55);
            this.textEncoder2.Name = "textEncoder2";
            this.textEncoder2.Size = new System.Drawing.Size(69, 20);
            this.textEncoder2.TabIndex = 14;
            // 
            // labelAngSharp
            // 
            this.labelAngSharp.AutoSize = true;
            this.labelAngSharp.Location = new System.Drawing.Point(134, 86);
            this.labelAngSharp.Name = "labelAngSharp";
            this.labelAngSharp.Size = new System.Drawing.Size(54, 13);
            this.labelAngSharp.TabIndex = 15;
            this.labelAngSharp.Text = "AngSharp";
            // 
            // textAngSharp
            // 
            this.textAngSharp.Enabled = false;
            this.textAngSharp.Location = new System.Drawing.Point(193, 83);
            this.textAngSharp.Name = "textAngSharp";
            this.textAngSharp.Size = new System.Drawing.Size(69, 20);
            this.textAngSharp.TabIndex = 16;
            // 
            // labelDistSharp
            // 
            this.labelDistSharp.AutoSize = true;
            this.labelDistSharp.Location = new System.Drawing.Point(134, 114);
            this.labelDistSharp.Name = "labelDistSharp";
            this.labelDistSharp.Size = new System.Drawing.Size(53, 13);
            this.labelDistSharp.TabIndex = 17;
            this.labelDistSharp.Text = "DistSharp";
            // 
            // textDistSharp
            // 
            this.textDistSharp.Enabled = false;
            this.textDistSharp.Location = new System.Drawing.Point(193, 111);
            this.textDistSharp.Name = "textDistSharp";
            this.textDistSharp.Size = new System.Drawing.Size(69, 20);
            this.textDistSharp.TabIndex = 18;
            // 
            // labelPosicion
            // 
            this.labelPosicion.AutoSize = true;
            this.labelPosicion.Location = new System.Drawing.Point(304, 9);
            this.labelPosicion.Name = "labelPosicion";
            this.labelPosicion.Size = new System.Drawing.Size(47, 13);
            this.labelPosicion.TabIndex = 19;
            this.labelPosicion.Text = "Posición";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(304, 28);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 20;
            this.labelX.Text = "X";
            // 
            // textX
            // 
            this.textX.Enabled = false;
            this.textX.Location = new System.Drawing.Point(345, 26);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(69, 20);
            this.textX.TabIndex = 21;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(304, 58);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 22;
            this.labelY.Text = "Y";
            // 
            // labelGama
            // 
            this.labelGama.AutoSize = true;
            this.labelGama.Location = new System.Drawing.Point(304, 86);
            this.labelGama.Name = "labelGama";
            this.labelGama.Size = new System.Drawing.Size(35, 13);
            this.labelGama.TabIndex = 23;
            this.labelGama.Text = "Gama";
            // 
            // textY
            // 
            this.textY.Enabled = false;
            this.textY.Location = new System.Drawing.Point(345, 58);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(69, 20);
            this.textY.TabIndex = 24;
            // 
            // textGama
            // 
            this.textGama.Enabled = false;
            this.textGama.Location = new System.Drawing.Point(345, 83);
            this.textGama.Name = "textGama";
            this.textGama.Size = new System.Drawing.Size(69, 20);
            this.textGama.TabIndex = 25;
            // 
            // labelMov
            // 
            this.labelMov.AutoSize = true;
            this.labelMov.Location = new System.Drawing.Point(12, 181);
            this.labelMov.Name = "labelMov";
            this.labelMov.Size = new System.Drawing.Size(61, 13);
            this.labelMov.TabIndex = 26;
            this.labelMov.Text = "Movimiento";
            // 
            // buttonLin
            // 
            this.buttonLin.Location = new System.Drawing.Point(12, 197);
            this.buttonLin.Name = "buttonLin";
            this.buttonLin.Size = new System.Drawing.Size(75, 23);
            this.buttonLin.TabIndex = 27;
            this.buttonLin.Text = "Línea recta";
            this.buttonLin.UseVisualStyleBackColor = true;
            this.buttonLin.Click += new System.EventHandler(this.buttonLin_Click);
            // 
            // buttonRot
            // 
            this.buttonRot.Location = new System.Drawing.Point(12, 226);
            this.buttonRot.Name = "buttonRot";
            this.buttonRot.Size = new System.Drawing.Size(75, 23);
            this.buttonRot.TabIndex = 28;
            this.buttonRot.Text = "Rotar";
            this.buttonRot.UseVisualStyleBackColor = true;
            this.buttonRot.Click += new System.EventHandler(this.buttonRot_Click);
            // 
            // textLin
            // 
            this.textLin.Location = new System.Drawing.Point(93, 200);
            this.textLin.Name = "textLin";
            this.textLin.Size = new System.Drawing.Size(76, 20);
            this.textLin.TabIndex = 29;
            this.textLin.Text = "0";
            // 
            // textRot
            // 
            this.textRot.Location = new System.Drawing.Point(93, 229);
            this.textRot.Name = "textRot";
            this.textRot.Size = new System.Drawing.Size(76, 20);
            this.textRot.TabIndex = 30;
            this.textRot.Text = "0";
            // 
            // labelLin
            // 
            this.labelLin.AutoSize = true;
            this.labelLin.Location = new System.Drawing.Point(175, 203);
            this.labelLin.Name = "labelLin";
            this.labelLin.Size = new System.Drawing.Size(21, 13);
            this.labelLin.TabIndex = 31;
            this.labelLin.Text = "cm";
            // 
            // labelRot
            // 
            this.labelRot.AutoSize = true;
            this.labelRot.Location = new System.Drawing.Point(175, 232);
            this.labelRot.Name = "labelRot";
            this.labelRot.Size = new System.Drawing.Size(39, 13);
            this.labelRot.TabIndex = 32;
            this.labelRot.Text = "grados";
            // 
            // labelPwmLin
            // 
            this.labelPwmLin.AutoSize = true;
            this.labelPwmLin.Location = new System.Drawing.Point(259, 203);
            this.labelPwmLin.Name = "labelPwmLin";
            this.labelPwmLin.Size = new System.Drawing.Size(34, 13);
            this.labelPwmLin.TabIndex = 33;
            this.labelPwmLin.Text = "PWM";
            // 
            // labelPwmRot
            // 
            this.labelPwmRot.AutoSize = true;
            this.labelPwmRot.Location = new System.Drawing.Point(259, 232);
            this.labelPwmRot.Name = "labelPwmRot";
            this.labelPwmRot.Size = new System.Drawing.Size(34, 13);
            this.labelPwmRot.TabIndex = 34;
            this.labelPwmRot.Text = "PWM";
            // 
            // textPwmLin
            // 
            this.textPwmLin.Location = new System.Drawing.Point(299, 199);
            this.textPwmLin.Name = "textPwmLin";
            this.textPwmLin.Size = new System.Drawing.Size(76, 20);
            this.textPwmLin.TabIndex = 35;
            this.textPwmLin.Text = "255";
            // 
            // textPwmRot
            // 
            this.textPwmRot.Location = new System.Drawing.Point(299, 228);
            this.textPwmRot.Name = "textPwmRot";
            this.textPwmRot.Size = new System.Drawing.Size(76, 20);
            this.textPwmRot.TabIndex = 36;
            this.textPwmRot.Text = "255";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ArduninoBasico.Properties.Resources.Dibujo_En_Blanco;
            this.pictureBox1.Location = new System.Drawing.Point(435, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 505);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.Location = new System.Drawing.Point(321, 111);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(75, 23);
            this.buttonReiniciar.TabIndex = 38;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 531);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textPwmRot);
            this.Controls.Add(this.textPwmLin);
            this.Controls.Add(this.labelPwmRot);
            this.Controls.Add(this.labelPwmLin);
            this.Controls.Add(this.labelRot);
            this.Controls.Add(this.labelLin);
            this.Controls.Add(this.textRot);
            this.Controls.Add(this.textLin);
            this.Controls.Add(this.buttonRot);
            this.Controls.Add(this.buttonLin);
            this.Controls.Add(this.labelMov);
            this.Controls.Add(this.textGama);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.labelGama);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelPosicion);
            this.Controls.Add(this.textDistSharp);
            this.Controls.Add(this.labelDistSharp);
            this.Controls.Add(this.textAngSharp);
            this.Controls.Add(this.labelAngSharp);
            this.Controls.Add(this.textEncoder2);
            this.Controls.Add(this.labelEncoder2);
            this.Controls.Add(this.labelEncoder1);
            this.Controls.Add(this.textEncoder1);
            this.Controls.Add(this.labelDatos);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.labelPuerto);
            this.Controls.Add(this.comboPuerto);
            this.Controls.Add(this.buttonConectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboPuerto;
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.Label labelPuerto;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Label labelDatos;
        private System.Windows.Forms.TextBox textEncoder1;
        private System.Windows.Forms.Label labelEncoder1;
        private System.Windows.Forms.Label labelEncoder2;
        private System.Windows.Forms.TextBox textEncoder2;
        private System.Windows.Forms.Label labelAngSharp;
        private System.Windows.Forms.TextBox textAngSharp;
        private System.Windows.Forms.Label labelDistSharp;
        private System.Windows.Forms.TextBox textDistSharp;
        private System.Windows.Forms.Label labelPosicion;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelGama;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TextBox textGama;
        private System.Windows.Forms.Label labelMov;
        private System.Windows.Forms.Button buttonLin;
        private System.Windows.Forms.Button buttonRot;
        private System.Windows.Forms.TextBox textLin;
        private System.Windows.Forms.TextBox textRot;
        private System.Windows.Forms.Label labelLin;
        private System.Windows.Forms.Label labelRot;
        private System.Windows.Forms.Label labelPwmLin;
        private System.Windows.Forms.Label labelPwmRot;
        private System.Windows.Forms.TextBox textPwmLin;
        private System.Windows.Forms.TextBox textPwmRot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonReiniciar;
    }
}

