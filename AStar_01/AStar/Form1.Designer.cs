namespace AStar
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
            this.tablero = new System.Windows.Forms.DataGridView();
            this.buttonEjecutar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonObstaculo = new System.Windows.Forms.RadioButton();
            this.radioButtonInicio = new System.Windows.Forms.RadioButton();
            this.radioButtonMeta = new System.Windows.Forms.RadioButton();
            this.radioButtonNinguno = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelInicio = new System.Windows.Forms.Label();
            this.labelMeta = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablero.Location = new System.Drawing.Point(12, 32);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(528, 442);
            this.tablero.TabIndex = 0;
            this.tablero.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablero_CellClick);
            // 
            // buttonEjecutar
            // 
            this.buttonEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEjecutar.Location = new System.Drawing.Point(558, 441);
            this.buttonEjecutar.Name = "buttonEjecutar";
            this.buttonEjecutar.Size = new System.Drawing.Size(171, 33);
            this.buttonEjecutar.TabIndex = 1;
            this.buttonEjecutar.Text = "Ejecutar";
            this.buttonEjecutar.UseVisualStyleBackColor = true;
            this.buttonEjecutar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Algoritmo A*";
            // 
            // radioButtonObstaculo
            // 
            this.radioButtonObstaculo.AutoSize = true;
            this.radioButtonObstaculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonObstaculo.Location = new System.Drawing.Point(558, 74);
            this.radioButtonObstaculo.Name = "radioButtonObstaculo";
            this.radioButtonObstaculo.Size = new System.Drawing.Size(127, 29);
            this.radioButtonObstaculo.TabIndex = 3;
            this.radioButtonObstaculo.Text = "Obstáculo";
            this.radioButtonObstaculo.UseVisualStyleBackColor = true;
            // 
            // radioButtonInicio
            // 
            this.radioButtonInicio.AutoSize = true;
            this.radioButtonInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInicio.Location = new System.Drawing.Point(558, 109);
            this.radioButtonInicio.Name = "radioButtonInicio";
            this.radioButtonInicio.Size = new System.Drawing.Size(80, 29);
            this.radioButtonInicio.TabIndex = 4;
            this.radioButtonInicio.Text = "Inicio";
            this.radioButtonInicio.UseVisualStyleBackColor = true;
            // 
            // radioButtonMeta
            // 
            this.radioButtonMeta.AutoSize = true;
            this.radioButtonMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMeta.Location = new System.Drawing.Point(558, 144);
            this.radioButtonMeta.Name = "radioButtonMeta";
            this.radioButtonMeta.Size = new System.Drawing.Size(78, 29);
            this.radioButtonMeta.TabIndex = 5;
            this.radioButtonMeta.Text = "Meta";
            this.radioButtonMeta.UseVisualStyleBackColor = true;
            // 
            // radioButtonNinguno
            // 
            this.radioButtonNinguno.AutoSize = true;
            this.radioButtonNinguno.Checked = true;
            this.radioButtonNinguno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNinguno.Location = new System.Drawing.Point(558, 39);
            this.radioButtonNinguno.Name = "radioButtonNinguno";
            this.radioButtonNinguno.Size = new System.Drawing.Size(110, 29);
            this.radioButtonNinguno.TabIndex = 6;
            this.radioButtonNinguno.TabStop = true;
            this.radioButtonNinguno.Text = "Ninguno";
            this.radioButtonNinguno.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(555, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "f(n)=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(552, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "g(n)=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(554, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "h(n)=";
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicio.Location = new System.Drawing.Point(668, 113);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(61, 25);
            this.labelInicio.TabIndex = 10;
            this.labelInicio.Text = "(X,Y)";
            // 
            // labelMeta
            // 
            this.labelMeta.AutoSize = true;
            this.labelMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeta.Location = new System.Drawing.Point(668, 148);
            this.labelMeta.Name = "labelMeta";
            this.labelMeta.Size = new System.Drawing.Size(61, 25);
            this.labelMeta.TabIndex = 11;
            this.labelMeta.Text = "(X,Y)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(551, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Celda ( X,Y)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 484);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMeta);
            this.Controls.Add(this.labelInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonNinguno);
            this.Controls.Add(this.radioButtonMeta);
            this.Controls.Add(this.radioButtonInicio);
            this.Controls.Add(this.radioButtonObstaculo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEjecutar);
            this.Controls.Add(this.tablero);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablero;
        private System.Windows.Forms.Button buttonEjecutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonObstaculo;
        private System.Windows.Forms.RadioButton radioButtonInicio;
        private System.Windows.Forms.RadioButton radioButtonMeta;
        private System.Windows.Forms.RadioButton radioButtonNinguno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Label labelMeta;
        private System.Windows.Forms.Label label5;
    }
}

