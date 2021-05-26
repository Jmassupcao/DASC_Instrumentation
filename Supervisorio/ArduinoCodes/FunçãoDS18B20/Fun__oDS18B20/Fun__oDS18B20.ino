#include <OneWire.h>
#include <DallasTemperature.h>

//================================ Mapeamento de Hardware ============================//
#define SensorLM35 A0 //Pino o qual o sensor está conectado
 
int Sensor = 13;  // Define o pino 13 como “sensor na saída do coletor”
DeviceAddress SensorEntrada = { 0x28, 0xAA, 0xBE, 0x24, 0x54, 0x14, 0x01, 0x72 }; //Define como sensor1 o sensor desse código
DeviceAddress SensorSaida = { 0x28, 0x31, 0x1A, 0x88, 0x13, 0x19, 0x01, 0x6E }; //Define como sensor2 o sensor desse código

//#define SensorEntrada 12  // Define o pino 12 como “sensor na entrada do coletro”
//#define PotenciometroAjustetemp 1 //Ajuste do setpoint da temperatura
//#define Rele_Peltier 6

int pinEnableMotorA = 11;      //Porta Digital PWM~
int pinEnableMotorB = 10;     //Porta Digital PWM~

int pinSentido1MotorA = 3;
int pinSentido2MotorA = 2;


int pinSentido1MotorB = 7;
int pinSentido2MotorB = 6;


OneWire oneWire(Sensor);//cria primeiramente um objeto referente ao o pino que será utilizado para transmissão de dados.
DallasTemperature sensors(&oneWire);//objeto que será responsável por representar o barramento de sensores no código
int valor = 0;
int valor3 = 0;

//=========================== Declarando Variáveis Globais =========================//
float Constante = 17.05;// Constante para estabelecer a faixa de temperatura de 0 à 60 Graus ==> 1023/60 = 17.05
float  temperatura; // Variável que recebe o valor convertido para temperatura.
int ValorAjustado = 0;


boolean adc; //variável de iniciação do códgo, muda para true quando recebe o comando do serial 
char rec[100]; //variável que irá receber os caracteres vindos da serial
int i=0; //variável de controle para a variável rec


int  pinSolar = A3;   //pino do conversor AD do sensor solar
//int  pintempIn = 1;  //pino do conversor AD do sensor de temperatura inicial do DASC
//int  pintempFn = 2;  //pino do conversor AD do sensor de temperatura final do DASC
//int  pintempAmb = 3; //pino do conversor AD do sensor de temperatura ambiente
int  pinUmidAmb = A4; //pino do conversor AD do sensor de umidade ambiente

//int pinPeltier = 3; //pino usado para o controle da placa peltier
int pinMotor   = A5; //pino usado para o controle da bomba peristáltica 

String   setPointtemp; //variável para amarzenar o set poit da temperatura da célula peltier
String   setPointVM;   //variável para amarzenar o set point da vazão do moto 
bool stringFlag = true;
int showSPtemp;
int showSPVM;

//int tempEntrada;
//int tempSaida;
float tempAmbiente;
//int Temperature;
//int Temperature2;


void setup() {
  Serial.begin(9600);

  pinMode(SensorLM35, INPUT);//Define como Entrada o Sensor ambiente

  pinMode(pinEnableMotorA, OUTPUT);
  pinMode(pinEnableMotorB, OUTPUT);

  pinMode(pinSentido1MotorA, OUTPUT);
  pinMode(pinSentido2MotorA, OUTPUT);
  pinMode(pinSentido1MotorB, OUTPUT);
  pinMode(pinSentido2MotorB, OUTPUT);

  
  //pinMode(pinPeltier, OUTPUT);
  pinMode(pinMotor, OUTPUT);

  sensors.begin();
  
  sensors.setResolution(SensorEntrada, 10);
  sensors.setResolution(SensorSaida, 10);

  sensors.getAddress(SensorEntrada, 0);
  sensors.getAddress(SensorEntrada, 1);

}

 /*******************************************************************************************************
    ------------------------------função do programa: Sensor(Entrada e Saída) Temperatura DS18B20-------------------
    *******************************************************************************************************/
void peltier(DeviceAddress Sensor,int estado, int pinEnableMotor,int pinSentido1Motor, int pinSentido2Motor, int ValorSetPoint)
{
    sensors.requestTemperatures();
    delay(100);
    float temp = sensors.getTempCByIndex(Sensor); //Obtem o valor do sensor
    String temperatura = String(temp);
    int valor = map(valor, 0, 1023, 0, 255);
    //Serial.print(temperatura);
    if (temperatura == "-127.00") // acho de depois posso tirar
    {
      // do nothing
    }
      else
    {
      //Serial.print("Temperature do NanoFluido(Saída) : ");
      //Serial.println(sensors.getTempCByIndex(0));
      //Serial.print(temperatura);
      //Serial.println();
      delay(500);
    }
    
    int Temperature = temp;

    switch(estado){
      case 1: //entrada
        if (Temperature <= ValorSetPoint)
        {
          //digitalWrite(Rele_Peltier, HIGH);
          int valor2 = 255;
          //int valor2 = 6*valor;//Fazer uma equação para colocar a tensão idela na saída da ponte H
          analogWrite(pinEnableMotor, valor2); //Valor do PWM no MOTOR
          digitalWrite(pinSentido1Motor, LOW); //Ativa o sentido para refrigerar
          digitalWrite(pinSentido2Motor, HIGH);
          delay(1000);
        }
        if (Temperature >= (ValorSetPoint + 2))
        {
          analogWrite(pinEnableMotor, 0);
        }
        break;

      case 2: //saída
        if (Temperature >= ValorSetPoint)
        {
          //digitalWrite(Rele_Peltier, HIGH);
          int valor2 = 255;
          //int valor2 = 6*valor;//Fazer uma equação para colocar a tensão idela na saída da ponte H
          analogWrite(pinEnableMotor, valor2); //Valor do PWM no MOTOR
          digitalWrite(pinSentido1Motor, LOW); //Ativa o sentido para refrigerar
          digitalWrite(pinSentido2Motor, HIGH);
          delay(1000);
        }
        if (Temperature <= (ValorSetPoint - 2))
        {
          analogWrite(pinEnableMotor, 0);
        }
        break;
    }
    
}

int tempDS18B20(DeviceAddress Sensor)
{
   sensors.requestTemperatures();
   delay(100);
   int temp = sensors.getTempCByIndex(Sensor); //Obtem o valor do sensor

   return temp;
}


void loop() {
  
 
  //espera até que a variável adc mude para true
  if(adc){

        /*******************************************************************************************************  
    -------Converte os valores de Set Point da bomba peristaltica e da placa peltier para Inteiro-----------
    *******************************************************************************************************/
    showSPtemp = setPointtemp.toInt();
    showSPVM = setPointVM.toInt();
    
 

    
    /*******************************************************************************************************  
    ------------------------------função do programa: verificar a temperatura Ambiente-------------------
    *******************************************************************************************************/
    float valor_analog_SensorLM35 = float(analogRead(SensorLM35)); // Obtém o valor analógico que varia de 0 a 1023
    float tensao = (valor_analog_SensorLM35 * 5) / 1023;           // Converter esse valor para tensão elétrica((5/tensão) =  (1023/Valor analog))
    tempAmbiente = tensao / 0.010;                           // dividimos a tensão por 0.010 que representa os 10 mV

    //Serial.print("temperatura Ambiente : ");
    //Serial.println(tempAmbiente); // Mostra na serial a temperatura do sensor

    //delay(500);

    /*******************************************************************************************************
    ------------------------------função do programa:Setpoint-------------------
    *******************************************************************************************************/
    valor = showSPtemp; //valor do set point da temperatura para controlar a saída em PWM
    valor = map(valor, 0, 1023, 0, 255);

    ValorAjustado = showSPtemp / Constante;
    //Serial.print("Setpoint : ");
    //Serial.print(ValorAjustado);
    //Serial.println();
    delay(500);

     /*******************************************************************************************************
    ------------------------------função do programa: Sensor(Entrada e Saída) Temperatura DS18B20-------------------
    *******************************************************************************************************/
    peltier(SensorEntrada, 1, pinEnableMotorA, pinSentido1MotorA, pinSentido2MotorA, ValorAjustado);
    peltier(SensorSaida, 2, pinEnableMotorB, pinSentido1MotorB, pinSentido2MotorB, ValorAjustado);
    

  /*******************************************************************************************************
  ------------------------------Enviando as informações para a serial------------------------------------
  *******************************************************************************************************/
    enviarSerial(pinSolar, tempDS18B20(SensorEntrada), tempDS18B20(SensorSaida), tempAmbiente, pinUmidAmb,showSPtemp, showSPVM);
  }
    
}

/*******************************************************************************************************
-----------------Evento que espera a comunicação com o serial e trata o dado recebido-------------------
*******************************************************************************************************/
void serialEvent()
{
  while(Serial.available())
  {
    rec[i]= (char)Serial.read(); //caso tenha, recupera o byte e armazena na posição 'i' de 'rec'

    if(rec[i] == '\r')//verifica se o dado recebido é igual a CR (0X0D)
    {
      i=0;

      //se os primeiros caracteres forem 'IN'
      if((rec[0]=='I') && (rec[1] == 'N'))
      {
         adc = true; //Muda para verdadeiro a variável de iniciação
          
         //recebe e trata os dados do set point da Temperatura e vazão do motor 
         for(int a=3; a<=sizeof(rec); a++)
         {
            if((rec[a] != ':') && (stringFlag)) //enquanto a string recebida for diferente de ':' o valor é referente ao set point da temperatura 
            {
              setPointtemp += rec[a]; //armazena o valor do set point da temperatura no formato string
            }
            else //caso o valor recebido seja ":" os próximos bytes seram referentes ao set point da Vazão do motor 
            {
              if(rec[a] == ':' && (!stringFlag)) //caso seja recebido mais um byte ':' indica o fim do tratamento
              {
                break; 
              }
              else //caso não os bytes da vazão do motor são amarzenados na variável 
              {
                setPointVM += rec[a+1];
              }
              
              stringFlag = false; 
            
            }
         }
      }

      //Se os primeiros caractéres foram "FN"
      if((rec[0]=='F') && (rec[1]=='N'))
      {
        adc = false; //Muda para falso a variável de iniciação 

        //limpa as variáveis de set point 
        setPointtemp = "";
        setPointVM   = "";

        //desliga os componentes ativos do DASC
        analogWrite(pinEnableMotorA, 0);
        analogWrite(pinEnableMotorB, 0);
        analogWrite(pinMotor, 0);
      }
        
    }
    else
      i++;
      stringFlag = true; 
  }
}


/*******************************************************************************************************
-----------------Função de envio das informações do arduino para o supervisório-------------------------
*******************************************************************************************************/

void enviarSerial(int solar, int tempEntrada, int tempSaida, int tempAmbiente, int umidadeAmbiente, int setPointTemp, int setPointVM)
{
  
  int adSolar = analogRead(solar);
  //int adTwo = analogRead(two);
  //int adThree = analogRead(three);
  //int adTempAmbiente = analogRead(tempAmbiente);
  int adUmidadeAmbiente = analogRead(umidadeAmbiente);

  char ad_buffer[64];

  snprintf(ad_buffer, sizeof(ad_buffer), "AN0:%04d:BN0:%04d:CN0:%04d:DN0:%04d:EN0:%04d:FN0:%04d:GN0:%04d:", 
                                                  adSolar, tempEntrada, tempSaida, tempAmbiente, adUmidadeAmbiente, setPointTemp, setPointVM);
  Serial.print(ad_buffer);
  delay(300); 
}
