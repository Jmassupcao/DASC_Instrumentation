﻿
namespace SupervisorioDASC
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.Serial = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSetPointVazao = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSetPointTemp = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxSetPointVM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxSetPointTemp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxTimeAquisicao = new System.Windows.Forms.TextBox();
            this.tbxDuracao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblUmidade = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblTempAmb = new System.Windows.Forms.Label();
            this.lblTempFinal = new System.Windows.Forms.Label();
            this.lblTempInicial = new System.Windows.Forms.Label();
            this.lblSolar = new System.Windows.Forms.Label();
            this.tmrApp = new System.Windows.Forms.Timer(this.components);
            this.mnApp = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svArquivo = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mnApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPorts);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(6, 54);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(100, 24);
            this.cbPorts.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bits de Parada: One";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bit de Dados: 8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paridade: None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baund Rate (bps): 9600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Porta:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(326, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Fechar Porta";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(326, 72);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(98, 36);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Abrir Porta";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(741, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Sair";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Serial
            // 
            this.Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_DataReceived);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSetPointVazao);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblSetPointTemp);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbxSetPointVM);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbxSetPointTemp);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxTimeAquisicao);
            this.groupBox2.Controls.Add(this.tbxDuracao);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnFinalizar);
            this.groupBox2.Controls.Add(this.lblUmidade);
            this.groupBox2.Controls.Add(this.btnIniciar);
            this.groupBox2.Controls.Add(this.lblTempAmb);
            this.groupBox2.Controls.Add(this.lblTempFinal);
            this.groupBox2.Controls.Add(this.lblTempInicial);
            this.groupBox2.Controls.Add(this.lblSolar);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 348);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experimento";
            // 
            // lblSetPointVazao
            // 
            this.lblSetPointVazao.AutoSize = true;
            this.lblSetPointVazao.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetPointVazao.Location = new System.Drawing.Point(471, 283);
            this.lblSetPointVazao.Name = "lblSetPointVazao";
            this.lblSetPointVazao.Size = new System.Drawing.Size(141, 58);
            this.lblSetPointVazao.TabIndex = 29;
            this.lblSetPointVazao.Text = "0000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(478, 266);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 17);
            this.label17.TabIndex = 28;
            this.label17.Text = "Set Point Vazão:";
            // 
            // lblSetPointTemp
            // 
            this.lblSetPointTemp.AutoSize = true;
            this.lblSetPointTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetPointTemp.Location = new System.Drawing.Point(304, 283);
            this.lblSetPointTemp.Name = "lblSetPointTemp";
            this.lblSetPointTemp.Size = new System.Drawing.Size(141, 58);
            this.lblSetPointTemp.TabIndex = 27;
            this.lblSetPointTemp.Text = "0000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(311, 266);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Set Point Temperaura:";
            // 
            // tbxSetPointVM
            // 
            this.tbxSetPointVM.Location = new System.Drawing.Point(268, 133);
            this.tbxSetPointVM.Name = "tbxSetPointVM";
            this.tbxSetPointVM.Size = new System.Drawing.Size(100, 22);
            this.tbxSetPointVM.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Set Point Vazão do moto (ml/min): ";
            // 
            // tbxSetPointTemp
            // 
            this.tbxSetPointTemp.Location = new System.Drawing.Point(268, 95);
            this.tbxSetPointTemp.Name = "tbxSetPointTemp";
            this.tbxSetPointTemp.Size = new System.Drawing.Size(100, 22);
            this.tbxSetPointTemp.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Set Point da Temperatura (ºC):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tempo de Aquisição (segundos):";
            // 
            // tbxTimeAquisicao
            // 
            this.tbxTimeAquisicao.Location = new System.Drawing.Point(268, 62);
            this.tbxTimeAquisicao.Name = "tbxTimeAquisicao";
            this.tbxTimeAquisicao.Size = new System.Drawing.Size(100, 22);
            this.tbxTimeAquisicao.TabIndex = 20;
            // 
            // tbxDuracao
            // 
            this.tbxDuracao.Location = new System.Drawing.Point(268, 27);
            this.tbxDuracao.Name = "tbxDuracao";
            this.tbxDuracao.Size = new System.Drawing.Size(100, 22);
            this.tbxDuracao.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Duração do Experimento (minutos) :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(166, 266);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 16;
            this.label14.Text = "Umidade Ambiente:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 266);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Temperatura Ambiente:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "Temperatura Final:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(156, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Temperatura Inicial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Intensidade Solar:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(493, 64);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(98, 33);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblUmidade
            // 
            this.lblUmidade.AutoSize = true;
            this.lblUmidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUmidade.Location = new System.Drawing.Point(159, 283);
            this.lblUmidade.Name = "lblUmidade";
            this.lblUmidade.Size = new System.Drawing.Size(141, 58);
            this.lblUmidade.TabIndex = 11;
            this.lblUmidade.Text = "0000";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(493, 21);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(98, 33);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTempAmb
            // 
            this.lblTempAmb.AutoSize = true;
            this.lblTempAmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempAmb.Location = new System.Drawing.Point(-1, 283);
            this.lblTempAmb.Name = "lblTempAmb";
            this.lblTempAmb.Size = new System.Drawing.Size(141, 58);
            this.lblTempAmb.TabIndex = 10;
            this.lblTempAmb.Text = "0000";
            // 
            // lblTempFinal
            // 
            this.lblTempFinal.AutoSize = true;
            this.lblTempFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempFinal.Location = new System.Drawing.Point(310, 193);
            this.lblTempFinal.Name = "lblTempFinal";
            this.lblTempFinal.Size = new System.Drawing.Size(141, 58);
            this.lblTempFinal.TabIndex = 9;
            this.lblTempFinal.Text = "0000";
            // 
            // lblTempInicial
            // 
            this.lblTempInicial.AutoSize = true;
            this.lblTempInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempInicial.Location = new System.Drawing.Point(149, 193);
            this.lblTempInicial.Name = "lblTempInicial";
            this.lblTempInicial.Size = new System.Drawing.Size(141, 58);
            this.lblTempInicial.TabIndex = 8;
            this.lblTempInicial.Text = "0000";
            // 
            // lblSolar
            // 
            this.lblSolar.AutoSize = true;
            this.lblSolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolar.Location = new System.Drawing.Point(-3, 193);
            this.lblSolar.Name = "lblSolar";
            this.lblSolar.Size = new System.Drawing.Size(137, 58);
            this.lblSolar.TabIndex = 6;
            this.lblSolar.Text = "0000";
            // 
            // tmrApp
            // 
            this.tmrApp.Tick += new System.EventHandler(this.tmrApp_Tick);
            // 
            // mnApp
            // 
            this.mnApp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.mnApp.Location = new System.Drawing.Point(0, 0);
            this.mnApp.Name = "mnApp";
            this.mnApp.Size = new System.Drawing.Size(883, 28);
            this.mnApp.TabIndex = 6;
            this.mnApp.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // svArquivo
            // 
            this.svArquivo.DefaultExt = "txt";
            this.svArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.svArquivo.Title = "Salvar Arquivo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SupervisorioDASC.Properties.Resources.poliUpe;
            this.pictureBox1.Location = new System.Drawing.Point(461, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 174);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mnApp);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mnApp.ResumeLayout(false);
            this.mnApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.IO.Ports.SerialPort Serial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblSolar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUmidade;
        private System.Windows.Forms.Label lblTempAmb;
        private System.Windows.Forms.Label lblTempFinal;
        private System.Windows.Forms.Label lblTempInicial;
        protected System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDuracao;
        private System.Windows.Forms.TextBox tbxTimeAquisicao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrApp;
        private System.Windows.Forms.MenuStrip mnApp;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog svArquivo;
        private System.Windows.Forms.TextBox tbxSetPointTemp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxSetPointVM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSetPointVazao;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSetPointTemp;
        private System.Windows.Forms.Label label15;
    }
}

