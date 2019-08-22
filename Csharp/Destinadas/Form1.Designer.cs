namespace Destinadas
{
    partial class Destinadas
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.lb = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbAguarde = new System.Windows.Forms.Label();
            this.txtDtInicial = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTodas = new System.Windows.Forms.RadioButton();
            this.rdOutras = new System.Windows.Forms.RadioButton();
            this.rdRecebidas = new System.Windows.Forms.RadioButton();
            this.rdEmitidas = new System.Windows.Forms.RadioButton();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.txtDtFinal = new System.Windows.Forms.MaskedTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRetornoXml = new System.Windows.Forms.TextBox();
            this.txtArquivoXml = new System.Windows.Forms.TextBox();
            this.btnEscolher = new System.Windows.Forms.Button();
            this.dialogArquivo = new System.Windows.Forms.OpenFileDialog();
            this.lbExportacaoXML = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(8, 27);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(325, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(342, 27);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(198, 20);
            this.txtSenha.TabIndex = 3;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(8, 72);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(532, 20);
            this.txtToken.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Token da Software House";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtLogin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSenha);
            this.panel2.Controls.Add(this.txtToken);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 558);
            this.panel2.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(877, 455);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Busca de notas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(860, 274);
            this.dataGridView1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbExportacaoXML);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCaminho);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(6, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 72);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Caminho para salvar os xml";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(7, 30);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(511, 20);
            this.txtCaminho.TabIndex = 20;
            this.txtCaminho.Text = "C:\\xml\\";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(752, 14);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(0, 13);
            this.lb.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 33);
            this.button1.TabIndex = 17;
            this.button1.Text = "Salvar xml\'s na pasta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbAguarde);
            this.panel3.Controls.Add(this.txtDtInicial);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnConsulta);
            this.panel3.Controls.Add(this.txtDtFinal);
            this.panel3.Location = new System.Drawing.Point(-3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 71);
            this.panel3.TabIndex = 23;
            // 
            // lbAguarde
            // 
            this.lbAguarde.AutoSize = true;
            this.lbAguarde.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbAguarde.Location = new System.Drawing.Point(9, 59);
            this.lbAguarde.Name = "lbAguarde";
            this.lbAguarde.Size = new System.Drawing.Size(0, 13);
            this.lbAguarde.TabIndex = 20;
            // 
            // txtDtInicial
            // 
            this.txtDtInicial.Location = new System.Drawing.Point(9, 23);
            this.txtDtInicial.Mask = "00/00/0000";
            this.txtDtInicial.Name = "txtDtInicial";
            this.txtDtInicial.Size = new System.Drawing.Size(70, 20);
            this.txtDtInicial.TabIndex = 16;
            this.txtDtInicial.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Data inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data final";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdTodas);
            this.groupBox1.Controls.Add(this.rdOutras);
            this.groupBox1.Controls.Add(this.rdRecebidas);
            this.groupBox1.Controls.Add(this.rdEmitidas);
            this.groupBox1.Location = new System.Drawing.Point(206, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo nota";
            // 
            // rdTodas
            // 
            this.rdTodas.AutoSize = true;
            this.rdTodas.Location = new System.Drawing.Point(294, 17);
            this.rdTodas.Name = "rdTodas";
            this.rdTodas.Size = new System.Drawing.Size(55, 17);
            this.rdTodas.TabIndex = 3;
            this.rdTodas.TabStop = true;
            this.rdTodas.Text = "Todas";
            this.rdTodas.UseVisualStyleBackColor = true;
            // 
            // rdOutras
            // 
            this.rdOutras.AutoSize = true;
            this.rdOutras.Location = new System.Drawing.Point(202, 16);
            this.rdOutras.Name = "rdOutras";
            this.rdOutras.Size = new System.Drawing.Size(56, 17);
            this.rdOutras.TabIndex = 2;
            this.rdOutras.TabStop = true;
            this.rdOutras.Text = "Outras";
            this.rdOutras.UseVisualStyleBackColor = true;
            // 
            // rdRecebidas
            // 
            this.rdRecebidas.AutoSize = true;
            this.rdRecebidas.Location = new System.Drawing.Point(110, 16);
            this.rdRecebidas.Name = "rdRecebidas";
            this.rdRecebidas.Size = new System.Drawing.Size(76, 17);
            this.rdRecebidas.TabIndex = 1;
            this.rdRecebidas.TabStop = true;
            this.rdRecebidas.Text = "Recebidas";
            this.rdRecebidas.UseVisualStyleBackColor = true;
            // 
            // rdEmitidas
            // 
            this.rdEmitidas.AutoSize = true;
            this.rdEmitidas.Location = new System.Drawing.Point(18, 18);
            this.rdEmitidas.Name = "rdEmitidas";
            this.rdEmitidas.Size = new System.Drawing.Size(64, 17);
            this.rdEmitidas.TabIndex = 0;
            this.rdEmitidas.TabStop = true;
            this.rdEmitidas.Text = "Emitidas";
            this.rdEmitidas.UseVisualStyleBackColor = true;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(713, 13);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(151, 38);
            this.btnConsulta.TabIndex = 15;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click_1);
            // 
            // txtDtFinal
            // 
            this.txtDtFinal.Location = new System.Drawing.Point(95, 23);
            this.txtDtFinal.Mask = "00/00/0000";
            this.txtDtFinal.Name = "txtDtFinal";
            this.txtDtFinal.Size = new System.Drawing.Size(70, 20);
            this.txtDtFinal.TabIndex = 17;
            this.txtDtFinal.ValidatingType = typeof(System.DateTime);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtRetornoXml);
            this.tabPage2.Controls.Add(this.txtArquivoXml);
            this.tabPage2.Controls.Add(this.btnEscolher);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Enviar xml";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(857, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar XML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Retorno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "XML";
            // 
            // txtRetornoXml
            // 
            this.txtRetornoXml.Location = new System.Drawing.Point(6, 260);
            this.txtRetornoXml.Multiline = true;
            this.txtRetornoXml.Name = "txtRetornoXml";
            this.txtRetornoXml.Size = new System.Drawing.Size(857, 133);
            this.txtRetornoXml.TabIndex = 2;
            // 
            // txtArquivoXml
            // 
            this.txtArquivoXml.Location = new System.Drawing.Point(6, 36);
            this.txtArquivoXml.Multiline = true;
            this.txtArquivoXml.Name = "txtArquivoXml";
            this.txtArquivoXml.Size = new System.Drawing.Size(857, 205);
            this.txtArquivoXml.TabIndex = 1;
            // 
            // btnEscolher
            // 
            this.btnEscolher.Location = new System.Drawing.Point(687, 6);
            this.btnEscolher.Name = "btnEscolher";
            this.btnEscolher.Size = new System.Drawing.Size(179, 24);
            this.btnEscolher.TabIndex = 0;
            this.btnEscolher.Text = "Escolher arquivo XML";
            this.btnEscolher.UseVisualStyleBackColor = true;
            this.btnEscolher.Click += new System.EventHandler(this.BtnEscolher_Click);
            // 
            // dialogArquivo
            // 
            this.dialogArquivo.FileName = "openFileDialog1";
            // 
            // lbExportacaoXML
            // 
            this.lbExportacaoXML.AutoSize = true;
            this.lbExportacaoXML.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbExportacaoXML.Location = new System.Drawing.Point(4, 53);
            this.lbExportacaoXML.Name = "lbExportacaoXML";
            this.lbExportacaoXML.Size = new System.Drawing.Size(0, 13);
            this.lbExportacaoXML.TabIndex = 22;
            // 
            // Destinadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(897, 571);
            this.Controls.Add(this.panel2);
            this.Name = "Destinadas";
            this.Text = "Nota Segura API";
            this.Load += new System.EventHandler(this.Destinadas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDtFinal;
        private System.Windows.Forms.MaskedTextBox txtDtInicial;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRetornoXml;
        private System.Windows.Forms.TextBox txtArquivoXml;
        private System.Windows.Forms.Button btnEscolher;
        private System.Windows.Forms.OpenFileDialog dialogArquivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdTodas;
        private System.Windows.Forms.RadioButton rdOutras;
        private System.Windows.Forms.RadioButton rdRecebidas;
        private System.Windows.Forms.RadioButton rdEmitidas;
        private System.Windows.Forms.Label lbAguarde;
        private System.Windows.Forms.Label lbExportacaoXML;
    }
}

