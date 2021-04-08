using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupervisorioDASC
{
    public partial class Form1 : Form
    {
        String RxString;
        String txt_Rec = string.Empty;

        Int32 baundRate = 9600;
        Int32 bitDados = 8;

        List<string> dataList = new List<string>();
        String txt_List = string.Empty;
        int qtde_data = 0;

        String timeAquisicao;
        Double count;
        Double duracao;
        public Form1()
        {
            InitializeComponent();
        }
         
        private void updateCom()
        {
            //clear all items in cb Ports
            cbPorts.Items.Clear();
            /* Each port name idenify will be add in the s variable */
            foreach (string s in SerialPort.GetPortNames())
            {
                //add the s variable to each cbPorts Item
                cbPorts.Items.Add(s);
            }

            //Select the 0 index of cbPorts
            cbPorts.SelectedIndex = 0;
        }
        /*private void parity()
        {
            //control combo variable 
            int i = 0;

            //clean all the items in cbParity
            cbParity.Items.Clear();

            //each parity name identified will be add to s
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                //Add the s variable to cbParity's Items
                cbParity.Items.Add(s);

                //Verify if the s value is igual None, if it is select the its item to be show
                if (s == "None")
                    cbParity.SelectedIndex = i;

                //Increment the i variable
                i++;
            }
        }*/
        /*private void stopBits()
        {
            //control combo variable 
            int i = 0;

            //clean all the items in cbStopBits
            cbStopBits.Items.Clear();

            //each Stop Bit name identified will be add to s
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                //Add the s variable to cbStopBits Items
                cbStopBits.Items.Add(s);

                //Verify if the s value is igual One, if it is select the its item to be show
                if (s == "One")
                    cbStopBits.SelectedIndex = i;

                //Increment the i variable
                i++;
            }
        }*/
        private void Form1_Load(object sender, EventArgs e)
        {
            updateCom();

            //cbBaund.SelectedText = "9600";

            //parity();

            //cbDataBits.SelectedText = "8";

            //stopBits();

            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnExit.Enabled = true;
            btnIniciar.Enabled = false;
            btnFinalizar.Enabled = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen == true) Serial.Close();

            Serial.PortName = cbPorts.Text;
            Serial.BaudRate = baundRate;
            Serial.Parity = Parity.None;
            Serial.DataBits = bitDados;
            Serial.StopBits = StopBits.One;

            try
            {
                Serial.Open();
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                btnExit.Enabled = false;
                btnIniciar.Enabled = true;
                btnFinalizar.Enabled = false;
            }
            catch
            {
                MessageBox.Show("It wasn't possible to open the port",
                                "WARING",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnExit.Enabled = false;
                btnFinalizar.Enabled = false;
                btnIniciar.Enabled = false;
      
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Serial.Write("FN000000\r"); //envia a mensagem de finalização para o arduino
            tmrApp.Enabled = false; //para a contagem do tempo do timer
            timeAquisicao = string.Empty; //limpa a variável que informa o intervalo de tempo do timer

            Serial.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnExit.Enabled = true;
            btnIniciar.Enabled = false;
            btnFinalizar.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Close();
        }
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = Serial.ReadExisting(); //recebe as strings vindas do serial 

            //chama outra thread para escrever o dado em algum lugar do formulário
            this.Invoke(new EventHandler(TreatRecivedData));
        }
        private void TreatRecivedData(object sender, EventArgs e)
        {
            string[] txtSplit; //variável para armazenar as partes da variável enviada pelo arduino
            txt_Rec += RxString; //armazena as strings que chegam na serial na variável txt_rec
            
            if(txt_Rec.Length >= 45) //confere se a variável tem 45 caractéres ou mais
            {
                txtSplit = txt_Rec.Split(':'); //divide os caracteres tendo como referencia ':'
                txt_Rec = string.Empty;

                if (txtSplit[0] == "AN0") //verifica se o primeiro grupo de caractere começa com 'ANO'
                {
                    txt_List = txtSplit[1] + ',' + txtSplit[3] + ',' + txtSplit[5] + 
                                              ',' + txtSplit[7] + ',' + txtSplit[9]; //Armazena as informações recebidas em uma variável que vai ser salva num arquivo txt

                    //escreve as informações recebidas pelo arduino nos labels do supervisório
                    lblSolar.Text       = txtSplit[1];
                    lblTempInicial.Text = txtSplit[3];
                    lblTempFinal.Text   = txtSplit[5];
                    lblTempAmb.Text     = txtSplit[7];
                    lblUmidade.Text     = txtSplit[9];
                }
                    
                /*switch(txt_Rec.Substring(0,1))
                {
                    case "A":
                        lblSolar.Text = txt_Rec.Substring(4, 4);
                        txt_List = txt_Rec.Substring(4, 4);
                        break;
                    case "B":
                        lblTempInicial.Text = txt_Rec.Substring(4, 4);
                        txt_List += ", " + txt_Rec.Substring(4, 4);
                        break;
                    case "C":
                        lblTempFinal.Text = txt_Rec.Substring(4, 4);
                        txt_List += ", " + txt_Rec.Substring(4, 4);
                        break;
                    case "D":
                        lblTempAmb.Text = txt_Rec.Substring(4, 4);
                        txt_List += ", " + txt_Rec.Substring(4, 4);
                        break;
                    case "E":
                        lblUmidade.Text = txt_Rec.Substring(4, 4);
                        txt_List += ", " + txt_Rec.Substring(4, 4);
                        break;
                }
                
                txt_Rec = string.Empty;*/
            }
        }

        private void tmrApp_Tick(object sender, EventArgs e)
        {
         
            dataList.Add(Convert.ToString(count) + "," + txt_List); //armazena o tempo do experimento de acordo com a variável count e tamabém 
                                                                    //as informações recebidas do arduino e armazenada na string txt_List
            //Serial.Write(dataList[qtde_data]);
           
            qtde_data++; //indica a quantidade de linhas que serão salvas no arquivo
            
            //termina o experimento se o tempo do experimento for igual ou maior que a tempo estabelecido pel usuário
            if(count >= duracao)
            {
                Serial.Write("FN000000\r"); //envia a mensagem de finalização para o arduino
                tmrApp.Enabled = false; //para a contagem do tempo do timer
                timeAquisicao = string.Empty; //limpa a variável que informa o intervalo de tempo do timer

                Serial.Close(); //termina a comunicação serial
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnExit.Enabled = true;
                btnIniciar.Enabled = false;
                btnFinalizar.Enabled = false;
            }

            count += count; //incrementa a contagem do tempo para um novo ciclo
        }
     
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(Serial.IsOpen)
            {
                Serial.Write("FN000000\r"); //envia a mensagem de finalização para o arduino
                tmrApp.Enabled = false; //para a contagem do tempo do timer
                timeAquisicao = string.Empty; //limpa a variável que informa o intervalo de tempo do timer

                Serial.Close(); //termina a comunicação serial

                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnExit.Enabled = true;
                btnIniciar.Enabled = false;
                btnFinalizar.Enabled = false;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                timeAquisicao = tbxTimeAquisicao.Text; //armazena o tempo de aquisição informado pelo usuário na variável 
                count = Convert.ToDouble(timeAquisicao); //converte o valor para double, para fazer a contagem do tempo ao decorrer do esperimento
                tmrApp.Interval = Int32.Parse(timeAquisicao) * 1000; //indica qual vai ser o intervalo do timer de acordo com o valor informado pelo usuário

                duracao = Convert.ToDouble(tbxDuracao.Text) * 60000; ; //armazena o tempo de duracao do experimento informado pelo usuário em minutos convertendo ele para milisegundos

                Serial.Write("IN000000\r"); //envia a mensagem de inicialização para o arduino
                tmrApp.Enabled = true; //início da contagem do timer 

                btnFinalizar.Enabled = true;
            }

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter Arq; //criar arquivo que serão armazenado os dados

            try
            {
                if(svArquivo.ShowDialog() == DialogResult.OK)
                {
                    Arq = File.AppendText(svArquivo.FileName); //indica o nome do arquivo

                    Arq.WriteLine("Tempo, Intensidade Solar, Temperatura Inicial, Temperatura Final, " +
                                                              "Temperatura Ambiente, Umidade Ambiente"); //escreve os labels de cada coluna na primeira linha

                    //escreve todos os dados armazenados na variável dataList
                    for (int i = 0; i < qtde_data; i++)
                        Arq.WriteLine(dataList[i]);

                    Arq.Close();
                }

                MessageBox.Show("Arquivo salvo com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
        }
    }
}
