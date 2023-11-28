namespace CriandoCRUD
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.Salvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listContatos = new System.Windows.Forms.ListView();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.BuscarBut = new System.Windows.Forms.Button();
            this.ClearFormulary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefone";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(16, 30);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 76);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(16, 127);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(100, 20);
            this.txtTelefone.TabIndex = 5;
            // 
            // Salvar
            // 
            this.Salvar.Location = new System.Drawing.Point(67, 153);
            this.Salvar.Name = "Salvar";
            this.Salvar.Size = new System.Drawing.Size(49, 20);
            this.Salvar.TabIndex = 6;
            this.Salvar.Text = "Salvar";
            this.Salvar.UseVisualStyleBackColor = true;
            this.Salvar.Click += new System.EventHandler(this.CreateAndUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Buscar contato";
            // 
            // listContatos
            // 
            this.listContatos.HideSelection = false;
            this.listContatos.Location = new System.Drawing.Point(145, 59);
            this.listContatos.MultiSelect = false;
            this.listContatos.Name = "listContatos";
            this.listContatos.Size = new System.Drawing.Size(252, 97);
            this.listContatos.TabIndex = 8;
            this.listContatos.UseCompatibleStateImageBehavior = false;
            this.listContatos.SelectedIndexChanged += new System.EventHandler(this.listContatos_SelectedIndexChanged);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(145, 30);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(182, 20);
            this.txtbuscar.TabIndex = 9;
            // 
            // BuscarBut
            // 
            this.BuscarBut.Location = new System.Drawing.Point(334, 30);
            this.BuscarBut.Name = "BuscarBut";
            this.BuscarBut.Size = new System.Drawing.Size(63, 23);
            this.BuscarBut.TabIndex = 10;
            this.BuscarBut.Text = "Buscar";
            this.BuscarBut.UseVisualStyleBackColor = true;
            this.BuscarBut.Click += new System.EventHandler(this.Read_Click);
            // 
            // ClearFormulary
            // 
            this.ClearFormulary.Location = new System.Drawing.Point(16, 153);
            this.ClearFormulary.Name = "ClearFormulary";
            this.ClearFormulary.Size = new System.Drawing.Size(46, 20);
            this.ClearFormulary.TabIndex = 11;
            this.ClearFormulary.Text = "Limpar";
            this.ClearFormulary.UseVisualStyleBackColor = true;
            this.ClearFormulary.Click += new System.EventHandler(this.ClearFormulary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 193);
            this.Controls.Add(this.ClearFormulary);
            this.Controls.Add(this.BuscarBut);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.listContatos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Salvar);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Button Salvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listContatos;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Button BuscarBut;
        private System.Windows.Forms.Button ClearFormulary;
    }
}

