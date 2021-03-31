using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Serial.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnExit.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = Serial.ReadExisting();

            //chama outra thread para escrever o dado em algum lugar do formulário
            this.Invoke(new EventHandler(TreatRecivedData));
        }
        private void TreatRecivedData(object sender, EventArgs e)
        {
            txt_Rec += RxString;
            
            if(txt_Rec.Length >= 8)
            {
                switch(txt_Rec.Substring(0,1))
                {
                    case "A":
                        lblSolar.Text = txt_Rec.Substring(4, 4);
                        break;
                    case "B":
                        lblTempInicial.Text = txt_Rec.Substring(4, 4);
                        break;
                    case "C":
                        lblTempFinal.Text = txt_Rec.Substring(4, 4);
                        break;
                    case "D":
                        lblTempAmb.Text = txt_Rec.Substring(4, 4);
                        break;
                    case "E":
                        lblUmidade.Text = txt_Rec.Substring(4, 4);
                        break;
                }
                
                txt_Rec = string.Empty;
            }
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(Serial.IsOpen)
            {
                Serial.Write("FN000000\r");
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                Serial.Write("IN000000\r");
            }

        }
    }
}
