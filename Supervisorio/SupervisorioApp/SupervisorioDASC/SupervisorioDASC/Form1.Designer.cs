
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(6, 58);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(100, 24);
            this.cbPorts.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bits de Parada: One";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bit de Dados: 8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paridade: None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baund Rate (bps): 9600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Porta:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(326, 73);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Fechar Porta";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(326, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(98, 32);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Abrir Porta";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(676, 367);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 28);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 273);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controle ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 65);
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
            this.label6.Size = new System.Drawing.Size(248, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Duração do Experimento (segundos) :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(302, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 16;
            this.label14.Text = "Umidade Ambiente:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(302, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Temperatura Ambiente:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(155, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "Temperatura Final:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Temperatura Inicial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Intensidade Solar:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(493, 64);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(98, 29);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblUmidade
            // 
            this.lblUmidade.AutoSize = true;
            this.lblUmidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUmidade.Location = new System.Drawing.Point(295, 213);
            this.lblUmidade.Name = "lblUmidade";
            this.lblUmidade.Size = new System.Drawing.Size(141, 58);
            this.lblUmidade.TabIndex = 11;
            this.lblUmidade.Text = "0000";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(493, 21);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(98, 29);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTempAmb
            // 
            this.lblTempAmb.AutoSize = true;
            this.lblTempAmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempAmb.Location = new System.Drawing.Point(295, 129);
            this.lblTempAmb.Name = "lblTempAmb";
            this.lblTempAmb.Size = new System.Drawing.Size(141, 58);
            this.lblTempAmb.TabIndex = 10;
            this.lblTempAmb.Text = "0000";
            // 
            // lblTempFinal
            // 
            this.lblTempFinal.AutoSize = true;
            this.lblTempFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempFinal.Location = new System.Drawing.Point(148, 213);
            this.lblTempFinal.Name = "lblTempFinal";
            this.lblTempFinal.Size = new System.Drawing.Size(141, 58);
            this.lblTempFinal.TabIndex = 9;
            this.lblTempFinal.Text = "0000";
            // 
            // lblTempInicial
            // 
            this.lblTempInicial.AutoSize = true;
            this.lblTempInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempInicial.Location = new System.Drawing.Point(148, 129);
            this.lblTempInicial.Name = "lblTempInicial";
            this.lblTempInicial.Size = new System.Drawing.Size(141, 58);
            this.lblTempInicial.TabIndex = 8;
            this.lblTempInicial.Text = "0000";
            // 
            // lblSolar
            // 
            this.lblSolar.AutoSize = true;
            this.lblSolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolar.Location = new System.Drawing.Point(5, 129);
            this.lblSolar.Name = "lblSolar";
            this.lblSolar.Size = new System.Drawing.Size(137, 58);
            this.lblSolar.TabIndex = 6;
            this.lblSolar.Text = "0000";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SupervisorioDASC.Properties.Resources.poliUpe;
            this.pictureBox1.Location = new System.Drawing.Point(441, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 120);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 415);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
    }
}

